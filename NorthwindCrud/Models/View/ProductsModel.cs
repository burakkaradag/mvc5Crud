using NorthwindCrud.Models.Data;
using NorthwindCrud.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindCrud.Models.View
{
    public class ProductsModel
    {
        public List<ProductsDTO> plist { get; set; }
        public Products Products { get; set; }
        public List<SelectListItem> CategoriesDropdown { get; set; }
        public List<SelectListItem> SupplierDropdown { get; set; }
        public int ToplamSayfa { get; set; }
        public int GirilenSayfaNo { get; set; }
    }
}