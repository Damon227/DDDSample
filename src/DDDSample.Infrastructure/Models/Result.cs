namespace DDDSample.Infrastructure.Models
{
    public class Result
    {
        public bool Succeed { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }
        
        public object Data { get; set; }

        public static Result Success() => new Result { Succeed = true, Message = "操作成功"};

        public static Result Success(int code, string message)
        {
            return new Result { Succeed = true, Code = code, Message = message };
        }

        public static Result Success(string message)
        {
            return Success(0, message);
        }

        public static Result Fail(int code, string message)
        {
            return new Result { Succeed = false, Code = code, Message = message };
        }

        public static Result Fail(string message)
        {
            return Fail(0, message);
        }
    }

    public class Result<T> : Result
    {
        public new T Data { get; set; }

        public static Result<T> Success(T data)
        {
            return Success(0, null, data);
        }

        public static Result<T> Success(string message, T data)
        {
            return Success(0, message, data);
        }

        public static Result<T> Success(int code, string message, T data)
        {
            return new Result<T> { Succeed = true, Code = code, Message = message, Data = data };
        }

        public new static Result<T> Fail(string message)
        {
            return Fail(0, message);
        }

        public new static Result<T> Fail(int code, string message)
        {
            return new Result<T> { Succeed = false, Code = code, Message = message };
        }
    }
}
