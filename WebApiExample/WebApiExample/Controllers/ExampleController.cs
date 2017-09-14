using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    public class ExampleController : ApiController
    {
        [HttpGet]
        //[Route("empty")]
        public void Empty()
        {
        }

        [HttpGet]
        public IHttpActionResult return200()
        {
            return Ok();
        }


        [HttpGet]
        public IHttpActionResult return404()
        {
            return NotFound();
        }

        [HttpGet]
        //[Route("PcrFromApp")]
        public IEnumerable<Product> Objects()
        {
            return products;
        }

        [HttpGet]
        public HttpResponseMessage StatusCode()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Created;
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Headers()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.Add("CustomHeader", "Jopa");
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }




        [HttpGet]
        public IEnumerable<string> update()
        {
            return new string[] { "update", "update" };
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


        Product[] products = new Product[]
         {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
         };
    }
}