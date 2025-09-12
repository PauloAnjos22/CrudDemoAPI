namespace CrudDemoAPI.Services
{
    public class ServiceResult
    {
        public bool Success { get;  private set; }
        public string? Message { get; private set; }

        private ServiceResult(bool success, string? errorMessage = null)
        {
            Success = success;
            Message = errorMessage;
        }
        public static ServiceResult Ok() => new ServiceResult(true);
        public static ServiceResult Fail(string errorMessage) => new ServiceResult(false, errorMessage);
    }
}
