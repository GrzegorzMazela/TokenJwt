using System;
using System.Collections.Generic;
using System.Text;

namespace TokenJwt.ApiClient.Services
{
    public abstract class BaseService
    {
        protected string ServerUrl { get; set; }

        public BaseService(string serverUrl)
        {
            ServerUrl = serverUrl;
        }
    }
}
