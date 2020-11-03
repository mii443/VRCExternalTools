using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.RightsManagement;

namespace VRCExternalTools.VRCAPI
{
    class VRCAPIBase
    {
        public static readonly String api_base = "https://api.vrchat.cloud/api/1";

        public class AvatarObject
        {
            public String id { get; set; }
            public String name { get; set; }
            public String description { get; set; }
            public String authorId { get; set; }
            public String authorName { get; set; }
        }
        
        public class PastDisplayNameObject
        {
            public String displayName { get; set; }
            public String updated_at { get; set; }
        }

        public class CurrentUserObject
        {
            public String username { get; set; }
            public String displayName { get; set; }
            public PastDisplayNameObject[] pastDisplayNames { get; set; }
            public String id { get; set; }
            public String bio { get; set; }
            public String[] bioLinks { get; set; }
            public String email { get; set; }
            public bool emailVerified { get; set; }
            public bool hasEmail { get; set; }
            public bool hasPendingEmail { get; set; }
            public String obfuscatedEmail { get; set; }
            public String obfuscatedPendingEmail { get; set; }
            public String steamId { get; set; }
            public String[] steamDetails { get; set; }
            public String oculusId { get; set; }
            public int acceptedTOSVersion { get; set; }
            public bool hasBirthday { get; set; }
            public String[] friends { get; set; }
            public String[] onlineFriends { get; set; }
            public String[] activeFriends { get; set; }
            public String[] offlineFriends { get; set; }
            public String[] friendGroupNames { get; set; }
            public String state { get; set; }
            public String status { get; set; }


        }

        public class WorldUnityPackageObject
        {
            public String id { get; set; }
            public String platform { get; set; }
            public String assetUrl { get; set; }
            public String unityVersion { get; set; }
            public int unitySortNumber { get; set; }
            public int assetVersion { get; set; }
            public String created_at { get; set; }
            public String assetUrlObject { get; set; }
            public String pluginUrl { get; set; }
            public String pluginUrlObject { get; set; }
        }

        public class LimitedWorldObject
        {
            public String name { get; set; }
            public String id { get; set; }
            public String authorName { get; set; }
            public int authorId { get; set; }
            public String[] tags { get; set; }
            public String created_at { get; set; }
            public String updated_at { get; set; }
            public String releaseStatus { get; set; }
            public int visits { get; set; }
            public int occupants { get; set; }
            public int capacity { get; set; }
            public int favorites { get; set; }
            public int popularity { get; set; }
            public String imageUrl { get; set; }
            public String thumbnailImageUrl { get; set; }
            public String organization { get; set; }
            public int heat { get; set; }
            public String publicationDate { get; set; }
            public String labsPublicationDate { get; set; }
            public WorldUnityPackageObject[] unityPackages { get; set; }
        }

        public class LimitedUserObject
        {
            public String username { get; set; }
            public String displayName { get; set; }
            public String id { get; set; }
            public String bio { get; set; }
            public String statys { get; set; }
            public String currentAvatarImageUrl { get; set; }
            public String currentAvatarThumbnailImageUrl { get; set; }
            public String last_platform { get; set; }
            public String[] tags { get; set; }
            public String developerType { get; set; }
            public bool isFriend { get; set; }
            //public LimitedWorldObject location { get; set; }
        }

        public class FriendsRequest
        {
            public int offset { get; set; }
            public int n { get; set; }
            public bool offline { get; set; }
            public String apiKey { get; set; }
        }

        public class TwoFactorRequest
        {
            public String apiKey { get; set; }
            public String code { get; set; }
        }

        public class TwoFactorAuthReturn
        {
            public bool verified { get; set; }
        }

        public class DisplayNameObject
        {
            public String displayName { get; set; }
            public String updated_at { get; set; }
        }

        public class UserDataReturn
        {
            public String id { get; set; }
            public String username { get; set; }
            public String displayName { get; set; }
            public String userIcon { get; set; }
            public String bio { get; set; }
            public String[] bioLinks { get; set; }
            public DisplayNameObject[] pastDisplayNames { get; set; }
            public bool hasEmail { get; set; }
            public bool hasPendingEmail { get; set; }
            public String email { get; set; }
            public String obfuscatedEmail { get; set; }
            public String obfuscatedPendingEmail { get; set; }
            public bool emailVerified { get; set; }
            public bool hasBirthday { get; set; }
            public bool unsubscribe { get; set; }
            public String[] friends { get; set; }
            public String[] friendGroupNames { get; set; }
            public String currentAvatarImageUrl { get; set; }
            public String currentAvatarThumbnailImageUrl { get; set; }
            public String fallbackAvatar { get; set; }
            public String currentAvatar { get; set; }
            public String currentAvatarAssetUrl { get; set; }
            public String accountDeletionDate { get; set; }
            public int acceptedTOSVersion { get; set; }
            public String steamId { get; set; }
            public String oculusId { get; set; }
            public bool hasLoggedInFromClient { get; set; }
            public String homeLocation { get; set; }
            public bool twoFactorAuthEnabled { get; set; }
            public String status { get; set; }
            public String statusDescription { get; set; }
            public String state { get; set; }
            public String[] tags { get; set; }
            public String developerType { get; set; }
            public String last_login { get; set; }
            public String last_platform { get; set; }
            public bool allowAvatarCopying { get; set; }
            public bool isFriend { get; set; }
            public String friendKey { get; set; }
            public String[] onlineFriends { get; set; }
            public String[] activeFriends { get; set; }
            public String[] offlineFriends { get; set; }

        }


        public class ConfigDataReturn
        {
            public String messageOfTheDay { get; set; }
            public String timeOutWorldId { get; set; }
            public String gearDemoRoomId { get; set; }
            public String releaseServerVersionStandalone { get; set; }
            public String downloadLinkWindows { get; set; }
            public String releaseAppVersionStandalone { get; set; }
            public String devAppVersionStandalone { get; set; }
            public String devServerVersionStandalone { get; set; }
            public String devDownloadLinkWindows { get; set; }
            public int currentTOSVersiona { get; set; }
            public String releaseSdkUrl { get; set; }
            public String releaseSdkVersion { get; set; }
            public String devSdkUrl { get; set; }
            public String devSdkVersion { get; set; }
            public String[] whiteListedAssetUrls { get; set; }
            public String clientApiKey { get; set; }
            public String viveWindowsUrl { get; set; }
            public String sdkUnityVersion { get; set; }
            public String hubWorldId { get; set; }
            public String homeWorldId { get; set; }
            public String tutorialWorldId { get; set; }
            public bool disableEventStream { get; set; }
            public bool disableAvatarGating { get; set; }
            public bool disableFeedbackGating { get; set; }
            public bool disableRegistration { get; set; }
            public String plugin { get; set; }
            public String sdkNotAllowedToPublishMessage { get; set; }
            public String sdkDeveloperFaqUrl { get; set; }
            public String sdkDiscordUrl { get; set; }
            public String notAllowedToSelectAvatarInPrivateWorldMessage { get; set; }
            public int userVerificationTimeout { get; set; }
            public int userUpdatePeriod { get; set; }
            public int userVerificationDelay { get; set; }
            public int userVerificationRetry { get; set; }
            public int worldUpdatePeriod { get; set; }
            public int moderationQueryPeriod { get; set; }
            public String defaultAvatar { get; set; }
            // public String dynamicWorldRows { get; set; } // Array of DynamicWorldRows WIP
            public String address { get; set; }
            public String contactEmail { get; set; }
            public String supportEmail { get; set; }
            public String jobsEmail { get; set; }
            public String copyrightEmail { get; set; }
            public String moderationEmail { get; set; }
            public bool disableEmail { get; set; }
            public String appName { get; set; }
            public String serverName { get; set; }
            public String deploymentGroup { get; set; }
            public String buildVersionTag { get; set; }
            public String apiKey { get; set; }
        }
    }
}
