using System.Collections.Generic;

namespace SmartAutoSpares.Outcomes.Results
{
    public class Failure : IOutcome
    {
        public List<string> ErrorMessages { get; private set; }
        public Failure(string errorMessage)
        {
            ErrorMessages = new List<string>() { errorMessage };
        }
        public Failure(IEnumerable<string> errorMessages)
        {
            ErrorMessages = new List<string>(errorMessages);
        }
    }

    public class Failure<T> : IOutcome<T>
    {
        public List<string> ErrorMessages { get; private set; }
        public Failure(string errorMessage)
        {
            ErrorMessages = new List<string>() { errorMessage };
        }
        public Failure(IEnumerable<string> errorMessages)
        {
            ErrorMessages = new List<string>(errorMessages);
        }
    }
}
