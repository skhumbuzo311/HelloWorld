using SmartAutoSpares.Outcomes.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SmartAutoSpares.Outcomes
{
    public class Handler : IHandler
    {
        public ActionResult<IOutcome> HandleOutcome(IOutcome outcome)
        {
            switch (outcome)
            {
                case Success success:
                    return success.Data != null ? new OkObjectResult(success.Data) : (ActionResult)new OkResult();
                case Failure failure:
                    return new FailedOutcomeResult(failure);
                default:
                    throw new ArgumentException($"Outcome type, \"{outcome?.GetType().FullName}\", has not been catered for.");
            }
        }

        public ActionResult<IOutcome<T>> HandleOutcome<T>(IOutcome<T> outcome)
        {
            switch (outcome)
            {
                case Success<T> success:
                    return success.Data != null ? new OkObjectResult(success.Data) : (ActionResult)new OkResult();
                case Failure<T> failure:
                    return new FailedOutcomeResult(failure);
                default:
                    throw new ArgumentException($"Outcome type, \"{outcome?.GetType().FullName}\", has not been catered for.");
            }
        }
    }
}
