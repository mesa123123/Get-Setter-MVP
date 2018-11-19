using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;

namespace Get_Setter
{

    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class RestTalker
    {
        string endPoint { get; set; }
        httpVerb httpInteraction { get; set; }

        public RestTalker(string query)
        {
            endPoint = query;
            httpInteraction = httpVerb.GET;

        }

        public APOD talkToRestClient()
        {
            string responseString = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpInteraction.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using(StreamReader reader = new StreamReader(responseStream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }
            }
            APOD todaysPhoto = DeSerialize(responseString);
            return todaysPhoto;
        }

        public APOD DeSerialize(string responseString)
        { 
            APOD retrievedPhoto = Newtonsoft.Json.JsonConvert.DeserializeObject<APOD>(responseString);
            return retrievedPhoto;
        }
    }
}
