using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Net.Http;

namespace CarManager.MyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory,"plugins"));

            foreach (string  file in files)
            {
                Assembly.LoadFile(file);
            }

            var config = new HttpSelfHostConfiguration("http://127.0.0.1:5678");
            config.Routes.MapHttpRoute("default","api6/{controller}/{id}",new { id=RouteParameter.Optional});

            //启动服务器

            var server = new HttpSelfHostServer(config);

            server.OpenAsync().Wait();//异步启动服务器

            Console.WriteLine("这个服务器已经启动了");

            //之后再服务器中调动接口方法就可以了
            Console.ReadKey();


            //.net 中调用 webservice
            HttpClient client = new HttpClient();
            //再引用 using System.Net.Http.Formatting; 强化 using System.Net.Http;

            client.GetStringAsync("");
        }
    }
}
