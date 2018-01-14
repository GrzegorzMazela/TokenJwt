using System;
using System.Collections.Generic;
using System.Text;
using TokenJwt.Dto;
using TokenJwt.Dto.Results;

namespace TokenJwt.ApiClient.Services
{
    public class TxtService : BaseService
    {
        public TxtService(string serverUrl) : base(serverUrl)
        {

        }

        public OperationResult<UserTxtDto> GetTxt(string token)
        {
            var request = RequestHelper.CreateRestRequest("api/txt");
            var result = RequestHelper.SendRequest<UserTxtDto>(ServerUrl, request, token);
            return result;
        }
    }
}
