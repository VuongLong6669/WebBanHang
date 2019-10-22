using System;
using System.Collections.Generic;

namespace SmartMarketServer.Response
{
    public class BaseResponse
    {
        public const string CODE_SUCESS = "200";
        public const string CODE_NOT_FOUND = "404";
        public const string CODE_BAD_REQUEST = "400";
        public string message;

        public string code;

        public string getCode()
        {
            return code;
        }
        public void setCode(String code)
        {
            this.code = code;
        }

        public string getMessage()
        {
            return message;
        }
        public void setMessage(String message)
        {
            this.message = message;
        }

    }
}
