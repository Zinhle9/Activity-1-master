using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        [System.Web.Http.Route("api/Customer/getCustomer")]
        [System.Web.Mvc.HttpPost]
        
        // GET api/values
        public List<dynamic> getAllCustomer()
        {
            Activity5Entities db = new Activity5Entities();
            db.Configuration.ProxyCreationEnabled = false;

            return getCustomerReturnList(db.Customers.ToList());
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
       private  List<dynamic> getCustomerReturnList(List<Customer> Employee)
        {
            List<dynamic> dynamicCustomer = new List<dynamic>();

            foreach(Customer customer in Employee)
            {
                dynamic dynamicCustomers = new ExpandoObject();
                dynamicCustomers.CusID = customer.CusID;
                dynamicCustomers.name = customer.name;
                dynamicCustomers.surname = customer.surname;

                dynamicCustomer.Add(dynamicCustomer); 
            }
         return (dynamicCustomer);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
