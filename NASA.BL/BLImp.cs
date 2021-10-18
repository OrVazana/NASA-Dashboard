using NASA.BE;
using NASA.BL.Interfaces;
using NASA.DAL;
using NASA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.BL
{
    public class BLImp : IBL
    {
        public IRepository IRepository { get; set; }

        public BLImp()
        {
            IRepository = new Repository();
        }


        #region fetch from db
        public Task<TodayPhoto> getTodayPhoto()
        {
            return IRepository.GetTodayPhoto();
        }

        public Task<List<Item>> GetLibrarySearchResult(string search)
        {
            return IRepository.GetLibrarySearchResult(search);
        }

        public Planet getSelectedPlanet(string name)
        {
            return IRepository.getSelectedPlanet(name);
        }

        public Task<List<Asteroid>> GetAsteroidsFilteredResult()
        {
            return IRepository.GetAsteroidsFilteredResult();
        }


        #endregion
    }
}
