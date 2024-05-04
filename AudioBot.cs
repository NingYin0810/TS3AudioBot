using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Nini.Config;
using TS3AudioBot;
using TS3AudioBot.Audio;
using TS3AudioBot.CommandSystem;
using TS3AudioBot.Plugins;
using TSLib.Full;
using NeteaseCloudMusicApi;
using QQMusicApi;

public class AudioPlugin : IBotPlugin
{
    //===========================================初始化===========================================
    static IConfigSource MyIni;
    PlayManager tempplayManager;
    InvokerData tempinvoker;
    Ts3Client tempts3Client;
    public static string neteaseCookies;
    public static string qqCookies;
    public static int playMode;
    public static string songPlat;
    public static string neteaseMusicAPI;
    public static string qqMusicAPI;
    public static string qq;
    public static string UNM_Address;
    List<long> playlist = new List<long>();
    List<string> qqplayList = new List<string>();
    public static int Playlocation = 0;
    private readonly SemaphoreSlim playlock = new SemaphoreSlim(1, 1);
    private readonly SemaphoreSlim Listeninglock = new SemaphoreSlim(1, 1);
    private readonly SemaphoreSlim QQplaylock = new SemaphoreSlim(1, 1);
    private readonly SemaphoreSlim QQListeninglock = new SemaphoreSlim(1, 1);
    public void Initialize()
    {
        string iniFilePath;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.WriteLine("运行在Windows环境.");
            iniFilePath = "plugins/Settings.ini"; // Windows 文件目录
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            string dockerEnvFilePath = "/.dockerenv";

            if (File.Exists(dockerEnvFilePath))
            {
                Console.WriteLine("运行在Docker环境.");
            }
            else
            {
                Console.WriteLine("运行在Linux环境.");
            }

            string location = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            iniFilePath = File.Exists(dockerEnvFilePath) ? location + "/data/plugins/YunSettings.ini" : location + "/plugins/YunSettings.ini";
        }
        else
        {
            throw new NotSupportedException("不支持的操作系统");
        }

        Console.WriteLine(iniFilePath);
        MyIni = new IniConfigSource(iniFilePath);

        playMode = int.TryParse(MyIni.Configs["MusicBot"].Get("playMode"), out int playModeValue) ? playModeValue : 0;

        string neteaseCookiesValue = MyIni.Configs["MusicBot"].Get("neteaseCookies");
        neteaseCookies = string.IsNullOrEmpty(neteaseCookiesValue) ? "" : neteaseCookiesValue;

        string neteaseMusicApiValue = MyIni.Configs["MusicBot"].Get("NeteaseMusic_API");
        neteaseMusicAPI = string.IsNullOrEmpty(neteaseMusicApiValue) ? "http://127.0.0.1:3000" : neteaseMusicApiValue;

        string unmAddressValue = MyIni.Configs["MusicBot"].Get("UNM_Address");
        UNM_Address = string.IsNullOrEmpty(unmAddressValue) ? "" : unmAddressValue;

        string qqMusicAPIValue = MyIni.Configs["MusicBot"].Get("QQMusic_API");
        qqMusicAPI = string.IsNullOrEmpty(qqMusicAPIValue) ? "" : qqMusicAPIValue;

        string qqCookieValue = MyIni.Configs["MusicBot"].Get("qqCookie");
        qqCookies = string.IsNullOrEmpty(qqCookieValue) ? "" : qqCookieValue;

        string qqUin = MyIni.Configs["MusicBot"].Get("qq");
        qq = string.IsNullOrEmpty(qqUin) ? "" : qqUin;



        Console.WriteLine("播放模式：" + playMode);
        Console.WriteLine("网抑云COOKIE：" + neteaseCookies);
        Console.WriteLine("网易云音乐API：" + neteaseMusicAPI);
        Console.WriteLine(UNM_Address);
        Console.WriteLine("QQ音乐COOKIE：" + qqCookies);
        Console.WriteLine("QQ音乐API：" + qqMusicAPI);
        Console.WriteLine("QQ号：" + qq);


    }



    public void SetPlplayManager(PlayManager playManager)
    {
        tempplayManager = playManager;
    }
    public PlayManager GetplayManager()
    {
        return tempplayManager;
    }

    public InvokerData Getinvoker()
    {
        return tempinvoker;
    }

    public void SetInvoker(InvokerData invoker)
    {
        tempinvoker = invoker;
    }

    public void SetTs3Client(Ts3Client ts3Client)
    {
        tempts3Client = ts3Client;
    }

    public Ts3Client GetTs3Client()
    {
        return tempts3Client;
    }

    //===========================================初始化===========================================

    //重载命令，待测试
/*    [Command("reload")]
    public void Reload()
    {
        Initialize();
    }*/

    //===========================================播放模式===========================================
    [Command("yun mode")]
    public string Playmode(int mode)
    {
        if (mode >= 0 && mode <= 3)
        {
            playMode = mode;
            MyIni.Configs["MusicBot"].Set("playMode", mode.ToString());
            MyIni.Save();
            return mode switch
            {
                0 => "顺序播放",
                1 => "顺序循环",
                2 => "随机播放",
                3 => "随机循环",
                _ => "未知播放模式",
            };
        }
        else
        {
            return "请输入正确的播放模式(0 到 3 之间的整数)";
        }
    }
    //===========================================播放模式===========================================


    //===========================================单曲播放===========================================
    [Command("yun play")]
    public async Task CommandYunPlay(string arguments, PlayManager playManager, InvokerData invoker, Ts3Client ts3Client)
    {
        //playlist.Clear();
        SetInvoker(invoker);
        SetPlplayManager(playManager);
        SetTs3Client(ts3Client);
        bool songFound = false;
        string urlSearch = $"{neteaseMusicAPI}/search?keywords={arguments}&limit=30";
        string searchJson = await HttpGetAsync(urlSearch);
        yunSearchSong yunSearchSong = JsonSerializer.Deserialize<yunSearchSong>(searchJson);
        string[] splitArguments = arguments.Split(" ");
        Console.WriteLine(splitArguments.Length);
        if (splitArguments.Length == 1)
        {
            _ = ProcessSong(yunSearchSong.result.songs[0].id, ts3Client, playManager, invoker);
            songFound = true;
        }
        else if (splitArguments.Length == 2)
        {
            // 歌曲名称和歌手
            string songName = splitArguments[0];
            string artist = splitArguments[1];

            for (int s = 0; s < yunSearchSong.result.songs.Count; s++)
            {
                if (yunSearchSong.result.songs[s].name == songName && yunSearchSong.result.songs[s].artists[0].name == artist)
                {
                    _ = ProcessSong(yunSearchSong.result.songs[s].id, ts3Client, playManager, invoker);
                    songFound = true;
                    break;
                }
            }
        }
        else
        {
            // 输入为空或格式不符合预期
            Console.WriteLine("请输入有效的歌曲信息");
            _ = ts3Client.SendChannelMessage("请输入有效的歌曲信息");
        }
        Playlocation = songFound && Playlocation > 0 ? Playlocation - 1 : Playlocation;
        if (!songFound)
        {
            _ = ts3Client.SendChannelMessage("未找到歌曲");
        }
    }

    //===========================================单曲播放===========================================


    //===========================================歌单播放===========================================
    [Command("yun gedan")]
    public async Task<string> CommandYunGedan(string arguments, PlayManager playManager, InvokerData invoker, Ts3Client ts3Client, Player player)
    {
        playlist.Clear();
        SetInvoker(invoker);
        SetPlplayManager(playManager);
        SetTs3Client(ts3Client);
        string urlSearch = $"{neteaseMusicAPI}/playlist/detail?id={arguments}";
        string searchJson = await HttpGetAsync(urlSearch);
        GedanDetail gedanDetail = JsonSerializer.Deserialize<GedanDetail>(searchJson);
        string gedanshuliang = gedanDetail.playlist.trackCount.ToString();
        _ = ts3Client.SendChannelMessage($"歌单共{gedanshuliang}首歌曲，正在添加到播放列表,请稍后。");
        int loopCount = -1;
        for (int i = 0; i < gedanDetail.playlist.trackCount; i += 50)
        {
            Console.WriteLine($"查询循环次数{loopCount + 1}");
            loopCount += 1;
            if (i + 50 > gedanDetail.playlist.trackCount)
            {
                // 如果歌单的歌曲数量小于50，那么查询的数量就是歌曲的数量，否则查询的数量就是歌曲的数量减去50乘以查询的次数
                i = gedanDetail.playlist.trackCount < 50 ? gedanDetail.playlist.trackCount : gedanDetail.playlist.trackCount - 50 * loopCount;
                // 构建查询URL，如果歌单的歌曲数量小于50，那么偏移量就是0，否则偏移量就是查询的数量
                int offset = gedanDetail.playlist.trackCount < 50 ? 0 : i;
                urlSearch = $"{neteaseMusicAPI}/playlist/track/all?id={arguments}&limit=50&offset={offset}";
                searchJson = await HttpGetAsync(urlSearch);
                GeDan geDan1 = JsonSerializer.Deserialize<GeDan>(searchJson);
                for (int j = 0; j < i; j++) {
                    playlist.Add(geDan1.songs[j].id);
                    Console.WriteLine(geDan1.songs[j].id);
                }
                break;
            }
            urlSearch = $"{neteaseMusicAPI}/playlist/track/all?id={arguments}&limit=50&offset={i}";
            searchJson = await HttpGetAsync(urlSearch);
            GeDan geDan = JsonSerializer.Deserialize<GeDan>(searchJson);
            for (int j = 0; j < 50; j++) {
                playlist.Add(geDan.songs[j].id);
                Console.WriteLine(geDan.songs[j].id);
            }
        }
        Playlocation = 0;
        _ = ProcessSong(playlist[0], ts3Client, playManager, invoker);
        Console.WriteLine($"歌单共{playlist.Count}首歌");
        await Listeninglock.WaitAsync();
        playManager.ResourceStopped += async (sender, e) => await SongPlayMode(playManager, invoker, ts3Client);
        return $"播放列表加载完成,已加载{playlist.Count}首歌";
    }

    [Command("qq gd")]
    public async Task<string> CommandQQGeDan(string arguments, PlayManager playManager, InvokerData invoker, Ts3Client ts3Client, Player player)
    {
        qqplayList.Clear();
        SetInvoker(invoker);
        SetPlplayManager(playManager);
        SetTs3Client(ts3Client);
        string urlSearch = $"{qqMusicAPI}/songlist?id={arguments}";
        string searchJson = await HttpGetAsync(urlSearch);
        RootObject gedanDetail = JsonSerializer.Deserialize<RootObject>(searchJson);
        Console.WriteLine(gedanDetail.Result);
        if (gedanDetail.Result == 100)
        {
            string gedanshuliang = gedanDetail.Data.Songnum.ToString();
            _ = ts3Client.SendChannelMessage($"歌单共{gedanshuliang}首歌曲，正在添加到播放列表,请稍后。");
            for (int i = 0; i < gedanDetail.Data.Songnum; i++)
            {
                string songid = gedanDetail.Data.Songlist[i].Songmid;
                qqplayList.Add(songid);
                Console.WriteLine(songid);
            }
            Playlocation = 0;
            _ = PlaySongs(qqplayList[0], ts3Client, playManager, invoker);
            Console.WriteLine($"歌单共{qqplayList.Count}首歌");
            await QQListeninglock.WaitAsync();
            playManager.ResourceStopped += async (sender, e) => await QQSongPlayMode(playManager, invoker, ts3Client);
            return $"播放列表加载完成,已加载{qqplayList.Count}首歌";
        }
        else
        {
            return "歌单获取错误";
        }

    }
    //===========================================歌单播放===========================================

    //===========================================下一曲===========================================
    [Command("yun next")]
    public async Task CommandYunNext(PlayManager playManager, InvokerData invoker, Ts3Client ts3Client)
    {
        await SongPlayMode(playManager, invoker, ts3Client);
    }
    [Command("qq next")]
    public async Task CommandQQNext(PlayManager playManager, InvokerData invoker, Ts3Client ts3Client)
    {
        await QQSongPlayMode(playManager, invoker, ts3Client);
    }

    //===========================================下一曲=============================================
    [Command("yun stop")]
    public async Task CommandYunStop(PlayManager playManager, Ts3Client ts3Client)
    {
        playlist.Clear();
        await playManager.Stop();
    }

    [Command("qq stop")]
    public async Task CommandQQStop(PlayManager playManager, Ts3Client ts3Client)
    {
        qqplayList.Clear();
        await playManager.Stop();
    }
    //===========================================播放逻辑===========================================
    private async Task SongPlayMode(PlayManager playManager, InvokerData invoker, Ts3Client ts3Client)
    {
        try
        {
            Console.WriteLine(playMode);
            switch (playMode)
            {
                case 0: //顺序播放
                    Playlocation += 1;
                    await ProcessSong(playlist[Playlocation], ts3Client, playManager, invoker);
                    break;
                case 1:  //顺序循环
                    if (Playlocation == playlist.Count - 1)
                    {
                        Playlocation = 0;
                        await ProcessSong(playlist[Playlocation], ts3Client, playManager, invoker);
                    }
                    else
                    {
                        Playlocation += 1;
                        await ProcessSong(playlist[Playlocation], ts3Client, playManager, invoker);
                    }
                    break;
                case 2:  //随机播放
                    Random random = new Random();
                    Playlocation = random.Next(0, playlist.Count);
                    await ProcessSong(playlist[Playlocation], ts3Client, playManager, invoker);
                    break;
                case 3:  //随机循环
                    Random random1 = new Random();
                    Playlocation = random1.Next(0, playlist.Count);
                    await ProcessSong(playlist[Playlocation], ts3Client, playManager, invoker);
                    break;
                default:
                    Console.WriteLine("DEFAULT");
                    break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("播放列表已空");
            _ = ts3Client.SendChannelMessage("已停止播放");
        }


    }
    private async Task QQSongPlayMode(PlayManager playManager, InvokerData invoker, Ts3Client ts3Client)
    {
        try
        {
            switch (playMode)
            {
            case 0: //顺序播放
                Playlocation += 1;
                await PlaySongs(qqplayList[Playlocation], ts3Client, playManager, invoker);
                break;
            case 1:  //顺序循环
                if (Playlocation == qqplayList.Count - 1)
                {
                    Playlocation = 0;
                    await PlaySongs(qqplayList[Playlocation], ts3Client, playManager, invoker);
                }
                else
                {
                    Playlocation += 1;
                    await PlaySongs(qqplayList[Playlocation], ts3Client, playManager, invoker);
                }
                break;
            case 2:  //随机播放
                Random random = new Random();
                Playlocation = random.Next(0, qqplayList.Count);
                await PlaySongs(qqplayList[Playlocation], ts3Client, playManager, invoker);
                break;
            case 3:  //随机循环
                Random random1 = new Random();
                Playlocation = random1.Next(0, qqplayList.Count);
                await PlaySongs(qqplayList[Playlocation], ts3Client, playManager, invoker);
                break;
            default:
                Playlocation += 1;
                await PlaySongs(qqplayList[Playlocation], ts3Client, playManager, invoker);
                break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("播放列表已空");
            _ = ts3Client.SendChannelMessage("已停止播放");
        }
    }

/*    private async Task ProcessSong(object value, Ts3Client ts3Client, PlayManager playManager, InvokerData invoker)
    {
        throw new NotImplementedException();
    }*/

    // netease music
    private async Task ProcessSong(long id, Ts3Client ts3Client, PlayManager playManager, InvokerData invoker)
    {
        await playlock.WaitAsync();
        try {
            long musicId = id;
            string musicCheckUrl = $"{neteaseMusicAPI}/check/music?id={musicId}";
            string searchMusicCheckJson = await HttpGetAsync(musicCheckUrl);
            MusicCheck musicCheckJson = JsonSerializer.Deserialize<MusicCheck>(searchMusicCheckJson);

            // 根据音乐检查结果获取音乐播放URL
            string musicUrl = musicCheckJson.success.ToString() == "False" ? await GetcheckMusicUrl(musicId, true) : await GetMusicUrl(musicId, true);

            // 构造获取音乐详情的URL
            string musicDetailUrl = $"{neteaseMusicAPI}/song/detail?ids={musicId}";
            string musicDetailJson = await HttpGetAsync(musicDetailUrl);
            MusicDetail musicDetail = JsonSerializer.Deserialize<MusicDetail>(musicDetailJson);

            // 从音乐详情中获取音乐图片URL和音乐名称
            string musicImgUrl = musicDetail.songs[0].al.picUrl;
            string musicName = musicDetail.songs[0].name;
            Console.WriteLine($"歌曲id：{musicId}，歌曲名称：{musicName}，版权：{musicCheckJson.success}");

            // 设置Bot的头像为音乐图片
            _ = MainCommands.CommandBotAvatarSet(ts3Client, musicImgUrl);

            // 设置Bot的描述为音乐名称
            _ = MainCommands.CommandBotDescriptionSet(ts3Client, musicName);

            // 在控制台输出音乐播放URL
            Console.WriteLine(musicUrl);

            // 如果音乐播放URL不是错误，则添加到播放列表并通知频道
            if (musicUrl != "error")
            {
                _ = MainCommands.CommandPlay(playManager, invoker, musicUrl);

                // 更新Bot的描述为当前播放的音乐名称
                _ = MainCommands.CommandBotDescriptionSet(ts3Client, musicName);

                // 发送消息到频道，通知正在播放的音乐
                if (playlist.Count == 0)
                {
                    _ = ts3Client.SendChannelMessage($"正在播放：{musicName}");
                }
                else
                {
                    _ = ts3Client.SendChannelMessage($"正在播放第{Playlocation+1}首：{musicName}");
                }
            }
        }
        finally
        {
            playlock.Release();
        }
    }
    //===========================================播放逻辑===========================================
    // qq music
    private async Task PlaySongs(string id, Ts3Client ts3Client, PlayManager playManager, InvokerData invoker)
    {
        await QQplaylock.WaitAsync();
        string MusicUrl = "error";
        try
        {
            string musicId = id;
            string musicCheckUrl = $"{qqMusicAPI}/song/url?id={musicId}";
            string searchMusicCheckJson = await HttpGetAsync(musicCheckUrl);
            var trackUrlResponse = JsonSerializer.Deserialize<TrackUrlResponse>(searchMusicCheckJson);
            // 获取播放URL
            /*if (trackUrlResponse != null && trackUrlResponse.Result == 100)
            {
                    MusicUrl = trackUrlResponse.Data;
                    Console.WriteLine($"Result: {trackUrlResponse.Result}");
            }*/
            MusicUrl = trackUrlResponse.Data;

            // 构造获取音乐详情的URL
            string musicDetailUrl = $"{qqMusicAPI}/song?songmid={musicId}";
            string musicDetailJson = await HttpGetAsync(musicDetailUrl);
            Root musicDetail = JsonSerializer.Deserialize<Root>(musicDetailJson);
            // 从音乐详情中获取音乐图片URL和音乐名称
            string mid = musicDetail.Data2.TrackInfo.Album.Mid;
            string musicImgUrl = $"https://y.gtimg.cn/music/photo_new/T002R300x300M000{mid}.jpg";
            string musicName = musicDetail.Data2.TrackInfo.Name;
            Console.WriteLine($"歌曲id：{musicId}，歌曲名称：{musicName}");
            // 设置Bot的头像为音乐图片
            _ = MainCommands.CommandBotAvatarSet(ts3Client, musicImgUrl);

            // 设置Bot的描述为音乐名称
            _ = MainCommands.CommandBotDescriptionSet(ts3Client, musicName);

            // 在控制台输出音乐播放URL
            Console.WriteLine(MusicUrl);

            // 如果音乐播放URL不是错误，则添加到播放列表并通知频道
            if (MusicUrl != "error")
            {
                _ = MainCommands.CommandPlay(playManager, invoker, MusicUrl);

                // 更新Bot的描述为当前播放的音乐名称
                _ = MainCommands.CommandBotDescriptionSet(ts3Client, musicName);

                // 发送消息到频道，通知正在播放的音乐
                if (qqplayList.Count == 0)
                {
                    _ = ts3Client.SendChannelMessage($"正在播放：{musicName}");
                }
                else
                {
                    _ = ts3Client.SendChannelMessage($"正在播放第{Playlocation + 1}首：{musicName}");
                }
            }else if(MusicUrl == "" || MusicUrl == "error"){
                _ = ts3Client.SendChannelMessage($"歌曲《{musicName}》播放失败");
                await PlaySongs(qqplayList[Playlocation + 1], ts3Client, playManager, invoker);
            }
            else
            {
                _ = ts3Client.SendChannelMessage($"歌曲《{musicName}》未知错误");
                await PlaySongs(qqplayList[Playlocation + 1], ts3Client, playManager, invoker);
            }

        }
        finally
        {
            QQplaylock.Release();
        }
    }


    //===========================================登录部分===========================================
    [Command("yun login")]
    public static async Task<string> CommandLoginAsync(Ts3Client ts3Client, TsFullClient tsClient)
    {
        // 获取登录二维码的 key
        string key = await GetLoginKey();

        // 生成登录二维码并获取二维码图片的 base64 字符串
        string base64String = await GetLoginQRImage(key);

        // 发送二维码图片到 TeamSpeak 服务器频道
        await ts3Client.SendChannelMessage("正在生成二维码");
        await ts3Client.SendChannelMessage(base64String);

        // 将 base64 字符串转换为二进制图片数据，上传到 TeamSpeak 服务器作为头像
        await UploadQRImage(tsClient, base64String);

        // 设置 TeamSpeak 服务器的描述信息
        await ts3Client.ChangeDescription("请用网易云APP扫描二维码登陆");

        int i = 0;
        long code;
        string result;

        while (true)
        {
            // 检查登录状态
            Status1 status = await CheckLoginStatus(key);

            code = status.code;
            neteaseCookies = status.cookie;
            i = i + 1;
            Thread.Sleep(1000);

            if (i == 120)
            {
                result = "登陆失败或者超时";
                await ts3Client.SendChannelMessage("登陆失败或者超时");
                break;
            }

            if (code == 803)
            {
                result = "登陆成功";
                await ts3Client.SendChannelMessage("登陆成功");
                break;
            }
        }

        // 登录完成后删除上传的头像
        _ = await tsClient.DeleteAvatar();

        // 更新 neteaseCookies 到配置文件
        MyIni.Configs["MusicBot"].Set("neteaseCookies", $"\"{neteaseCookies}\"");
        MyIni.Save();

        return result;
    }

    // QQ登录
    [Command("qq login")]
    public static async Task<string> QQLoginAsync(Ts3Client ts3Client, TsFullClient tsClient)
    {
        string result;
        string url = qqMusicAPI + "/user/setCookie";
        string qqCookie = await Cookie2Json(qqCookies);
        Console.WriteLine(qqCookie);
        Console.WriteLine("开始QQ登录");
        try
        {
            string json = await HttpPostAsync(url, qqCookie);
            string data;
            int status;
            Console.WriteLine("Received JSON: " + json);

            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                // 访问 JSON 中的字段
                if (doc.RootElement.TryGetProperty("data", out JsonElement dataElement))
                {
                    data = dataElement.GetString();
                    Console.WriteLine(data);
                }
                else
                {
                    throw new Exception("data can't find");
                }

                // 检查是否存在某个字段
                if (doc.RootElement.TryGetProperty("result", out JsonElement resultElement))
                {
                    status = resultElement.GetInt32();
                    if(status == 100)
                    {
                        Console.WriteLine(data);
                        string setCookieApi = qqMusicAPI + "/user/getCookie?id=" + qq;
                        string setCookie = await HttpGetAsync(setCookieApi);
                        CookieStatus cookieStatus = JsonSerializer.Deserialize<CookieStatus>(setCookie);
                        if(cookieStatus.Status == 100 && cookieStatus.Message == "设置 cookie 成功")
                        {
                            result = cookieStatus.Message;
                        }
                    }
                    else
                    {
                        result = "登录失败";
                        throw new Exception(result);
                    }
                }

                // 处理更复杂的数据结构，例如数组或嵌套对象
                result = "QQ登录成功";
            }
        }
        catch (Exception ex)
        {
            result = "Error: " + ex.Message;
            
        }

        return result;
    }

    // 获取登录二维码的 key
    private static async Task<string> GetLoginKey()
    {
        string url = neteaseMusicAPI + "/login/qr/key" + "?timestamp=" + GetTimeStamp();
        string json = await HttpGetAsync(url);
        LoginKey loginKey = JsonSerializer.Deserialize<LoginKey>(json);
        return loginKey.data.unikey;
    }

    // 生成登录二维码并获取二维码图片的 base64 字符串
    private static async Task<string> GetLoginQRImage(string key)
    {
        string url = neteaseMusicAPI + $"/login/qr/create?key={key}&qrimg=true&timestamp={GetTimeStamp()}";
        string json = await HttpGetAsync(url);
        LoginImg loginImg = JsonSerializer.Deserialize<LoginImg>(json);
        return loginImg.data.qrimg;
    }

    // 上传二维码图片到 TeamSpeak 服务器
    private static async Task UploadQRImage(TsFullClient tsClient, string base64String)
    {
        string[] img = base64String.Split(",");
        byte[] bytes = Convert.FromBase64String(img[1]);
        Stream stream = new MemoryStream(bytes);
        _ = await tsClient.UploadAvatar(stream);
    }

    // 检查登录状态
    private static async Task<Status1> CheckLoginStatus(string key)
    {
        string url = neteaseMusicAPI + $"/login/qr/check?key={key}&timestamp={GetTimeStamp()}";
        string json = await HttpGetAsync(url);
        Status1 status = JsonSerializer.Deserialize<Status1>(json);
        Console.WriteLine(json);
        return status;
    }
    //===============================================登录部分===============================================


    //===============================================获取歌曲信息===============================================
    //以下全是功能性函数
    public static async Task<string> GetMusicUrl(long id, bool usingCookie = false)
    {
        return await GetMusicUrl(id.ToString(), usingCookie);
    }

    public static async Task<string> GetMusicUrl(string id, bool usingCookie = false)
    {
        string url = $"{neteaseMusicAPI}/song/url?id={id}";
        if (usingCookie && !string.IsNullOrEmpty(neteaseCookies))
        {
            url += $"&cookie={neteaseCookies}";
        }

        string musicUrlJson = await HttpGetAsync(url);
        musicURL musicUrl = JsonSerializer.Deserialize<musicURL>(musicUrlJson);

        if (musicUrl.code != 200)
        {
            // 处理错误情况，这里你可以根据实际情况进行适当的处理
            return string.Empty;
        }

        string mp3 = musicUrl.data[0].url;
        return mp3;
    }

    public static async Task<string> GetcheckMusicUrl(long id, bool usingcookie = false) //获得无版权歌曲URL
    {
        string url;
        url = neteaseMusicAPI + "/song/url?id=" + id.ToString() + "&proxy=" + UNM_Address;
        string musicurljson = await HttpGetAsync(url);
        musicURL musicurl = JsonSerializer.Deserialize<musicURL>(musicurljson);
        string mp3 = musicurl.data[0].url.ToString();
        string checkmp3 = mp3.Replace("http://music.163.com", UNM_Address);
        return checkmp3;
    }

    public static async Task<string> GetMusicName(string arguments)//获得歌曲名称
    {
        string musicdetailurl = neteaseMusicAPI + "/song/detail?ids=" + arguments;
        string musicdetailjson = await HttpGetAsync(musicdetailurl);
        MusicDetail musicDetail = JsonSerializer.Deserialize<MusicDetail>(musicdetailjson);
        string musicname = musicDetail.songs[0].name;
        return musicname;
    }
    //===============================================获取歌曲信息===============================================



    //===============================================HTTP相关===============================================
    public static async Task<string> HttpGetAsync(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.Accept = "text/html, application/xhtml+xml, */*";
        request.ContentType = "application/json";

        // 异步获取响应
        using HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
        // 异步读取响应流
        using StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        return await reader.ReadToEndAsync();
    }

    public static async Task<string> HttpPostAsync(string url, string jsonData)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/json"; // 确保内容类型为 JSON

        // 将 jsonData 字符串转换为 byte 数组
        byte[] dataBytes = Encoding.UTF8.GetBytes(jsonData);

        // 设置请求内容长度
        request.ContentLength = dataBytes.Length;

        // 异步写入请求数据
        using (Stream stream = await request.GetRequestStreamAsync())
        {
            await stream.WriteAsync(dataBytes, 0, dataBytes.Length);
        }

        // 异步获取响应
        using HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
        // 异步读取响应流
        using StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        return await reader.ReadToEndAsync();
    }

    public static string GetTimeStamp() //获得时间戳
    {
        TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds).ToString();
    }
    //===============================================HTTP相关===============================================
    public void Dispose()
    {
        
    }

    //===========================================QQ相关==================================
    public static async Task<string> Cookie2Json(string cookie)
    {
        var cookieData = new { data = cookie };
        string json = JsonSerializer.Serialize(cookieData);
        return json;
    }
}