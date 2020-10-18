using API.Interfaces;

namespace API.Entities
{
    public class ApiResult: IApiResult
    {
        public int Error { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
