using System.Collections.Generic;

namespace NeteaseCloudMusicApi
{
    public class ArtistsItem
    {
        public long id { get; set; }

        public string name { get; set; }

        public string picUrl;

        public List<string> @alias;

        public long albumSize;

        public long picId;

        public string fansGroup;

        public string img1v1Url;

        public long img1v1;

        public string trans;
    }

    public class Artist
    {

        public long id;

        public string name;

        public string picUrl;

        public List<string> @alias;

        public long albumSize;

        public long picId;

        public string fansGroup;

        public string img1v1Url;

        public long img1v1;

        public string trans;
    }

    public class Album
    {

        public long id;

        public string name;

        public Artist artist;

        public long publishTime;

        public long size;

        public long copyrightId;

        public long status;

        public long picId;

        public long mark;
    }

    public class SongsItem
    {

        public long id { get; set; }

        public string name { get; set; }

        public List<ArtistsItem> artists { get; set; }

        public Album album;

        public long duration;

        public long copyrightId;

        public long status;

        public List<string> @alias;

        public long rtype;

        public long ftype;

        public long mvid;

        public long fee;

        public string rUrl;

        public long mark;
    }

    public class Result
    {

        public List<SongsItem> songs { get; set; }

        public bool hasMore;

        public long songCount;
    }

    public class yunSearchSong
    {

        public Result result { get; set; }

        public long code;
    }

    public class FreeTrialInfo
    {

        public long start;

        public long end;
    }

    public class FreeTrialPrivilege
    {

        public bool resConsumable;

        public bool userConsumable;

        public string listenType;

        public string cannotListenReason;
    }

    public class FreeTimeTrialPrivilege
    {

        public bool resConsumable;

        public bool userConsumable;

        public long type;

        public long remalongime;
    }

    public class DataItem
    {

        public long id;

        public string url { get; set; }

        public long br;

        public long size;

        public string md5;

        public long code;

        public long expi;

        public string type;

        public double gain;

        public double peak;

        public long fee;

        public string uf;

        public long payed;

        public long flag;

        public bool canExtend;

        public FreeTrialInfo freeTrialInfo;

        public string level;

        public string encodeType;

        public FreeTrialPrivilege freeTrialPrivilege;

        public FreeTimeTrialPrivilege freeTimeTrialPrivilege;

        public long urlSource;

        public long rightSource;

        public string podcastCtrp;

        public string effectTypes;

        public long time;
    }

    public class musicURL
    {

        public List<DataItem> data { get; set; }

        public long code { get; set; }
    }

    public class ArItem
    {

        public long id;

        public string name;

        public List<string> tns;

        public List<string> @alias;
    }

    public class Al
    {

        public long id;

        public string name;

        public string picUrl;

        public List<string> tns;

        public long pic;
    }

    public class H
    {

        public long br;

        public long fid;

        public long size;

        public long vd;

        public long sr;
    }

    public class M
    {

        public long br;

        public long fid;

        public long size;

        public long vd;

        public long sr;
    }

    public class L
    {

        public long br;

        public long fid;

        public long size;

        public long vd;

        public long sr;
    }

    public class SongsItems
    {

        public string name { get; set; }

        public long id { get; set; }

        public long pst;

        public long t;

        public List<ArItem> ar;

        public List<string> alia;

        public long pop;

        public long st;

        public string rt;

        public long fee;

        public long v;

        public string crbt;

        public string cf;

        public Al al;

        public long dt;

        public H h;

        public M m;

        public L l;

        public string sq;

        public string hr;

        public string a;

        public string cd;

        public long no;

        public string rtUrl;

        public long ftype;

        public List<string> rtUrls;

        public long djId;

        public long copyright;

        public long s_id;

        public long mark;

        public long originCoverType;

        public string originSongSimpleData;

        public string tagPicList;

        public bool resourceState;

        public long version;

        public string songJumpInfo;

        public string entertainmentTags;

        public string awardTags;

        public long single;

        public bool noCopyrightRcmd;

        public long mst;

        public long cp;

        public long rtype;

        public string rurl;

        public long mv;

        public long publishTime;
    }

    public class FreeTrial
    {

        public bool resConsumable;

        public bool userConsumable;

        public string listenType;
    }

    public class ChargeInfoListItem
    {

        public long rate;

        public string chargeUrl;

        public string chargeMessage;

        public long chargeType;
    }

    public class PrivilegesItem
    {

        public long id;

        public long fee;

        public long payed;

        public long st;

        public long pl;

        public long dl;

        public long sp;

        public long cp;

        public long subp;

        public bool cs;

        public long maxbr;

        public long fl;

        public bool toast;

        public long flag;

        public bool preSell;

        public long playMaxbr;

        public long downloadMaxbr;

        public string maxBrLevel;

        public string playMaxBrLevel;

        public string downloadMaxBrLevel;

        public string plLevel;

        public string dlLevel;

        public string flLevel;

        public string rscl;

        public FreeTrial freeTrialPrivilege;

        public List<ChargeInfoListItem> chargeInfoList;
    }

    public class GeDan
    {

        public List<SongsItems> songs { get; set; }

        public List<PrivilegesItem> privileges;

        public long code;
    }

    public class Creator
    {
        /// <summary>
        /// 淋雨丶伞
        /// </summary>
        public string nickname;

        public long userId;

        public long userType;

        public string avatarUrl;

        public long authStatus;

        public string expertTags;

        public string experts;
    }

    public class ArtistsItems
    {

        public string name;

        public long id;

        public long picId;

        public long img1v1Id;

        public string briefDesc;

        public string picUrl;

        public string img1v1Url;

        public long albumSize;

        public List<string> @alias;

        public string trans;

        public long musicSize;
    }

    public class Artists
    {

        public string name;

        public long id;

        public long picId;

        public long img1v1Id;

        public string briefDesc;

        public string picUrl;

        public string img1v1Url;

        public long albumSize;

        public List<string> @alias;

        public string trans;

        public long musicSize;
    }

    public class ArtistsItemss
    {

        public string name;

        public long id;

        public long picId;

        public long img1v1Id;

        public string briefDesc;

        public string picUrl;

        public string img1v1Url;

        public long albumSize;

        public List<string> @alias;

        public string trans;

        public long musicSize;
    }

    public class Albums
    {

        public string name;

        public long id;

        public string idStr;
        /// <summary>
        /// 专辑
        /// </summary>
        public string type;

        public long size;

        public long picId;

        public string blurPicUrl;

        public long companyId;

        public long pic;

        public string picUrl;

        public long publishTime;

        public string description;

        public string tags;

        public string company;

        public string briefDesc;

        public Artist artist;

        public List<string> songs;

        public List<string> @alias;

        public long status;

        public long copyrightId;

        public string commentThreadId;

        public List<ArtistsItemss> artists;
    }

    public class BMusic
    {

        public string name;

        public long id;

        public long size;

        public string extension;

        public long sr;

        public long dfsId;

        public long bitrate;

        public long playTime;

        public long volumeDelta;
    }

    public class HMusic
    {

        public string name;

        public long id;

        public long size;

        public string extension;

        public long sr;

        public long dfsId;

        public long bitrate;

        public long playTime;

        public long volumeDelta;
    }

    public class MMusic
    {

        public string name;

        public long id;

        public long size;

        public string extension;

        public long sr;

        public long dfsId;

        public long bitrate;

        public long playTime;

        public long volumeDelta;
    }

    public class LMusic
    {

        public string name;

        public long id;

        public long size;

        public string extension;

        public long sr;

        public long dfsId;

        public long bitrate;

        public long playTime;

        public long volumeDelta;
    }

    public class Track
    {

        public string name;

        public long id;

        public long position;

        public List<string> @alias;

        public long status;

        public long fee;

        public long copyrightId;

        public string disc;

        public long no;

        public List<ArtistsItemss> artists;

        public Albums album;

        public bool starred;

        public long popularity;

        public long score;

        public long starredNum;

        public long duration;

        public long playedNum;

        public long dayPlays;

        public long hearTime;

        public string ringtone;

        public string crbt;

        public string audition;

        public string copyFrom;

        public string commentThreadId;

        public string rtUrl;

        public long ftype;

        public List<string> rtUrls;

        public long copyright;

        public long rtype;

        public string rurl;

        public BMusic bMusic;

        public string mp3Url;

        public long mvid;

        public HMusic hMusic;

        public MMusic mMusic;

        public LMusic lMusic;
    }

    public class PlaylistsItem
    {

        public long id { get; set; }

        public string name;

        public string coverImgUrl;

        public Creator creator;

        public bool subscribed;

        public long trackCount;

        public long userId;

        public long playCount;

        public long bookCount;

        public long specialType;

        public List<string> officialTags;

        public string action;

        public string actionType;

        public string recommendText;

        public string score;

        public string description;

        public bool highQuality;

        public Track track;

        public string alg;
    }

    public class Results
    {

        public List<PlaylistsItem> playlists { get; set; }

        public bool hasMore;

        public List<string> hlWords;

        public long playlistCount;

        public string searchQcReminder;
    }

    public class SearchGedan
    {

        public Results result { get; set; }

        public long code;
    }

    public class Data
    {

        public int code;

        public string unikey { get; set; }
    }

    public class LoginKey
    {

        public Data data { get; set; }

        public int code;
    }
    
    public class QQLogin
    {
        public int status;
    }

    public class Datas
    {

        public string qrurl;

        public string qrimg { get; set; }
    }

    public class LoginImg
    {

        public int code;

        public Datas data { get; set; }
    }

    public class Status1
    {

        public long code { get; set; }

        public string message { get; set; }

        public string cookie { get; set; }
    }

    public class SubscribersItem
    {

        public string defaultAvatar;

        public int province;

        public int authStatus;

        public string followed;

        public string avatarUrl;

        public int accountStatus;

        public int gender;

        public int city;

        public int birthday;

        public long userId;

        public int userType;

        public string nickname;

        public string signature;

        public string description;

        public string detailDescription;

        public int avatarImgId;

        public int backgroundImgId;

        public string backgroundUrl;

        public int authority;

        public string mutual;

        public string expertTags;

        public string experts;

        public int djStatus;

        public int vipType;

        public string remarkName;

        public int authenticationTypes;

        public string avatarDetail;

        public string avatarImgIdStr;

        public string backgroundImgIdStr;

        public string anchor;

        public string avatarImgId_str;
    }

    public class AvatarDetail
    {

        public int userType;

        public int identityLevel;

        public string identityIconUrl;
    }

    public class Creators
    {

        public string defaultAvatar;

        public int province;

        public int authStatus;

        public string followed;

        public string avatarUrl;

        public int accountStatus;

        public int gender;

        public int city;

        public int birthday;

        public long userId;

        public int userType;

        public string nickname;

        public string signature;

        public string description;

        public string detailDescription;

        public int avatarImgId;

        public int backgroundImgId;

        public string backgroundUrl;

        public int authority;

        public string mutual;

        public string expertTags;

        public string experts;

        public int djStatus;

        public int vipType;

        public string remarkName;

        public int authenticationTypes;

        public AvatarDetail avatarDetail;

        public string avatarImgIdStr;

        public string backgroundImgIdStr;

        public string anchor;

        public string avatarImgId_str;
    }

    public class Sq
    {

        public int br;

        public int fid;

        public int size;

        public int vd;

        public int sr;
    }

    public class TracksItem
    {

        public string name;

        public int id;

        public int pst;

        public int t;

        public List<ArItem> ar;

        public List<string> alia;

        public int pop;

        public int st;

        public string rt;

        public int fee;

        public int v;

        public string crbt;

        public string cf;

        public Al al;

        public int dt;

        public H h;

        public M m;

        public L l;

        public Sq sq;

        public string hr;

        public string a;

        public string cd;

        public int no;

        public string rtUrl;

        public int ftype;

        public List<string> rtUrls;

        public int djId;

        public int copyright;

        public int s_id;

        public int mark;

        public int originCoverType;


        public string originSongSimpleData;

        public string tagPicList;

        public bool resourceState;

        public int version;

        public string songJumpInfo;

        public string entertainmentTags;

        public int single;

        public string noCopyrightRcmd;

        public string rurl;

        public int mst;

        public int cp;

        public int mv;

        public int rtype;

        public long publishTime;
    }

    public class TrackIdsItem
    {

        public int id;

        public int v;

        public int t;

        public int at;

        public string alg;

        public int uid;

        public string rcmdReason;

        public string sc;

        public string f;

        public string sr;
    }

    public class Playlist
    {

        public long id;

        public string name { get; set; }

        public long coverImgId;

        public string coverImgUrl { get; set; }

        public string coverImgId_str;

        public int adType;

        public long userId;

        public int createTime;

        public int status;

        public bool opRecommend;

        public bool highQuality;

        public bool newImported;

        public int updateTime;

        public int trackCount { get; set; }

        public int specialType;

        public int privacy;

        public int trackUpdateTime;

        public string commentThreadId;

        public int playCount;

        public long trackNumberUpdateTime;

        public int subscribedCount;

        public int cloudTrackCount;

        public bool ordered;

        public string description;

        public List<string> tags;

        public string updateFrequency;

        public int backgroundCoverId;

        public string backgroundCoverUrl;

        public int titleImage;

        public string titleImageUrl;

        public string englishTitle;

        public string officialPlaylistType;

        public bool copied;

        public string relateResType;

        public List<SubscribersItem> subscribers;

        public bool subscribed;

        public Creators creator;

        public List<TracksItem> tracks;

        public string videoIds;

        public string videos;

        public List<TrackIdsItem> trackIds;

        public string bannedTrackIds;

        public string mvResourceInfos;

        public int shareCount;

        public int commentCount;

        public string remixVideo;

        public string sharedUsers;

        public string historySharedUsers;

        public string gradeStatus;

        public string score;

        public string algTags;
    }

    public class FreeTrialPrivileges
    {

        public string resConsumable;

        public string userConsumable;

        public string listenType;
    }

    public class ChargeInfoListItems
    {

        public int rate;

        public string chargeUrl;

        public string chargeMessage;

        public int chargeType;
    }

    public class PrivilegesItems
    {

        public int id;

        public int fee;

        public int payed;

        public int realPayed;

        public int st;

        public int pl;

        public int dl;

        public int sp;

        public int cp;

        public int subp;

        public string cs;

        public int maxbr;

        public int fl;

        public string pc;

        public string toast;

        public int flag;

        public string paidBigBang;

        public string preSell;

        public int playMaxbr;

        public int downloadMaxbr;

        public string maxBrLevel;

        public string playMaxBrLevel;

        public string downloadMaxBrLevel;

        public string plLevel;

        public string dlLevel;

        public string flLevel;

        public string rscl;

        public FreeTrialPrivileges freeTrialPrivilege;

        public List<ChargeInfoListItems> chargeInfoList;
    }

    public class GedanDetail
    {

        public long code;

        public string relatedVideos;

        public Playlist playlist { get; set; }

        public string urls;

        public List<PrivilegesItems> privileges;

        public string sharedPrivilege;

        public string resEntrance;

        public string fromUsers;

        public int fromUserCount;

        public string songFromUsers;
    }

    public class MusicCheck
    {

        public bool success{ get; set; }

        public string message{ get; set; }
    }

    public class ArItem1
    {

        public int id;

        public string name;

        public List<string> tns;

        public List<string> @alias;
    }

    public class Al1
    {

        public int id;

        public string name;

        public string picUrl { get; set; }

        public List<string> tns;

        public string pic_str;

        public long pic;
    }

    public class H1
    {

        public int br;

        public int fid;

        public int size;

        public int vd;

        public int sr;
    }

    public class M1
    {

        public int br;

        public int fid;

        public int size;

        public int vd;

        public int sr;
    }

    public class L1
    {

        public int br;

        public int fid;

        public int size;

        public int vd;

        public int sr;
    }

    public class Sq1
    {

        public int br;

        public int fid;

        public int size;

        public int vd;

        public int sr;
    }

    public class SongsItem1
    {

        public string name { get; set; }

        public long id;

        public int pst;

        public int t;

        public List<ArItem1> ar;

        public List<string> alia;

        public int pop;

        public int st;

        public string rt;

        public int fee;

        public int v;

        public string crbt;

        public string cf;

        public Al1 al { get; set; }

        public int dt;

        public H1 h;

        public M1 m;

        public L1 l;

        public Sq1 sq;


        public string hr;

        public string a;

        public string cd;

        public int no;

        public string rtUrl;

        public int ftype;

        public List<string> rtUrls;

        public long djId;

        public long copyright;

        public long s_id;

        public long mark;

        public int originCoverType;

        public string originSongSimpleData;

        public string tagPicList;

        public string resourceState;

        public int version;

        public string songJumpInfo;

        public string entertainmentTags;

        public string awardTags;

        public int single;

        public string noCopyrightRcmd;

        public int mv;

        public int mst;

        public int cp;

        public int rtype;

        public string rurl;

        public long publishTime;
    }

    public class FreeTrialPrivilege1
    {

        public string resConsumable;

        public string userConsumable;

        public string listenType;
    }

    public class ChargeInfoListItem1
    {

        public long rate;

        public string chargeUrl;

        public string chargeMessage;

        public int chargeType;
    }

    public class PrivilegesItem1
    {

        public long id;

        public int fee;

        public int payed;

        public int st;

        public int pl;

        public int dl;

        public int sp;

        public int cp;

        public int subp;

        public string cs;

        public int maxbr;

        public int fl;

        public string toast;

        public int flag;

        public string preSell;

        public int playMaxbr;

        public int downloadMaxbr;

        public string maxBrLevel;

        public string playMaxBrLevel;

        public string downloadMaxBrLevel;

        public string plLevel;

        public string dlLevel;

        public string flLevel;

        public string rscl;

        public FreeTrialPrivilege1 freeTrialPrivilege;

        public List<ChargeInfoListItem1> chargeInfoList;
    }

    public class MusicDetail
    {

        public List<SongsItem1> songs { get; set; }

        public List<PrivilegesItem1> privileges;

        public int code;
    }
}