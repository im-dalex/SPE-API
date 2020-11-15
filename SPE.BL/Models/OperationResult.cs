using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SPE.BL.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public OperationResult()
        {
            Success = false;
            Message = String.Empty;
            StatusCode = 0;
        }
        public OperationResult(HttpStatusCode statusCode)
        {
            Success = false;
            Message = String.Empty;
            StatusCode = statusCode;
        }
        public OperationResult(HttpStatusCode statusCode, bool success)
        {
            Success = success;
            Message = String.Empty;
            StatusCode = statusCode;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }
        public OperationResult()
        {

        }
        public OperationResult(HttpStatusCode statusCode)
            :base(statusCode)
        {

        }
        public OperationResult(HttpStatusCode statusCode, bool success)
            :base(statusCode, success)
        {

        }
    }
}
