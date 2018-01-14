using System;
using System.Collections.Generic;
using System.Text;
using TokenJwt.Dto;
using TokenJwt.Dto.Results;

namespace TokenJwt.ApiClient.Services
{
    public class AuthService : BaseService
    {
        public AuthService(string serverUrl) : base(serverUrl)
        {

        }

        public OperationResult<TokenDto> GetToken(LoginDto loginDto)
        {
            var request = RequestHelper.CreateRestRequestObjectAsBody("api/Token/token", loginDto, RestSharp.Method.POST);
            var result = RequestHelper.SendRequest<TokenDto>(ServerUrl, request);
            return result;
        }
    }
}
