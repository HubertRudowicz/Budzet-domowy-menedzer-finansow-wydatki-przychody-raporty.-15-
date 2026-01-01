using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekttest.Models
{
    public interface IExportable
    {
        string GetCSVFormat();
    }
}
