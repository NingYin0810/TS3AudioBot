using NeteaseCloudMusicApi;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace QQMusicApi
{
    public class RootObject
    {
        [JsonPropertyName("result")]
        public int Result { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("disstid")]
        public string Disstid { get; set; }

        [JsonPropertyName("dir_show")]
        public int Dir_Show { get; set; }

        [JsonPropertyName("owndir")]
        public int Owndir { get; set; }

        [JsonPropertyName("dirid")]
        public int Dirid { get; set; }

        [JsonPropertyName("coveradurl")]
        public string Coveradurl { get; set; }

        [JsonPropertyName("dissid")]
        public int Dissid { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("uin")]
        public string Uin { get; set; }

        [JsonPropertyName("encrypt_uin")]
        public string Encrypt_Uin { get; set; }

        [JsonPropertyName("dissname")]
        public string Dissname { get; set; }

        [JsonPropertyName("logo")]
        public string Logo { get; set; }

        [JsonPropertyName("pic_mid")]
        public string Pic_Mid { get; set; }

        [JsonPropertyName("album_pic_mid")]
        public string Album_Pic_Mid { get; set; }

        [JsonPropertyName("pic_dpi")]
        public int Pic_Dpi { get; set; }

        [JsonPropertyName("isAd")]
        public int IsAd { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("ctime")]
        public long Ctime { get; set; }

        [JsonPropertyName("mtime")]
        public long Mtime { get; set; }

        [JsonPropertyName("headurl")]
        public string Headurl { get; set; }

        [JsonPropertyName("ifpicurl")]
        public string Ifpicurl { get; set; }

        [JsonPropertyName("nick")]
        public string Nick { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("singerid")]
        public int Singerid { get; set; }

        [JsonPropertyName("singermid")]
        public string Singermid { get; set; }

        [JsonPropertyName("isvip")]
        public int Isvip { get; set; }

        [JsonPropertyName("isdj")]
        public int Isdj { get; set; }

        [JsonPropertyName("tags")]
        public int[] Tags { get; set; }

        [JsonPropertyName("songnum")]
        public int Songnum { get; set; }

        [JsonPropertyName("songids")]
        public string Songids { get; set; }

        [JsonPropertyName("songtypes")]
        public string Songtypes { get; set; }

        [JsonPropertyName("disstype")]
        public int Disstype { get; set; }

        [JsonPropertyName("dir_pic_url2")]
        public string Dir_Pic_Url2 { get; set; }

        [JsonPropertyName("song_update_time")]
        public long Song_Update_Time { get; set; }

        [JsonPropertyName("song_update_num")]
        public int Song_Update_Num { get; set; }

        [JsonPropertyName("total_song_num")]
        public int Total_Song_Num { get; set; }

        [JsonPropertyName("song_begin")]
        public int Song_Begin { get; set; }

        [JsonPropertyName("cur_song_num")]
        public int Cur_Song_Num { get; set; }

        [JsonPropertyName("songlist")]
        public Song[] Songlist { get; set; }

        [JsonPropertyName("visitnum")]
        public int Visitnum { get; set; }

        [JsonPropertyName("cmtnum")]
        public int Cmtnum { get; set; }

        [JsonPropertyName("buynum")]
        public int Buynum { get; set; }

        [JsonPropertyName("scoreavage")]
        public string Scoreavage { get; set; }

        [JsonPropertyName("scoreusercount")]
        public int Scoreusercount { get; set; }
    }

    public class Song
    {
        [JsonPropertyName("albumdesc")]
        public string Albumdesc { get; set; }

        [JsonPropertyName("albumid")]
        public int Albumid { get; set; }

        [JsonPropertyName("albummid")]
        public string Albummid { get; set; }

        [JsonPropertyName("albumname")]
        public string Albumname { get; set; }

        [JsonPropertyName("alertid")]
        public int Alertid { get; set; }

        [JsonPropertyName("belongCD")]
        public int BelongCD { get; set; }

        [JsonPropertyName("cdIdx")]
        public int CdIdx { get; set; }

        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        [JsonPropertyName("isonly")]
        public int Isonly { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("msgid")]
        public int Msgid { get; set; }

        [JsonPropertyName("pay")]
        public Pay Pay { get; set; }

        [JsonPropertyName("preview")]
        public Preview Preview { get; set; }

        [JsonPropertyName("rate")]
        public int Rate { get; set; }

        [JsonPropertyName("singer")]
        public Singer[] Singer { get; set; }

        [JsonPropertyName("size128")]
        public int Size128 { get; set; }

        [JsonPropertyName("size320")]
        public int Size320 { get; set; }

        [JsonPropertyName("size5_1")]
        public int Size5_1 { get; set; }

        [JsonPropertyName("sizeape")]
        public int Sizeape { get; set; }

        [JsonPropertyName("sizeflac")]
        public int Sizeflac { get; set; }

        [JsonPropertyName("sizeogg")]
        public int Sizeogg { get; set; }

        [JsonPropertyName("songid")]
        public int Songid { get; set; }

        [JsonPropertyName("songmid")]
        public string Songmid { get; set; }

        [JsonPropertyName("songname")]
        public string Songname { get; set; }

        [JsonPropertyName("songorig")]
        public string Songorig { get; set; }

        [JsonPropertyName("songtype")]
        public int Songtype { get; set; }

        [JsonPropertyName("strMediaMid")]
        public string StrMediaMid { get; set; }

        [JsonPropertyName("stream")]
        public int Stream { get; set; }

        [JsonPropertyName("switch")]
        public int Switch { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("vid")]
        public string Vid { get; set; }
    }

    public class Pay
    {
        [JsonPropertyName("payalbum")]
        public int Payalbum { get; set; }

        [JsonPropertyName("payalbumprice")]
        public int Payalbumprice { get; set; }

        [JsonPropertyName("paydownload")]
        public int Paydownload { get; set; }

        [JsonPropertyName("payinfo")]
        public int Payinfo { get; set; }

        [JsonPropertyName("payplay")]
        public int Payplay { get; set; }

        [JsonPropertyName("paytrackmouth")]
        public int Paytrackmouth { get; set; }

        [JsonPropertyName("paytrackprice")]
        public int Paytrackprice { get; set; }

        [JsonPropertyName("timefree")]
        public int Timefree { get; set; }
    }

    public class Preview
    {
        [JsonPropertyName("trybegin")]
        public int Trybegin { get; set; }

        [JsonPropertyName("tryend")]
        public int Tryend { get; set; }

        [JsonPropertyName("trysize")]
        public int Trysize { get; set; }
    }


    public class Singer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("mid")]
        public string Mid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    public class CookieStatus
    {
        [JsonPropertyName("result")]
        public int Status { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("result")]
        public int Result { get; set; }

        [JsonPropertyName("data")]
        public Data2 Data2 { get; set; }
    }

    public class Data2
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("extras")]
        public Extras Extras { get; set; }

        [JsonPropertyName("track_info")]
        public TrackInfo TrackInfo { get; set; }
    }

    public class Info
    {
        [JsonPropertyName("company")]
        public Category Company { get; set; }

        [JsonPropertyName("genre")]
        public Category Genre { get; set; }

        [JsonPropertyName("lan")]
        public Category Lan { get; set; }

        [JsonPropertyName("pub_time")]
        public Category PubTime { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("content")]
        public List<Content> Content { get; set; }

        [JsonPropertyName("pos")]
        public int Pos { get; set; }

        [JsonPropertyName("more")]
        public int More { get; set; }

        [JsonPropertyName("selected")]
        public string Selected { get; set; }

        [JsonPropertyName("use_platform")]
        public int UsePlatform { get; set; }
    }

    public class Content
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("mid")]
        public string Mid { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("show_type")]
        public int ShowType { get; set; }

        [JsonPropertyName("is_parent")]
        public int IsParent { get; set; }

        [JsonPropertyName("picurl")]
        public string PicUrl { get; set; }

        [JsonPropertyName("read_cnt")]
        public int ReadCnt { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("jumpurl")]
        public string JumpUrl { get; set; }

        [JsonPropertyName("ori_picurl")]
        public string OriPicUrl { get; set; }
    }

    public class Extras
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("transname")]
        public string TransName { get; set; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("wikiurl")]
        public string WikiUrl { get; set; }
    }

    public class TrackInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("mid")]
        public string Mid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }

        [JsonPropertyName("singer")]
        public List<Singer2> Singer2 { get; set; }

        [JsonPropertyName("album")]
        public Album Album { get; set; }

        [JsonPropertyName("mv")]
        public Mv Mv { get; set; }

        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        [JsonPropertyName("isonly")]
        public int Isonly { get; set; }

        [JsonPropertyName("language")]
        public int Language { get; set; }

        [JsonPropertyName("genre")]
        public int Genre { get; set; }

        [JsonPropertyName("index_cd")]
        public int IndexCd { get; set; }

        [JsonPropertyName("index_album")]
        public int IndexAlbum { get; set; }

        [JsonPropertyName("time_public")]
        public string TimePublic { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("fnote")]
        public int Fnote { get; set; }

        [JsonPropertyName("file")]
        public File2 File2 { get; set; }

        [JsonPropertyName("pay")]
        public Pay2 Pay2 { get; set; }

        [JsonPropertyName("action")]
        public Action Action { get; set; }

        [JsonPropertyName("ksong")]
        public Ksong Ksong { get; set; }

        [JsonPropertyName("volume")]
        public Volume Volume { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("bpm")]
        public int Bpm { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("trace")]
        public string Trace { get; set; }

        [JsonPropertyName("data_type")]
        public int DataType { get; set; }

        [JsonPropertyName("modify_stamp")]
        public int ModifyStamp { get; set; }

        [JsonPropertyName("pingpong")]
        public string Pingpong { get; set; }

        [JsonPropertyName("ppurl")]
        public string PpUrl { get; set; }

        [JsonPropertyName("tid")]
        public int Tid { get; set; }

        [JsonPropertyName("ov")]
        public int Ov { get; set; }

        [JsonPropertyName("sa")]
        public int Sa { get; set; }

        [JsonPropertyName("es")]
        public string Es { get; set; }

        [JsonPropertyName("vs")]
        public List<string> Vs { get; set; }

        [JsonPropertyName("vi")]
        public List<int> Vi { get; set; }

        [JsonPropertyName("ktag")]
        public string Ktag { get; set; }

        [JsonPropertyName("vf")]
        public List<double> Vf { get; set; }
    }

    public class Singer2
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("mid")]
        public string Mid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("uin")]
        public int Uin { get; set; }
    }

    public class Album
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("mid")]
        public string Mid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }

        [JsonPropertyName("time_public")]
        public string TimePublic { get; set; }

        [JsonPropertyName("pmid")]
        public string Pmid { get; set; }
    }

    public class Mv
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("vid")]
        public string Vid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("vt")]
        public int Vt { get; set; }
    }

    public class File2
    {
        [JsonPropertyName("media_mid")]
        public string MediaMid { get; set; }

        [JsonPropertyName("size_24aac")]
        public int Size24aac { get; set; }

        [JsonPropertyName("size_48aac")]
        public int Size48aac { get; set; }

        [JsonPropertyName("size_96aac")]
        public int Size96aac { get; set; }

        [JsonPropertyName("size_192ogg")]
        public int Size192ogg { get; set; }

        [JsonPropertyName("size_192aac")]
        public int Size192aac { get; set; }

        [JsonPropertyName("size_128mp3")]
        public int Size128mp3 { get; set; }

        [JsonPropertyName("size_320mp3")]
        public int Size320mp3 { get; set; }

        [JsonPropertyName("size_ape")]
        public int SizeApe { get; set; }

        [JsonPropertyName("size_flac")]
        public int SizeFlac { get; set; }

        [JsonPropertyName("size_dts")]
        public int SizeDts { get; set; }

        [JsonPropertyName("size_try")]
        public int SizeTry { get; set; }

        [JsonPropertyName("try_begin")]
        public int TryBegin { get; set; }

        [JsonPropertyName("try_end")]
        public int TryEnd { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("size_hires")]
        public int SizeHires { get; set; }

        [JsonPropertyName("hires_sample")]
        public int HiresSample { get; set; }

        [JsonPropertyName("hires_bitdepth")]
        public int HiresBitdepth { get; set; }

        [JsonPropertyName("b_30s")]
        public int B30s { get; set; }

        [JsonPropertyName("e_30s")]
        public int E30s { get; set; }

        [JsonPropertyName("size_96ogg")]
        public int Size96ogg { get; set; }

        [JsonPropertyName("size_360ra")]
        public List<int> Size360ra { get; set; }

        [JsonPropertyName("size_dolby")]
        public int SizeDolby { get; set; }

        [JsonPropertyName("size_new")]
        public List<int> SizeNew { get; set; }
    }

    public class Pay2
    {
        [JsonPropertyName("pay_month")]
        public int PayMonth { get; set; }

        [JsonPropertyName("price_track")]
        public int PriceTrack { get; set; }

        [JsonPropertyName("price_album")]
        public int PriceAlbum { get; set; }

        [JsonPropertyName("pay_play")]
        public int PayPlay { get; set; }

        [JsonPropertyName("pay_down")]
        public int PayDown { get; set; }

        [JsonPropertyName("pay_status")]
        public int PayStatus { get; set; }

        [JsonPropertyName("time_free")]
        public int TimeFree { get; set; }
    }

    public class Action
    {
        [JsonPropertyName("switch")]
        public int Switch { get; set; }

        [JsonPropertyName("msgid")]
        public int Msgid { get; set; }

        [JsonPropertyName("alert")]
        public int Alert { get; set; }

        [JsonPropertyName("icons")]
        public int Icons { get; set; }

        [JsonPropertyName("msgshare")]
        public int MsgShare { get; set; }

        [JsonPropertyName("msgfav")]
        public int MsgFav { get; set; }

        [JsonPropertyName("msgdown")]
        public int MsgDown { get; set; }

        [JsonPropertyName("msgpay")]
        public int MsgPay { get; set; }

        [JsonPropertyName("switch2")]
        public int Switch2 { get; set; }

        [JsonPropertyName("icon2")]
        public int Icon2 { get; set; }
    }

    public class Ksong
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("mid")]
        public string Mid { get; set; }
    }

    public class Volume
    {
        [JsonPropertyName("gain")]
        public double Gain { get; set; }

        [JsonPropertyName("peak")]
        public double Peak { get; set; }

        [JsonPropertyName("lra")]
        public double Lra { get; set; }
    }

    public class TrackUrlResponse
    {
        [JsonPropertyName("data")]
        public Dictionary<string, string> Data { get; set; }

        [JsonPropertyName("result")]
        public int Result { get; set; }
    }
}
