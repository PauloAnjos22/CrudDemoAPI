namespace CrudDemoAPI.Services
{
    public class ServiceResult
    {
        public bool Success { get;  private set; }
        public string? Message { get; private set; }

        protected ServiceResult(bool success, string? errorMessage = null)
        {
            Success = success;
            Message = errorMessage;
        }
        public static ServiceResult Ok() => new ServiceResult(true);
        public static ServiceResult Fail(string errorMessage) => new ServiceResult(false, errorMessage);
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; private set; }

        private ServiceResult(bool success, T? data = default, string? errorMessage = null)
            : base(success, errorMessage)
        {
            Data = data;
        }
        public static ServiceResult<T> Ok(T data) => new ServiceResult<T>(true, data);
        public new static ServiceResult<T> Fail(string errorMessage) => new ServiceResult<T>(false, default, errorMessage);
    }
 }
