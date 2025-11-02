namespace TechPathNavigator.Common.Results
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();

        public static ServiceResult<T> Ok(T data) => new ServiceResult<T> { Success = true, Data = data };
        public static ServiceResult<T> Fail(params string[] errors) => new ServiceResult<T> { Success = false, Errors = errors.ToList() };
        public static ServiceResult<T> Fail(IEnumerable<string> errors) => new ServiceResult<T> { Success = false, Errors = errors.ToList() };
    }
}


