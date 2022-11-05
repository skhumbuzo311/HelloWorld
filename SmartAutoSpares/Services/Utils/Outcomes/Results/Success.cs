using System;

namespace SmartAutoSpares.Outcomes.Results
{
    public class Success : IOutcome
    {
        public Object Data { get; private set; }
        public Success() { }
        public Success(Object data)
        {
            Data = data;
        }
    }

    public class Success<T> : IOutcome<T>
    {
        public T Data { get; private set; }
        public Success() { }
        public Success(T data)
        {
            Data = data;
        }
    }
}
