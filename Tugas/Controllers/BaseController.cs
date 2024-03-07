
using Tugas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tugas.Models;
using System.Collections.Generic;
using System;
using System.Net;
using Tugas.Models.Request;
using Newtonsoft.Json;
using Tugas.Models.Entity;

namespace Tugas.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BaseController : ControllerBase, IBaseController
    {
        protected IServiceBase _service;

        public BaseController(IServiceBase service) 
        { 
            _service = service;
        }

        [HttpGet]
        [Route("get_all_data")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public virtual async Task<ActionResult<ApiResponse>> GetAllData()
        {
            try
            {

                ServiceResult result = await _service.GetAllData();
                return GenerateResult(result);
            }
            catch (Exception ex)
            {
                return GenerateException(ex);
            }
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public virtual async Task<ActionResult<ApiResponse>> Get(int Id)
        {
            try
            {

                ServiceResult result = await _service.Get(Id);
                return GenerateResult(result);
            }
            catch (Exception ex)
            {
                return GenerateException(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public virtual async Task<ActionResult<ApiResponse>> Post([FromBody] IEnumerable<StudentModel> studentModel)
        {
            try
            {

                ServiceResult result = await _service.Create(studentModel);
                return GenerateResult(result);
            }
            catch (Exception ex)
            {
                return GenerateException(ex);
            }
        }

        protected ApiResponse GenerateResult(ServiceResult serviceResult)
        {
            ApiResponse result = new ApiResponse();

            if (serviceResult.IsError)
            {
                result.Title = "Error";
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Result = serviceResult;
            }
            else
            {
                result.Title = "Success";
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Result = serviceResult;
            }

            return result;
        }

        protected ApiResponse GenerateException(Exception ex)
        {
            ApiResponse result = new ApiResponse()
            {
                Title = "Error",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Result = new ServiceResult()
                {
                    IsError = true,
                    Message = ex.Message
                }
            };

            return result;
        }
    }
}
