using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeBall.BL.Interfaces
{
    public interface IFindMatchItem
    {
        List<int> FindLinkLocations(List<string> links, string url);
    }
}
