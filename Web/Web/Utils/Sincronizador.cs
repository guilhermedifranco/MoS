using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Web.Utils
{
    public class Sincronizador
    {
        public static object Post(string url, NetworkCredential credential, string json, string codigo = null, bool contentTypeJson = true)
        {
            string URL = url;
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpRequest.Method = "POST";
            if (!contentTypeJson)
                httpRequest.ContentType = "application/x-www-form-urlencoded; charset=ISO-8859-1";
            else
                httpRequest.ContentType = "application/json";
            httpRequest.Accept = "application/json";
            httpRequest.Credentials = credential;

            using (Stream stm = httpRequest.GetRequestStream())
            {
                using (StreamWriter stmw = new StreamWriter(stm))
                {
                    stmw.Write(json);
                }
            }
            System.Net.ServicePointManager.Expect100Continue = false;
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
            if (httpRequest.HaveResponse)
            {
                string response = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();

                byte[] byteArray = Encoding.UTF8.GetBytes(response);
                //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                MemoryStream stream = new MemoryStream(byteArray);

                StreamReader sr = new StreamReader(stream);
                var serializer = new JsonSerializer();
                var jsonTextReader = new JsonTextReader(sr);

                object j = serializer.Deserialize(jsonTextReader);

                return j;
            }
            else
                if (string.IsNullOrEmpty(codigo))
                    throw new NullReferenceException("O servidor não retornou nenhum resultado.");
                else
                    throw new NullReferenceException(string.Format("O servidor não retornou nenhum resultado para o código {0}.", codigo));

        }
   
    }
}