using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.AspNet;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace ML.WebUI.Code
{
    public class VKontakteAuthenticationClient : IAuthenticationClient
    {
        public string appId;
        public string appSecret;


        public VKontakteAuthenticationClient(string appId, string appSecret)
        {
            this.appId = appId;
            this.appSecret = appSecret;
        }

        public VKontakteAuthenticationClient()
        {
            // TODO: Complete member initialization
        }

        string IAuthenticationClient.ProviderName
        {
            get { return "vkontakte"; }
        }

        private string redirectUri;

        void IAuthenticationClient.RequestAuthentication(HttpContextBase context, Uri returnUrl)
        {
            var APP_ID = this.appId;
            this.redirectUri = context.Server.UrlEncode(returnUrl.ToString());
            var address = String.Format(
                    "https://oauth.vk.com/authorize?client_id={0}&redirect_uri={1}&scope=friends,status,wall,offline,groups,photos&response_type=code",
                    APP_ID, this.redirectUri
                );

            HttpContext.Current.Response.Redirect(address, false);
        }

        class AccessToken
        {
            public string access_token = null;
            public string user_id = null;
            //public static HttpContextBase context1 = null;
        }

        public class UserData
        {
            public string uid = null;
            public string first_name = null;
            public string last_name = null;
            public string photo_100 = null;
            public string status = null;
            public string accesstoken = null;
        }

        class UsersData
        {
            public UserData[] response = null;
        }

        AuthenticationResult IAuthenticationClient.VerifyAuthentication(HttpContextBase context)
        {

            try
            {
                string code = context.Request["code"];

                var address = String.Format(
                        "https://oauth.vk.com/access_token?client_id={0}&client_secret={1}&code={2}&redirect_uri={3}",
                        this.appId, this.appSecret, code, this.redirectUri);

                var response = VKontakteAuthenticationClient.Load(address);
                var accessToken = VKontakteAuthenticationClient.DeserializeJson<AccessToken>(response);
                address = String.Format(
                        "https://api.vk.com/method/users.get?uids={0}&fields=photo_50,status",
                        accessToken.user_id);

                response = VKontakteAuthenticationClient.Load(address);
                var usersData = VKontakteAuthenticationClient.DeserializeJson<UsersData>(response);
                var userData = usersData.response.First();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("status", userData.status);
                dic.Add("photo", userData.photo_100);
                dic.Add("accesstoken", accessToken.access_token);
                return new AuthenticationResult(
                    true, (this as IAuthenticationClient).ProviderName, accessToken.user_id,
                    userData.first_name + " " + userData.last_name,
                    dic);
            }
            catch (Exception ex)
            {
                return new AuthenticationResult(ex);
            }
        }

        public static string Load(string address)
        {
            var request = WebRequest.Create(address) as HttpWebRequest;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static T DeserializeJson<T>(string input)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(input);
        }

    }
}