using System.Collections.Generic;

namespace QQMusicApi
{
    public class RootObject
    {
        public int Result { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string Disstid { get; set; }
        public int Dir_Show { get; set; }
        public int Owndir { get; set; }
        public int Dirid { get; set; }
        public string Coveradurl { get; set; }
        public int Dissid { get; set; }
        public string Login { get; set; }
        public string Uin { get; set; }
        public string Encrypt_Uin { get; set; }
        public string Dissname { get; set; }
        public string Logo { get; set; }
        public string Pic_Mid { get; set; }
        public string Album_Pic_Mid { get; set; }
        public int Pic_Dpi { get; set; }
        public int IsAd { get; set; }
        public string Desc { get; set; }
        public long Ctime { get; set; }
        public long Mtime { get; set; }
        public string Headurl { get; set; }
        public string Ifpicurl { get; set; }
        public string Nick { get; set; }
        public string Nickname { get; set; }
        public int Type { get; set; }
        public int Singerid { get; set; }
        public string Singermid { get; set; }
        public int Isvip { get; set; }
        public int Isdj { get; set; }
        public int[] Tags { get; set; }
        public int Songnum { get; set; }
        public string Songids { get; set; }
        public string Songtypes { get; set; }
        public int Disstype { get; set; }
        public string Dir_Pic_Url2 { get; set; }
        public long Song_Update_Time { get; set; }
        public int Song_Update_Num { get; set; }
        public int Total_Song_Num { get; set; }
        public int Song_Begin { get; set; }
        public int Cur_Song_Num { get; set; }
        public Song[] Songlist { get; set; }
        public int Visitnum { get; set; }
        public int Cmtnum { get; set; }
        public int Buynum { get; set; }
        public string Scoreavage { get; set; }
        public int Scoreusercount { get; set; }
    }

    public class Song
    {
        public string Albumdesc { get; set; }
        public int Albumid { get; set; }
        public string Albummid { get; set; }
        public string Albumname { get; set; }
        public int Alertid { get; set; }
        public int BelongCD { get; set; }
        public int CdIdx { get; set; }
        public int Interval { get; set; }
        public int Isonly { get; set; }
        public string Label { get; set; }
        public int Msgid { get; set; }
        public Pay Pay { get; set; }
        public Preview Preview { get; set; }
        public int Rate { get; set; }
        public Singer[] Singer { get; set; }
        public int Size128 { get; set; }
        public int Size320 { get; set; }
        public int Size5_1 { get; set; }
        public int Sizeape { get; set; }
        public int Sizeflac { get; set; }
        public int Sizeogg { get; set; }
        public int Songid { get; set; }
        public string Songmid { get; set; }
        public string Songname { get; set; }
        public string Songorig { get; set; }
        public int Songtype { get; set; }
        public string StrMediaMid { get; set; }
        public int Stream { get; set; }
        public int Switch { get; set; }
        public int Type { get; set; }
        public string Vid { get; set; }
    }

    public class Pay
    {
        public int Payalbum { get; set; }
        public int Payalbumprice { get; set; }
        public int Paydownload { get; set; }
        public int Payinfo { get; set; }
        public int Payplay { get; set; }
        public int Paytrackmouth { get; set; }
        public int Paytrackprice { get; set; }
        public int Timefree { get; set; }
    }

    public class Preview
    {
        public int Trybegin { get; set; }
        public int Tryend { get; set; }
        public int Trysize { get; set; }
    }

    public class Singer
    {
        public int Id { get; set; }
        public string Mid { get; set; }
        public string Name { get; set; }
    }
}
