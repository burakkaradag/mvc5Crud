using NorthwindCrud.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindCrud.Models.View
{
    public class CategoriesModel
    {
        public List<Categories> clist { get; set; }
        public Categories categories { get; set; }
    }
}