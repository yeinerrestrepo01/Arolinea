namespace Aerolina.Domain.Entities
{
    public class ApiResult
    {
        public string Message { get; set; }
        public object Result { get; set; }
        public bool IsError { get; set; }
    }
}
