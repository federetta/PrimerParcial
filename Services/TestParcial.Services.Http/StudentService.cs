using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestParcial.Business;
using TestParcial.Entities;
using TestParcial.Services.Contracts;

namespace TestParcial.Services.Http
{
    /// <summary>
    /// student HTTP service controller.
    /// </summary>
    [RoutePrefix("rest/Student")]
    public class StudentService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllResponse All()
        {
            try
            {
                var response = new AllResponse();
                var bs = new StudentBusiness();
                response.Result = bs.All();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }

        }

        [HttpPost]
        [Route("Add")]
        public Student Add(Student student)
        {
            try
            {
                var bc = new StudentBusiness();
                return bc.Add(student);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}