using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v0._2.Models;

namespace v0._2.ViewModel
{
    public class BaseWindowViewModel : ViewModelBase
    {
        public BaseWindowViewModel()
        {
            using (var DB = new DemVarContext())
            {
                Products = DB.Products
                    .Include(p => p.ProductMaterials).ThenInclude(pm => pm.Material)
                    .Include(pv => pv.ProductType)
                    .ToList();
            }
        }
        private List<Product>? _products;
        public List<Product> Products
        {
            get { return _products; }
            set { Set(ref _products, value, nameof(Products)); }
        } 
    }

}
