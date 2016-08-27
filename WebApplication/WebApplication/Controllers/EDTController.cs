using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.DbContexts;
using System.Transactions;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/edt")]
    public class EDTController : ApiController
    {
        private readonly ContextA _contextA;
        private readonly ContextB _contextB;

        public EDTController()
        {
            _contextA = new ContextA();
            _contextB = new ContextB();
        }

        [HttpGet, Route("create-one-and-fail")]
        public IHttpActionResult DoWork()
        {
            int tempId = 0;
            try
            {
                using (var scope = new TransactionScope())
                {
                    var a = new AModel { BValue1 = Guid.NewGuid().ToString() };
                    var b = new BModel { BValue1 = Guid.NewGuid().ToString() };

                    _contextA.ATable.Add(a);
                    _contextA.SaveChanges();

                    tempId = a.Id;
                    throw new Exception();

                    _contextB.BTable.Add(b);
                    _contextB.SaveChanges();

                    scope.Complete();
                }
            }
            catch
            {
                return Ok($"Id A supposed to get - {tempId}");
            }
        }

            

        [HttpGet, Route("create")]
        public IHttpActionResult CreateItemsEach()
        {
            using (var scope = new TransactionScope())
            {
                var a = new AModel { BValue1 = Guid.NewGuid().ToString() };
                var b = new BModel { BValue1 = Guid.NewGuid().ToString() };

                _contextA.ATable.Add(a);
                _contextA.SaveChanges();

                _contextB.BTable.Add(b);
                _contextB.SaveChanges();

                scope.Complete();

                return Ok($"A Id - {a.Id}, B Id - {b.Id}");
            }
        }
    }
}
