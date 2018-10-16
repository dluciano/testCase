using Microsoft.AspNetCore.Mvc;
using System;

namespace Clay.WebApi
{
    public abstract class ClayBaseController : ControllerBase
    {
        protected IActionResult RenderResult(ResultDto result)
        {
            switch (result.ResultType)
            {
                case ResultType.Sucessful:
                    return Ok(result.Value);
                case ResultType.EntityNotFounded:
                    return NotFound(result.Errors);
                case ResultType.InvalidRequest:
                    return BadRequest(ModelState);
                case ResultType.Deny:
                    return this.Forbid();
            }
            throw new Exception(result.StatusMessage);
        }
    }
}