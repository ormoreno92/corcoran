using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Api.Models;
using System.Web.Http.Cors;

namespace Api.App_Start
{
    public class PresidentsController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Presidents> Get(bool desc = false)
        {
            var presidentsContent = File.ReadAllText(HttpContext.Current.Request.MapPath("~\\presidents.json"));
            var presidents = JsonConvert.DeserializeObject<List<Presidents>>(presidentsContent);
            presidents = desc ? presidents.OrderByDescending(x => x.President).ToList() : presidents.OrderBy(x => x.President).ToList();
            return presidents;
        }
    }
}
