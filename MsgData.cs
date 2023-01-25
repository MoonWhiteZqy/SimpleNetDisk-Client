using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetdiskClient
{
    class ReqQuery
    {
        public string user_id { get; set; }
        public string lower_space { get; set; }
        public string higher_space { get; set; }
        public string lower_file_num { get; set; }
        public string higher_file_num { get; set; }
    }

    class UserDetail
    {
        public string Id { get; set; }
        public string Friends { get; set; }
        public int Filenum { get; set; }
        public Int64 Diskused { get; set; }
    }

    class ReqDeleteUser
    {
        public string manager_id { get; set; }
        public string user_id { get; set; }
    }

    class RespQuery
    {
        public UserDetail[] users { get; set; }
    }
    class ReqUserLoginRegister
    {
        public string user_id { get; set; }
        public string password { get; set; }
        public Int64 disk { get; set; }
    }
    class RespUserFriends
    {
        public string status { get; set; }
        public string reason { get; set; }
        public string[] friends { get; set; }
    }

    class RespUserCommon
    {
        public string status { get; set; }
        public string reason { get; set; }
        public string user_id { get; set; }
    }

    class ReqUserUpdateFriend
    {
        public string me { get; set; }
        public string friend { get; set; }
    }

    class ReqFileTarget
    {
        public string user_id { get; set; }
        public string target { get; set; }
        public string path { get; set; }
    }

    // 用户可下载文件中，文件的承载体
    class SimpleFile
    {
        public string file_path { get; set; }
        public string uploader { get; set; }
        public string[] target { get; set; }

        public void say()
        {
            Console.WriteLine(file_path);
            Console.WriteLine(uploader);
            for(int i = 0; i < target.Length; i++)
            {
                Console.WriteLine(target[i]);
            }
        }
    }

    // 用户可下载文件的承载体
    class RespFileList
    {
        public SimpleFile[] my_file { get; set; }
        public SimpleFile[] other_file { get; set; }
        public int file_num { get; set; }
        public string space_used { get; set; }
    }
    class MsgData
    {
        public string BaseUrl = "";

        // 普通的GET模版
        public string getHttpRequest(string addr)
        {
            try
            {
                HttpClient client = new HttpClient();

                Console.WriteLine(addr);
                var task = client.GetStringAsync(addr);
                string res = task.Result;
                return res;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        // 普通的POST模版
        public string postHttpRequest(string addr, Object obj)
        {
            try
            {
                HttpClient client = new HttpClient();
                string content = JsonConvert.SerializeObject(obj);
                Console.WriteLine(addr);

                // 定义POST请求地址和内容
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, addr);
                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // 读取返回信息
                var task = client.SendAsync(request);
                HttpResponseMessage resp = task.Result;
                var task_str = resp.Content.ReadAsStringAsync();
                string res = task_str.Result;
                return res;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        // 下载文件请求
        public byte[] downloadReq(string addr, Object obj)
        {
            try
            {
                HttpClient client = new HttpClient();
                string content = JsonConvert.SerializeObject(obj);
                Console.WriteLine(addr);

                // 定义POST请求地址和内容
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, addr);
                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // 读取返回信息
                var task = client.SendAsync(request);
                HttpResponseMessage resp = task.Result;
                var task_str = resp.Content.ReadAsByteArrayAsync();
                byte[] res = task_str.Result;
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new byte[0];
            }
        }

        // 上传文件请求
        public string webUploadFile(string addr, string path)
        {
            try
            {
                WebRequest req = WebRequest.Create(addr);
                req.Method = "POST";
                byte[] content = File.ReadAllBytes(path);
                req.ContentType = "application/octet-stream";
                req.ContentLength = content.Length;
                Stream dataStream = req.GetRequestStream();
                dataStream.Write(content, 0, content.Length);
                dataStream.Close();
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                string res = sr.ReadToEnd();
                Console.WriteLine(res);
                return res;
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }
    }

    
}
