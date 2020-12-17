using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WADemo;

namespace WADemoTest
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient HttpClient { get; set; }
        public TestServerFixture()
        {
            var builder = new WebHostBuilder()
                    .UseStartup<Startup>();

            _testServer = new TestServer(builder);
            HttpClient = _testServer.CreateClient();
        }
        public void Dispose()
        {
            HttpClient.Dispose();
            _testServer.Dispose();
        }
    }
}
