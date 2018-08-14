using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Logic
{
    public interface IPresident
    {
        List<Presidents> GetPresidents(bool desc);
    }
}
