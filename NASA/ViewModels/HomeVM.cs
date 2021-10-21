using NASA.Models;
using System;
using System.Threading.Tasks;

namespace NASA.ViewModels
{
    public class HomeVM : BaseVM
    {
        public HomeModel HomeModel { get; set; }

        public HomeVM()
        {
            HomeModel = new();
            initDB();
        }

        private async void initDB()
        {
            await Task.Run(() => HomeModel.InitDB());
        }
    }
}
