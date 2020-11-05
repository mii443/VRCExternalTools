using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace VRCExternalTools.VRCAPI
{
    public class VRCAPI
    {
        public string apiKey;
        public string authToken;
        private HttpClientHandler handler = new HttpClientHandler();
        public VRCAPI(string key, string token)
        {
            apiKey = key;
            authToken = token;
            handler.CookieContainer = new CookieContainer();
            handler.CookieContainer.Add(new Cookie("auth", authToken, "/", "api.vrchat.cloud"));
        }

        public VRCAPIBase.UserDataReturn getUserConfig()
        {
            Uri uri = new Uri(VRCAPIBase.api_base + "/auth/user");
            using (var client = new HttpClient(handler, false))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<VRCAPIBase.UserDataReturn>(result);
            }
        }

        public VRCAPIBase.AvatarObject getAvatarById(string id)
        {
            StringBuilder urlParams = new StringBuilder("?");
            urlParams.Append("apiKey=" + apiKey);
            Uri uri = new Uri(VRCAPIBase.api_base + "/avatars/" + id + urlParams);
            using (var client = new HttpClient(handler, false))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<VRCAPIBase.AvatarObject>(result);
            }
        }

        public List<VRCAPIBase.AvatarObject> searchAvatars(string user = null, bool featured = false, string userId = null, int n = -1, int offset = -1, string order = null, string releaseStatus = null, string sort = null, string maxUnityVersion = null, string minUnityVersion = null, string maxAssetVersion = null, string minAssetVersion = null, string platform = null)
        {
            string urlParams = "?";
            if (user != null) { urlParams += "user=" + user + "&"; }
            urlParams += "featured=" + featured + "&";
            if (userId != null) { urlParams += "userId=" + userId + "&"; }
            if (n != -1) { urlParams += "n=" + n + "&"; }
            if (offset != -1) { urlParams += "offset=" + offset + "&"; }
            if (order != null) { urlParams += "order=" + order + "&"; }
            if (releaseStatus != null) { urlParams += "releaseStatus=" + releaseStatus + "&"; }
            if (sort != null) { urlParams += "sort=" + sort + "&"; }
            if (maxUnityVersion != null) { urlParams += "maxUnityVersion=" + maxUnityVersion + "&"; }
            if (minUnityVersion != null) { urlParams += "minUnityVersion=" + minUnityVersion + "&"; }
            if (maxAssetVersion != null) { urlParams += "maxAssetVersion=" + maxAssetVersion + "&"; }
            if (minAssetVersion != null) { urlParams += "minAssetVersion=" + minAssetVersion + "&"; }
            if (platform != null) { urlParams += "platform=" + platform + "&"; }

            urlParams += "apiKey=" + apiKey;

            Uri uri = new Uri(VRCAPIBase.api_base + "/avatars" + urlParams);
            using (var client = new HttpClient(handler, false))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<VRCAPIBase.AvatarObject>>(result);
            }
        }

        public List<VRCAPIBase.LimitedUserObject> getFriends(int n, bool offline, int offset)
        {
            using (var client = new HttpClient(handler, false))
            {
                Uri uri = new Uri(VRCAPIBase.api_base + "/auth/user/friends?apiKey=" + apiKey + "&offline=" + offline + "&offset=" + Convert.ToString(offset));
                //request.Content = new StringContent(JsonSerializer.Serialize(new VRCAPIBase.FriendsRequest() { apiKey = apiKey, n = n, offline = offline, offset = offset }), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<VRCAPIBase.LimitedUserObject>>(result);
            }
        }
    }
}
