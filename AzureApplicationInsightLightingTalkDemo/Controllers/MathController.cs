using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AzureApplicationInsightLightingTalkDemo.Controllers
{
    [RoutePrefix("api/math")]
    public class MathController : ApiController
    {
        [HttpGet, Route("add/{a}/{b}")]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [HttpGet, Route("subtract/{a}/{b}")]
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        [HttpGet, Route("multiply/{a}/{b}")]
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        [HttpGet, Route("divide/{a}/{b}")]
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
