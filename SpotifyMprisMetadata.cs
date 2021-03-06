// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using spotlyrics;
//
//    var spotifyMprisMetadata = SpotifyMprisMetadata.FromJson(jsonString);

namespace spotlyrics
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SpotifyMprisMetadata
    {
        [JsonProperty("mpris:trackid")]
        public string MprisTrackid { get; set; }

        [JsonProperty("mpris:length")]
        public long MprisLength { get; set; }

        [JsonProperty("mpris:artUrl")]
        public Uri MprisArtUrl { get; set; }

        [JsonProperty("xesam:album")]
        public string XesamAlbum { get; set; }

        [JsonProperty("xesam:albumArtist")]
        public List<string> XesamAlbumArtist { get; set; }

        [JsonProperty("xesam:artist")]
        public List<string> XesamArtist { get; set; }

        [JsonProperty("xesam:autoRating")]
        public double XesamAutoRating { get; set; }

        [JsonProperty("xesam:discNumber")]
        public long XesamDiscNumber { get; set; }

        [JsonProperty("xesam:title")]
        public string XesamTitle { get; set; }

        [JsonProperty("xesam:trackNumber")]
        public long XesamTrackNumber { get; set; }

        [JsonProperty("xesam:url")]
        public Uri XesamUrl { get; set; }
    }

    public partial class SpotifyMprisMetadata
    {
        public static SpotifyMprisMetadata FromJson(string json) => JsonConvert.DeserializeObject<SpotifyMprisMetadata>(json, spotlyrics.Converter.Settings);

        public static SpotifyMprisMetadata FromMprisObject(IDictionary<String,object> source) {
            var sobj = JsonConvert.SerializeObject(source);
            return FromJson(sobj);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this SpotifyMprisMetadata self) => JsonConvert.SerializeObject(self, spotlyrics.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
