using SmartAutoSpares.Outcomes.Results;
using Microsoft.AspNetCore.Mvc;

namespace SmartAutoSpares.Outcomes
{
    public interface IHandler
    {
        ActionResult<IOutcome> HandleOutcome(IOutcome outcome);
        ActionResult<IOutcome<T>> HandleOutcome<T>(IOutcome<T> outcome);
    }
}
