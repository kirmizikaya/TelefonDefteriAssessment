using System;

namespace PhoneBook.Api.Commands.Response
{
    public class ResponseData<T> where T : class
    {
        public ResponseData()
        {
            requestId = Guid.NewGuid();
        }

        public ResponseData(int statusCode, string message, string exceptionMessage, string innerExceptionMessage, string stackTrace, bool isSuccess)
        {
            requestId = Guid.NewGuid();
            exceptionDescription = message;
            innerExceptionMessage = exceptionMessage;
            StatusCode = statusCode;
            this.exceptionMessage = exceptionMessage;
        }

        public ResponseData(int statusCode, T responseData, string message, string exceptionMessage, bool isSuccess)
        {
            requestId = Guid.NewGuid();
            exceptionDescription = message;
            result = responseData;
            innerExceptionMessage = exceptionMessage;
            StatusCode = statusCode;
        }

        public Guid requestId { get; set; }
        public string exceptionMessage { get; set; }
        public string innerExceptionMessage { get; set; }
        public string exceptionDescription { get; set; }
        public T result { get; set; }
        public int StatusCode { get; set; }

        public static ResponseData<T> SendSuccessResponse(T responseData)
        {
            return new ResponseData<T>(200, responseData, null, null, true);
        }
        public static ResponseData<T> SendErrorResponse(System.Exception e)
        {
            return new ResponseData<T>(500, null, e.Message, e.InnerException?.Message, e.StackTrace, false);
        }
        public static ResponseData<T> SendErrorResponse(System.Exception e, int statusCode)
        {
            return new ResponseData<T>(statusCode, null, e.Message, e.InnerException?.Message, e.StackTrace, false);
        }
        public static ResponseData<T> SendNoContentResponse()
        {
            return new ResponseData<T>(404, "İçerik Bulunamadı !", null, null, null, true);
        }
    }



    public class ResponseModel
    {
        public bool IsSuccecss { get; set; }
    }
}
