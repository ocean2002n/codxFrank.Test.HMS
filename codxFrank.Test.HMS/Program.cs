using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace codxFrank.Test.HMS
{
    class Program
    {
        public static string SSOID = "HB78dCVFlp2oImk";
        public static string ApiUriRandom = "http://61.220.206.55:3001/v1/random";
        public static string ApiUriHash = "http://61.220.206.55:3001/v1/hash";
        public static string ApiUriEncrypt = "http://61.220.206.55:3001/v1/encrypt";
        public static string ApiUriDecrypt = "http://61.220.206.55:3001/v1/decrypt";
        public static string ApiUriGenerateAllKey = "http://61.220.206.55:3001/v1/genallsessionkey";
        public static string ApiUriGenerateSingleKey = "http://61.220.206.55:3001/v1/gensinglesessionkey";
        public static string ApiUriDeleteSingleKey = "http://61.220.206.55:3001/v1/delsinglesessionkey";
        public static string ApiUriDeleteAllKey = "http://61.220.206.55:3001/v1/delallsessionkey";
        public static string ApiUriSign = "http://61.220.206.55:3001/v1/sign";
        public static string ApiUriVerify = "http://61.220.206.55:3001/v1/verify";

        static void Main(string[] args)
        {
            HmsHelper.GenerateAllKey("Frank", "00000000", HmsKeyTypeEnum.DES3, HmsDataFormateEnum.hex);
        }



        public class HmsHelper
        {
            private static string SendRequest(string uri, object rq)
            {
                var postRs = CommonHelper.HttpPost(uri, rq, false);
                var rs = JsonHelper.DeserializeFromJSON<HmsMessageRs>(postRs);
                return rs.data;
            }

            /// <summary>
            /// 隨機亂數
            /// </summary>
            /// <param name="length">亂數長度</param>
            /// <returns></returns>
            public static string Random(int length)
            {
                var rq = new HmsRandomRq
                {
                    ssoid = SSOID,
                    randomValueBytesLength = length,
                    responseFormat = HmsDataFormateEnum.hex.ToString()
                };
                
                return SendRequest(ApiUriRandom, rq);
            }

            /// <summary>
            /// 雜湊演算(SHA)
            /// </summary>
            /// <param name="input">欲加密之資料</param>
            /// <param name="hashType">加密類型(預設SHA256)</param>
            /// <returns></returns>
            public static string Hash(string input, HmsHashTypeEnum hashType = HmsHashTypeEnum.SHA256)
            {
                var rq = new HmsHashRq
                {
                    ssoid = SSOID,
                    hashType = hashType,
                    data = input,
                    dataFormat = HmsDataFormateEnum.utf8.ToString(),
                    responseFormat = HmsDataFormateEnum.hex.ToString()
                };
                
                return SendRequest(ApiUriHash, rq);
            }

            /// <summary>
            /// 加密
            /// </summary>
            /// <param name="keyName">金鑰名稱</param>
            /// <param name="input">欲加密之資料</param>
            /// <param name="encryptType">加密類型</param>
            /// <param name="iv">只有CBC加密才必須傳入</param>
            /// <returns></returns>
            public static string Encrypt(string keyName, string input, HmsEncryptModeEnum encryptType, string iv = "")
            {
                var rq = new HsmEncryptRq
                {
                    ssoid = SSOID,
                    keyName = keyName,
                    encryptMode = encryptType,
                    keyIV = iv,
                    data = input,
                    dataFormat = HmsDataFormateEnum.utf8.ToString(),
                    responseFormat = HmsDataFormateEnum.hex.ToString()
                };

                return SendRequest(ApiUriEncrypt, rq);
            }

            /// <summary>
            /// 解密
            /// </summary>
            /// <param name="keyName">金鑰名稱</param>
            /// <param name="input">欲解密之資料</param>
            /// <param name="decryptType">解密類型</param>
            /// <param name="iv">只有CBC加密才必須傳入</param>
            /// <returns></returns>
            public static string Decrypt(string keyName, string input, HmsEncryptModeEnum decryptType, string iv = "")
            {
                var rq = new HmsDecryptRq
                {
                    ssoid = SSOID,
                    keyName = keyName,
                    decryptMode = decryptType,
                    keyIV = iv,
                    data = input,
                    dataFormat = HmsDataFormateEnum.hex.ToString(),
                    responseFormat = HmsDataFormateEnum.utf8.ToString()
                };

                return SendRequest(ApiUriDecrypt, rq);
            }

            /// <summary>
            /// 刪除金鑰於一台HSM
            /// </summary>
            /// <param name="keyname">金鑰名稱</param>
            /// <param name="keyType">金鑰類型</param>
            /// <returns></returns>
            public static string DeleteSingleKey(string keyname, HmsKeyTypeEnum keyType)
            {
                var rq = new HmsDelSingleKeyRq
                {
                    ssoid = SSOID,
                    keyName = keyname,
                    keyType = keyType
                };

                return SendRequest(ApiUriDeleteSingleKey, rq);
            }

            /// <summary>
            /// 刪除金鑰於所有HSM
            /// </summary>
            /// <param name="keyname">金鑰名稱</param>
            /// <param name="keyType">金鑰類型</param>
            /// <returns></returns>
            public static string DeleteAllKey(string keyname, HmsKeyTypeEnum keyType)
            {
                var rq = new HmsDelAllKeyRq
                {
                    ssoid = SSOID,
                    keyName = keyname,
                    keyType = keyType
                };

                return SendRequest(ApiUriDeleteSingleKey, rq);
            }

            /// <summary>
            /// 建立金鑰於一台HSM
            /// </summary>
            /// <param name="keyName">金鑰名稱</param>
            /// <param name="keyValue">金鑰內容</param>
            /// <param name="keyType">金鑰類型</param>
            /// <param name="keyValueFormate">金鑰內容格式</param>
            /// <returns></returns>
            public static string GenerateSingleKey(string keyName, string keyValue, HmsKeyTypeEnum keyType, HmsDataFormateEnum keyValueFormate)
            {
                var rq = new HmsGenSingleKeyRq
                {
                    ssoid = SSOID,
                    keyType = keyType,
                    keyName = keyName,
                    keyValue = keyValue,
                    keyValueFormat = keyValueFormate.ToString()
                };

                return SendRequest(ApiUriGenerateSingleKey, rq);
            }

            /// <summary>
            /// 建立金鑰於所有HSM
            /// </summary>
            /// <param name="keyName">金鑰名稱</param>
            /// <param name="keyValue">金鑰內容</param>
            /// <param name="keyType">金鑰類型</param>
            /// <param name="keyValueFormate">金鑰內容格式</param>
            /// <returns></returns>
            public static string GenerateAllKey(string keyName, string keyValue, HmsKeyTypeEnum keyType, HmsDataFormateEnum keyValueFormate)
            {
                var rq = new HmsGenAllKeyRq
                {
                    ssoid = SSOID,
                    keyType = keyType,
                    keyName = keyName,
                    keyValue = keyValue,
                    keyValueFormat = keyValueFormate.ToString()
                };
                
                return SendRequest(ApiUriGenerateAllKey, rq);
            }

            //TODO Sign

            //TODO Verify
        }


    }

    public static class CommonHelper
    {
        public static string HttpPost(string url, object postJson, bool chkUseSsl = false)
        {
            if (chkUseSsl)
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;
            }

            var result = "";
            var handler = new WebRequestHandler
            {
                AllowAutoRedirect = false,
                UseProxy = false,
                Credentials = CredentialCache.DefaultNetworkCredentials
            };
            using (var client = new HttpClient(handler))
            {
                client.PostAsJsonAsync(url, postJson)
                    .ContinueWith(task =>
                    {
                        var response = task.Result;
                        result = response.Content.ReadAsStringAsync().Result;
                    }).Wait();
            }
            return result;
        }
    }

    public static class JsonHelper
    {
        /// <summary>
        /// 最後一次的錯誤物件
        /// </summary>
        public static Exception LastException;

        /// <summary>
        /// 將JSON格式的字串轉成物件
        /// </summary>
        /// <param name="psJsonString">JSON格式的字串</param>
        /// <typeparam name="T">轉換物件型態</typeparam>
        public static T DeserializeFromJSON<T>(string psJsonString)
        {
            try
            {
                if (psJsonString == null)
                    return default(T);
                else
                    return JsonConvert.DeserializeObject<T>(psJsonString);
            }
            catch (Exception ex)
            {
                LastException = ex;
                return default(T);
            }
        }

        /// <summary>
        /// 將物件轉成JSON字串
        /// </summary>
        /// <param name="poObject">來源物件</param>
        /// <param name="pbUseEscape">是否執行Escape</param>
        public static string SerializeObjectToJSON(object poObject, bool pbUseEscape = false)
        {
            // 忽略null值的轉換
            JsonSerializerSettings oSettings = new JsonSerializerSettings();
            oSettings.NullValueHandling = NullValueHandling.Ignore;
            string sJsonString = JsonConvert.SerializeObject(poObject, oSettings);
            // 因可能輸入特殊字元，故使用EscapeDataString
            if (pbUseEscape)
                return Uri.EscapeDataString(sJsonString);
            else
                return sJsonString;
        }
    }
}
