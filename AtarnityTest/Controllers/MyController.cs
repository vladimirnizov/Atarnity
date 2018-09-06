using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using AtarnityTest.Models;

namespace AtarnityTest.Controllers
{
    public class MyController : ApiController
    {


         Dictionary<int, MyModel> models = new Dictionary<int, MyModel>()
         {
            {1, new MyModel("A",1)},
            {2, new MyModel("B",2)},
            {3, new MyModel("C",3)},
            {4, new MyModel("D",4)}
         };



        //GET api/my
        public HttpResponseMessage Get()
        {

           return Request.CreateResponse(HttpStatusCode.OK, models);
        }

        //POST api/my
        public HttpResponseMessage Post([FromBody]MyModel model)
        {

          if (!models.ContainsKey(model.id))
          {
            models.Add(model.id, model);
            return Request.CreateResponse(HttpStatusCode.Created, models);
          }
          else
            return Request.CreateResponse(HttpStatusCode.BadRequest, String.Format("id exist"));
        }


         //DELETE api/my/5
        public HttpResponseMessage Delete(int id)
        {
          if (models.ContainsKey(id))
          {
            models.Remove(id);
            return Request.CreateResponse(HttpStatusCode.Accepted, models);
          }
          else
            return Request.CreateResponse(HttpStatusCode.NotFound, String.Format("not found"));
        }

         //PUT api/my/5
        public HttpResponseMessage Put(int id, [FromBody]string name)
        {

          if (models.ContainsKey(id))
          {
            models[id].name=name;
            return Request.CreateResponse(HttpStatusCode.Accepted, models);
          }
          else
            return Request.CreateResponse(HttpStatusCode.NotFound, String.Format("not found"));
        }

  }
}
