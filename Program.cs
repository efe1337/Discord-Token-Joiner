using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace joiner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "Discord Token Joiner. Made by efe1337";

            Console.Write("\nDrag and drop token file:");
            string filepath = Console.ReadLine();
            Console.Write("Write server invite link:");
            string invitecode = Console.ReadLine().Substring("https://discord.gg/".Length);

            foreach(string ine in File.ReadAllLines(filepath))
            {
                System.Threading.Thread.Sleep(258);
                Join(invitecode,ine);
                System.Threading.Thread.Sleep(258);
            };
            Console.ReadLine();
        }
        static void Join(string invitelink, string token)
        {
            try
            {
                var Req = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v8/invites/{invitelink}?inputValue=https%3A%2F%2Fdiscord.gg%2F{invitelink}&with_counts=true");
                string UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";
                Req.Method = "POST";
                Req.UserAgent = UserAgent;
                Req.ContentType = "application/json";
                Req.Headers.Add("authorization", token);

                using (Stream ReqResponseStream = Req.GetResponse().GetResponseStream())
                {
                    using (StreamReader ReqResponse = new StreamReader(ReqResponseStream))

                    {
                        string Resp = ReqResponse.ReadToEnd();
                        ReqResponse.Close();
                        Console.WriteLine($"Done {token}!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Not working: {token}");
            }
        }
    }
}
