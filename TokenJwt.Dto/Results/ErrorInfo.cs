using System;
using System.Collections.Generic;
using System.Text;

namespace TokenJwt.Dto.Results
{
    public class ErrorInfo
    {
        public string ErrorCode { get; private set; }

        public string Message { get; private set; }

        public string StackTrace { get; private set; }

        public void SetError(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public void SetError(string errorCode, Exception ex)
        {
            ErrorCode = errorCode;
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }

        public void SetError(Exception ex)
        {
            ErrorCode = "999";
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }
    }
}
