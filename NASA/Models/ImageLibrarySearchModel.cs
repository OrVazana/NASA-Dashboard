﻿using NASA.BE;
using NASA.BL;
using NASA.BL.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NASA.Models
{
    public class ImageLibrarySearchModel 
    {
        public IBL BL { get; set; }

        public ImageLibrarySearchModel()
        {
            BL = new BLImp();
        }
        public ObservableCollection<libraryImage> GetLibrarySearchResult(string search)
        {
            return new ObservableCollection<libraryImage>(BL.GetLibrarySearchResult(search).Result);
        }
    }
}