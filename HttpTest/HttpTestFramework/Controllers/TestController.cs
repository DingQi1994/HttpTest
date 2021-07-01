using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Batch;
using CsharpHttpHelper;
using Flurl.Http;
using Flurl.Http.Configuration;
using RestSharp;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Models;


namespace HttpTestFramework.Controllers
{
    public class TestController : ApiController
    {
        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object Http()
        {
            var http = new HttpHelper();
            http.GetHtml(new HttpItem()
            {
                URL = "http://192.168.0.115:82/home/sleep",
                //ProxyIp = "192.168.0.115:8888",
            });


            return  Json("OK");
        }
        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object Http2()
        {



            //var client = HttpClientFactory.Create(new DefaultHttpBatchHandler(new HttpServer()
            //{
            //    new HttpClientHandler
            //}));
            var client = HttpClientFactory.Create(new HttpClientHandler
            {
                //Proxy = new WebProxy("http://192.168.0.115:8888"),
                //UseProxy = true
            });
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://192.168.0.115:82/home/sleep"),
                Method = HttpMethod.Get,
            };
            var r = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;


            return Json("OK");
        }

        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> Http3()
        {
            //FlurlHttp.Configure(settings => {
            //    settings.HttpClientFactory = new ProxyHttpClientFactory("http://192.168.0.115:8888");
            //});

            var text = "http://192.168.0.115:82/home/sleep".GetStringAsync();


            return await text;
        }

        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object Http4()
        {

            var http = new WebClient();
         //   http.Proxy = new WebProxy("http://192.168.0.115:8888");
            var r = http.DownloadString("http://192.168.0.115:82/home/sleep");


            return Json("OK");
        }

        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object Http5()
        {
            var http = new RestClient();
          //  http.Proxy = new WebProxy("http://192.168.0.115:8888");
            var req = new RestRequest("http://192.168.0.115:82/home/sleep");
            var r = http.Execute(req).Content;
            return Json("OK");
        }
        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object Http6()
        {
           
            var web=new WebUtils();
            web.DoGet("http://192.168.0.115:82/home/sleep", null, null);

            return Json("OK");
        }
    }
}
