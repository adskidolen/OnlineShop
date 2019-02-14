using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepHome.Models;

namespace KeepHome.Web.ViewModels.Home
{
    public class SearchViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public string Text { get; set; }
    }
}
