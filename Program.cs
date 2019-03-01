using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tmds.DBus;
using spotify.DBus;

using Newtonsoft.Json;
using Genius;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;

namespace spotlyrics
{
    class Program
    {
        static string tkn = DotNetEnv.Env.GetString("TOKEN");
        static GeniusClient geniusClient;
        static WebClient webClient;
        static HtmlParser parser;

        static async Task Main(string[] args)
        {
            DotNetEnv.Env.Load();

            Console.WriteLine("Watching for metadata...");
            Console.WriteLine();

            geniusClient = new GeniusClient(tkn);

            webClient = new WebClient();

            parser = new HtmlParser();

            var sess = Connection.Session;
            var spotify = sess.CreateProxy<IPlayer>("org.mpris.MediaPlayer2.spotify", "/org/mpris/MediaPlayer2");

            var initialMd = SpotifyMprisMetadata.FromMprisObject(await spotify.GetMetadataAsync());

            var previousID = (string)initialMd.MprisTrackid;

            await GetLyrics(initialMd);
            await spotify.WatchPropertiesAsync(prop =>
            {
                var md = SpotifyMprisMetadata.FromMprisObject(((Dictionary<String, object>)prop.Changed[0].Value));
                var id = md.MprisTrackid;
                if (previousID != id)
                {
                    GetLyrics(md);
                }
                previousID = id;

            });

            await Task.Delay(int.MaxValue);

        }

        static async Task GetLyrics(SpotifyMprisMetadata md)
        {
            var joinedArtists = String.Join(", ", md.XesamArtist);
            var header = $"“{md.XesamTitle}” by {joinedArtists}";

            var simplifiedName = md.XesamTitle.Split(" - ")[0];
            Console.Clear();



            Console.WriteLine($"Searching for {header}...");
            var songs = await geniusClient.SearchClient.Search(Genius.Models.TextFormat.Plain, $"{joinedArtists} {simplifiedName}");

            var firstHit = ((dynamic)songs.Response[0].Result);

            Console.WriteLine($"Getting info for Song ID {firstHit.id} ({firstHit.full_title})...");

            var song = await geniusClient.SongsClient.GetSong(Genius.Models.TextFormat.Plain, firstHit.id.ToString());

            Console.WriteLine("Getting web page...");
            var page = webClient.DownloadString(new Uri((string)firstHit.url));
            var doc = (IHtmlDocument) parser.ParseDocument(page);
            var text = doc.QuerySelector("div.lyrics").TextContent.Trim();

            Console.Clear();
            Console.WriteLine(header);
            Console.WriteLine(new String('-', header.Length));
            Console.WriteLine();
            Console.WriteLine(text);


        }
    }
}
