using System.Collections.Generic;

namespace arquetipo.Entity.Response
{
    public class Response <ResponseData> : ResponseBase where ResponseData : class
    {
        public ResponseData? Data { get; set; } 
    }
}
