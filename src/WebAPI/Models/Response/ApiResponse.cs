namespace Rommanel.WebAPI.Models.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public static ApiResponse<T> Ok(T data, string? message = null)
            => new() { Data = data, Message = message };

        public static ApiResponse<T> Fail(IEnumerable<string> errors)
            => new() { Success = false, Errors = errors };

        public static ApiResponse<T> Fail(string error)
            => new() { Success = false, Errors = new List<string> { error } };
    }
}
