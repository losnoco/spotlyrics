SpotLyrics
==========

Fetches lyrics for [Spotify] from [Genius].

Only works on Linux, because it uses D-Bus to listen for Spotify.

Pull requests are **very** encouraged.

Configuration:
--------------
Acquire an access token for Genius at https://genius.com/developers, copy `.env-SAMPLE` to `.env` and replace the placeholder with your access token.

Libraries used:
---------------
* [AngleSharp]
* [DotNetEnv]
* [Genius.NET]
* [Newtonsoft.Json]
* [Tmds.DBus]

[Spotify]: https://spotify.com
[Genius]:  https://genius.com

[AngleSharp]:      https://anglesharp.github.io/
[DotNetEnv]:       https://github.com/tonerdo/dotnet-env
[Genius.NET]:      https://prajjwaldimri.github.io/Genius.NET/
[Newtonsoft.Json]: https://www.newtonsoft.com/json
[Tmds.DBus]:       https://github.com/tmds/Tmds.DBus