using Api.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Api.Logic
{
    public class President : IPresident
    {
        public string Path
        {
            get
            {
                return HttpContext.Current.Request.MapPath("~\\presidents.json");
            }
        }

        public List<Presidents> GetPresidents(bool desc)
        {
            var presidentsContent = File.ReadAllText(Path);
            var presidents = JsonConvert.DeserializeObject<List<Presidents>>(presidentsContent);
            presidents = desc ? presidents.OrderByDescending(x => x.President).ToList() : presidents.OrderBy(x => x.President).ToList();
            return presidents;
        }
    }
}