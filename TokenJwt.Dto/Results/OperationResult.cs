using System;
using System.Collections.Generic;
using System.Text;

namespace TokenJwt.Dto.Results
{
    public class OperationResult
    {
        public bool Succes { get; private set; }
        public ErrorInfo ErrorInfo { get; private set; }

        public OperationResult()
        {
            Succes = false;
            ErrorInfo = null;
        }

        public void SetSucces()
        {
            Succes = true;
        }

        public void SetError(string errorCode, string message)
        {
            Succes = false;
            ErrorInfo = new ErrorInfo();
            ErrorInfo.SetError(errorCode, message);
        }

        public void SetError(ErrorInfo errorInfo)
        {
            Succes = false;
            ErrorInfo = errorInfo;
        }

        public void SetError(string errorCode, Exception ex)
        {
            Succes = false;
            ErrorInfo = new ErrorInfo();
            ErrorInfo.SetError(errorCode, ex);
        }

        public void SetError(Exception ex)
        {
            Succes = false;
            ErrorInfo = new ErrorInfo();
            ErrorInfo.SetError(ex);
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public void SetSucces(T data)
        {
            base.SetSucces();
            Data = data;
        }
    }
}
