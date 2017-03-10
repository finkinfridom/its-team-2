using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApplication12{
    class postData{
        string datap="";
        string urlp = "";
        string responsep = "";
        public string response{
            get { return responsep; }
        }
        public postData(){
            
        }
        public postData(string url){
            this.url=url;
        }
        public postData(string url, Dictionary<string, string> parameters){
            this.url = url;
            data = "";
            foreach (KeyValuePair<string, string> entry in parameters)
                data += entry.Key + "=" + entry.Value + "&";
            data = data.Substring(0, data.Length - 1);
        }

        public string url{
            get { return urlp; }
            set {
                if(checkUrl(value))
                    urlp = value;
            }
        }
        public string data{
             get { return datap; }
             set { datap = value; }
         }

        public bool start() {
            try{
                WebRequest request = WebRequest.Create(urlp);
                request.Method = "POST";
                string postData = datap;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();// Get the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);// Write the data to the request stream.
                dataStream.Close();// Close the Stream object.
                WebResponse responseWeb = request.GetResponse();// Get the response.
                //Console.WriteLine (((HttpWebResponse)response).StatusDescription);
                dataStream = responseWeb.GetResponseStream();// Get the stream containing content returned by the server.
                StreamReader reader = new StreamReader(dataStream);// Open the stream using a StreamReader for easy access.
                string responseFromServer = reader.ReadToEnd();// Read the content.
                //Console.WriteLine(responseFromServer);
                reader.Close();
                dataStream.Close();
                responseWeb.Close();
                if (((HttpWebResponse)responseWeb).StatusDescription == "OK"){
                    responsep = responseFromServer;
                    return true;
                }else{
                    responsep = null;
                    return false;
                }
            }catch (WebException WebE){
                if (WebE.ToString().Substring(25, 36).Equals("Impossibile risolvere il nome remoto")) {
                    Console.WriteLine("Error: check connection");
                }else if (WebE.ToString().Substring(51, 5).Equals("(404)")){
                    Console.WriteLine("Error: 404 Page not found");
                }
                return false;
            }catch (UriFormatException){
                Console.WriteLine("Error: Invalid Url");
                return false;
            }catch (Exception e){
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        static public bool checkUrl(string url){
            Uri uriResult;
            return (url.Length>0) ? (Uri.TryCreate(url, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp) : false;
        }

       static public String login(String mail,String pass){
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("mail", mail);
            parameters.Add("pass", pass);
            parameters.Add("f", "11");
            postData mioPost = new postData("http://dbsecret.altervista.org/funz.php", parameters);
            if (mioPost.start())
                return mioPost.response;
            else
                return"Error!";
        }

        static public String addUser(Dictionary<string, string> parameters){
            parameters.Add("f", "10");
            postData mioPost = new postData("http://dbsecret.altervista.org/funz.php", parameters);
            if (mioPost.start())
                return mioPost.response;
            else
                return "Error!";
        }

    }
}

