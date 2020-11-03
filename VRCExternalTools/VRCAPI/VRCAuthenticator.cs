using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Windows;

namespace VRCExternalTools.VRCAPI
{
    class VRCAuthenticator
    {
        private String userName;
        private String password;
        private String apiKey;
        private String authToken;
        private bool twoFactor = false;

        public VRCAuthenticator(String name, String pass)
        {
            userName = name;
            password = pass;
        }

        public async Task<String> getApiKey()
        {
            Uri uri = new Uri(VRCAPIBase.api_base + "/config");
            using (var client = new HttpClient())
            {
                VRCAPIBase.ConfigDataReturn config = JsonSerializer.Deserialize<VRCAPIBase.ConfigDataReturn>(await client.GetAsync(uri).Result.Content.ReadAsStringAsync());

                return config.apiKey;
            }
        }

        public string getAuthToken(String name, String pass)
        {
            var cookieContainer = new CookieContainer();

            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            using (var client = new HttpClient(handler))
            {
                var uri = new Uri(VRCAPIBase.api_base + "/auth/user");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", name, pass))));
                client.DefaultRequestHeaders.Add("apiKey", apiKey);

                var response = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

                if (response.Contains("requiresTwoFactorAuth") && response.Contains("otp"))
                {
                    twoFactor = true;
                }

                IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
                foreach (Cookie cookie in responseCookies)
                {
                    if (cookie.Name == "auth")
                    {
                        return cookie.Value;
                    }
                }
            }

            return String.Empty;
        }

        public async Task<VRCAPI> loginAsync()
        { 
            apiKey = await getApiKey();
            authToken = getAuthToken(userName, password);
            if (authToken == String.Empty)
            {
                return null;
            }
            return new VRCAPI(apiKey, authToken);
        }

        public bool verifyTwoFactor(int pass)
        {
            Uri uri = new Uri(VRCAPIBase.api_base + "/auth/twofactorauth/totp/verify");
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            handler.CookieContainer.Add(new Cookie("auth", authToken, "/", "api.vrchat.cloud"));
            using (var client = new HttpClient(handler))
            {
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                
                request.Content = new StringContent(JsonSerializer.Serialize(new VRCAPIBase.TwoFactorRequest() { apiKey = apiKey, code = Convert.ToString(pass)}), Encoding.UTF8, "application/json");
                var result = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize < VRCAPIBase.TwoFactorAuthReturn > (result).verified;
            }
        }

        public bool isTwoAuthentication()
        {
            return twoFactor;
        }
    }
}
