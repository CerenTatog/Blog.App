using Blog.Model.Models;

namespace Blog.BLL.Helper
{
    [Serializable]
    public class ServiceResult
    {
        public ServiceResultState State { get; set; }

        public string Message { get; set; }

        public ServiceResult(string message = "", ServiceResultState state = ServiceResultState.SUCCESS)
        {
            State = state;
            Message = message;
        }
    }
    [Serializable]
    public class ServiceResult<T> : ServiceResult
    {
        public T Result { get; set; }

        public ServiceResult(T result, string message = "", ServiceResultState state = ServiceResultState.SUCCESS)
            : base(message, state)
        {
            Result = result;
        }
    }

}
