using System;
using System.Collections.Generic;
using System.Linq;
using KeenSap.Portal.API.Common.Validation;
using KeenSap.Portal.Service.Dto;
using KeenSap.Portal.Service.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KeenSap.Portal.API.Controllers
{
    public abstract class GenericController : ControllerBase 
    {
        

        protected IActionResult Success(string message = "Record fetched successfully.")
        {
             return Ok(new ResponseDto(true, message));
        }

        protected IActionResult Success<T>(T data, string message = "Record fetched successfully.")
            // where T : IDto
        {
             return Ok(new ResponseDto<T>(data, true, message));
        }

        protected IActionResult Success<T>(IEnumerable<T> data, string message = "Record fetched successfully.")
            where T : IDto
        {
             return Ok(new ResponseDto<IEnumerable<T>>(data, true, message));
        }

        protected IActionResult Error(string message, Exception ex = null)
        {
            var response = new ResponseDto(false, message);
            if(ex != null) response.Errors.Add(GetErrorMessage(ex));
            return UnprocessableEntity(response);
        }


        protected string GetErrorMessage(Exception ex)
        {
            var msg = string.Empty;
            if(ex.GetType() == typeof(MySql.Data.MySqlClient.MySqlException))
                msg = ex.Message.ToString();

            if(ex.InnerException != null)
                msg = GetErrorMessage(ex.InnerException);

            if(string.IsNullOrEmpty(msg)) 
                msg = ex.Message.ToString();
            return msg;
        }

        protected ValidationFailedResult ValidationFailed(){
            return new ValidationFailedResult(ModelState);
        }

        protected ValidationFailedResult ValidationFailed(string key, string errorMessage){
            ModelState.AddModelError(key, errorMessage);
            return new ValidationFailedResult(ModelState);
        }
    }
}
