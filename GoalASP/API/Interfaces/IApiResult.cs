namespace API.Interfaces
{
    public interface IApiResult
    {
        public int Error { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
