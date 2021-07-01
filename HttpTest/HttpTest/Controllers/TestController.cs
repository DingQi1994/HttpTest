using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Mvc;
using NetCoreHttpHelper;

using RestSharp;
using IHttpClientFactory = System.Net.Http.IHttpClientFactory;



namespace HttpTest.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class TestController : ControllerBase
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public TestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Http()
        {

            //for (int i = 0; i < 30; i++)
            //{
            //    Task.Factory.StartNew(() =>
            //    {

            //    });
            //}
            var http = new HttpHelper();
            http.GetHtml(new HttpItem()
            {
                URL = "http://192.168.0.115:82/home/sleep",
             //   ProxyIp = "192.168.0.115:8888",
            });


            return new JsonResult("OK");
        }
        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Http2()
        {
            var client = _httpClientFactory.CreateClient("HttpClientFactoryDemo");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://192.168.0.115:82/home/sleep"),
                Method = HttpMethod.Get,
            };

            return Ok(await client.SendAsync(request));
        }

        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Http3()
        {
            //FlurlHttp.Configure(settings => {
            //    settings.HttpClientFactory = new ProxyHttpClientFactory("http://192.168.0.115:8888");
            //});
            string text =  "http://192.168.0.115:82/home/sleep".GetStringAsync().Result;
            return text;
        }

        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Http4()
        {
            var http = new WebClient();
          //  http.Proxy = new WebProxy("http://192.168.0.115:8888");
            var r = http.DownloadString("http://192.168.0.115:82/home/sleep");
            return Ok(r);
        }

        /// <summary>
        /// 商品搜索接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Http5()
        {
            var http = new RestClient();
          //  http.Proxy = new WebProxy("http://192.168.0.115:8888");
            var req = new RestRequest("http://192.168.0.115:82/home/sleep");
            var r = http.Execute(req).Content;
            return Ok(r);
        }

    }
}
