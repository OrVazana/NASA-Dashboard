using NASA.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.BL.Interfaces
{
    public interface IBL
    {
        Task<TodayPhoto> getTodayPhoto();
        Planet getSelectedPlanet(string name);
    }
}
