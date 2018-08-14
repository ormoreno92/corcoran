using System.Collections.Generic;
using System.Web.Http;
using Api.Models;
using System.Web.Http.Cors;
using Api.Logic;

namespace Api.App_Start
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PresidentsController : ApiController
    {
        private IPresident _pr;

        public PresidentsController(IPresident president)
        {
            _pr = president;
        }

        public List<Presidents> Get(bool desc = false)
        {
            return _pr.GetPresidents(desc);
        }
    }
}
