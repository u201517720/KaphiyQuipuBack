namespace Core.Common.Domain.Model
{
    public class Result
    {
        public Result()
        {
            this.Meta = new MetaResponse();
        }

        public bool Success { get; set; } = false;
        public string ErrCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public MetaResponse Meta { get; set; }
        public dynamic Data { get; set; }
    }
}
