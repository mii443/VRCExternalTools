using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.RightsManagement;
using Newtonsoft.Json;

namespace VRCExternalTools.VRCAPI
{
    public class VRCAPIBase
    {
        public static readonly string api_base = "https://api.vrchat.cloud/api/1";

        public class AvatarObject
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string authorId { get; set; }
            public string authorName { get; set; }
            public string[] tags { get; set; }
            public int version { get; set; }
            public bool featured { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string releaseStatus { get; set; }
            public string assetUrl { get; set; }
            public string assetVersion { get; set; }
            public string platform { get; set; }
            public string imageUrl { get; set; }
            public string thumbnailImageUrl { get; set; }
            public string unityVersion { get; set; }
            public string unityPackageUrl { get; set; }
        }
        
        public class PastDisplayNameObject
        {
            public string displayName { get; set; }
            public string updated_at { get; set; }
        }

        public class CurrentUserObject
        {
            public string username { get; set; }
            public string displayName { get; set; }
            [JsonProperty(Required = Required.AllowNull)]
            public PastDisplayNameObject[] pastDisplayNames { get; set; }
            public string id { get; set; }
            public string bio { get; set; }
            public string[] bioLinks { get; set; }
            public string email { get; set; }
            public bool emailVerified { get; set; }
            public bool hasEmail { get; set; }
            public bool hasPendingEmail { get; set; }
            public string obfuscatedEmail { get; set; }
            public string obfuscatedPendingEmail { get; set; }
            public string steamId { get; set; }
            public string[] steamDetails { get; set; }
            public string oculusId { get; set; }
            public int acceptedTOSVersion { get; set; }
            public bool hasBirthday { get; set; }
            public string[] friends { get; set; }
            public string[] onlineFriends { get; set; }
            public string[] activeFriends { get; set; }
            public string[] offlineFriends { get; set; }
            public string[] friendGroupNames { get; set; }
            public string state { get; set; }
            public string status { get; set; }


        }

        public class WorldUnityPackageObject
        {
            public string id { get; set; }
            public string platform { get; set; }
            public string assetUrl { get; set; }
            public string unityVersion { get; set; }
            public int unitySortNumber { get; set; }
            public int assetVersion { get; set; }
            public string created_at { get; set; }
            public string assetUrlObject { get; set; }
            public string pluginUrl { get; set; }
            public string pluginUrlObject { get; set; }
        }

        public class LimitedWorldObject
        {
            public string name { get; set; }
            public string id { get; set; }
            public string authorName { get; set; }
            public int authorId { get; set; }
            public string[] tags { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string releaseStatus { get; set; }
            public int visits { get; set; }
            public int occupants { get; set; }
            public int capacity { get; set; }
            public int favorites { get; set; }
            public int popularity { get; set; }
            public string imageUrl { get; set; }
            public string thumbnailImageUrl { get; set; }
            public string organization { get; set; }
            public int heat { get; set; }
            public string publicationDate { get; set; }
            public string labsPublicationDate { get; set; }
            public WorldUnityPackageObject[] unityPackages { get; set; }
        }

        public class LimitedUserObject
        {
            public string username { get; set; }
            public string displayName { get; set; }
            public string id { get; set; }
            public string bio { get; set; }
            public string statys { get; set; }
            public string currentAvatarImageUrl { get; set; }
            public string currentAvatarThumbnailImageUrl { get; set; }
            public string last_platform { get; set; }
            public string[] tags { get; set; }
            public string developerType { get; set; }
            public bool isFriend { get; set; }

            //[JsonProperty(Required = Required.AllowNull)]
           // public LimitedWorldObject location { get; set; }
        }

        public class FriendsRequest
        {
            public int offset { get; set; }
            public int n { get; set; }
            public bool offline { get; set; }
            public string apiKey { get; set; }
        }

        public class TwoFactorRequest
        {
            public string apiKey { get; set; }
            public string code { get; set; }
        }

        public class TwoFactorAuthReturn
        {
            public bool verified { get; set; }
        }

        public class DisplayNameObject
        {
            public string displayName { get; set; }
            public string updated_at { get; set; }
        }

        public class UserDataReturn
        {
            public string id { get; set; }
            public string username { get; set; }
            public string displayName { get; set; }
            public string userIcon { get; set; }
            public string bio { get; set; }
            public string[] bioLinks { get; set; }
            public DisplayNameObject[] pastDisplayNames { get; set; }
            public bool hasEmail { get; set; }
            public bool hasPendingEmail { get; set; }
            public string email { get; set; }
            public string obfuscatedEmail { get; set; }
            public string obfuscatedPendingEmail { get; set; }
            public bool emailVerified { get; set; }
            public bool hasBirthday { get; set; }
            public bool unsubscribe { get; set; }
            public string[] friends { get; set; }
            public string[] friendGroupNames { get; set; }
            public string currentAvatarImageUrl { get; set; }
            public string currentAvatarThumbnailImageUrl { get; set; }
            public string fallbackAvatar { get; set; }
            public string currentAvatar { get; set; }
            public string currentAvatarAssetUrl { get; set; }
            public string accountDeletionDate { get; set; }
            public int acceptedTOSVersion { get; set; }
            public string steamId { get; set; }
            public string oculusId { get; set; }
            public bool hasLoggedInFromClient { get; set; }
            public string homeLocation { get; set; }
            public bool twoFactorAuthEnabled { get; set; }
            public string status { get; set; }
            public string statusDescription { get; set; }
            public string state { get; set; }
            public string[] tags { get; set; }
            public string developerType { get; set; }
            public string last_login { get; set; }
            public string last_platform { get; set; }
            public bool allowAvatarCopying { get; set; }
            public bool isFriend { get; set; }
            public string friendKey { get; set; }
            public string[] onlineFriends { get; set; }
            public string[] activeFriends { get; set; }
            public string[] offlineFriends { get; set; }

        }


        public class ConfigDataReturn
        {
            public string messageOfTheDay { get; set; }
            public string timeOutWorldId { get; set; }
            public string gearDemoRoomId { get; set; }
            public string releaseServerVersionStandalone { get; set; }
            public string downloadLinkWindows { get; set; }
            public string releaseAppVersionStandalone { get; set; }
            public string devAppVersionStandalone { get; set; }
            public string devServerVersionStandalone { get; set; }
            public string devDownloadLinkWindows { get; set; }
            public int currentTOSVersiona { get; set; }
            public string releaseSdkUrl { get; set; }
            public string releaseSdkVersion { get; set; }
            public string devSdkUrl { get; set; }
            public string devSdkVersion { get; set; }
            public string[] whiteListedAssetUrls { get; set; }
            public string clientApiKey { get; set; }
            public string viveWindowsUrl { get; set; }
            public string sdkUnityVersion { get; set; }
            public string hubWorldId { get; set; }
            public string homeWorldId { get; set; }
            public string tutorialWorldId { get; set; }
            public bool disableEventStream { get; set; }
            public bool disableAvatarGating { get; set; }
            public bool disableFeedbackGating { get; set; }
            public bool disableRegistration { get; set; }
            public string plugin { get; set; }
            public string sdkNotAllowedToPublishMessage { get; set; }
            public string sdkDeveloperFaqUrl { get; set; }
            public string sdkDiscordUrl { get; set; }
            public string notAllowedToSelectAvatarInPrivateWorldMessage { get; set; }
            public int userVerificationTimeout { get; set; }
            public int userUpdatePeriod { get; set; }
            public int userVerificationDelay { get; set; }
            public int userVerificationRetry { get; set; }
            public int worldUpdatePeriod { get; set; }
            public int moderationQueryPeriod { get; set; }
            public string defaultAvatar { get; set; }
            // public String dynamicWorldRows { get; set; } // Array of DynamicWorldRows WIP
            public string address { get; set; }
            public string contactEmail { get; set; }
            public string supportEmail { get; set; }
            public string jobsEmail { get; set; }
            public string copyrightEmail { get; set; }
            public string moderationEmail { get; set; }
            public bool disableEmail { get; set; }
            public string appName { get; set; }
            public string serverName { get; set; }
            public string deploymentGroup { get; set; }
            public string buildVersionTag { get; set; }
            public string apiKey { get; set; }
        }
    }
}
