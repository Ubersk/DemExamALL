using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v0._1.Models;

namespace v0._1.ViewModels
{
    public class BaseWindowViewModel : ViewModelbase
    {
        public BaseWindowViewModel()
        {
            using (var DB = new DemVarContext())
            {
                //Здесь берутся данные из базы данных. 
                Products = DB.Products
                    .Include(p => p.ProductMaterials).ThenInclude(pm => pm.Material)
                    .Include(pv => pv.ProductType)
                    .ToList();
                AllProducts = Products;
            }
        }
        //Поле где хранятся данные. Хранит то что нужно отображать
        private List<Product>? _products;

        //Свойства для доступа к полю
        public List<Product> Products 
        { 
            get { return _products; } 
            set { Set(ref _products, value, nameof(Products));} 
        }

        //Создание сортировки
        private int _selectedSort = 0;

        public int SelectedSort
        {
            get { return _selectedSort; }
            set { Set(ref _selectedSort, value, nameof(SelectedSort)); }
        }

        //Создаем фильтрацию
        private int _filterProperty = 0;

        public int FilterProperty
        {
            get { return _filterProperty; }
            set { Set(ref _filterProperty, value, nameof(FilterProperty)); }
        }

        //В нём полностью сохранится список продуктов. Используется для фильтрации и сортировки.
        private List<Product>? _allproducts;
        public List<Product> AllProducts
        {
            get { return _allproducts; }
            set { Set(ref _allproducts, value, nameof(AllProducts)); }
        }
        //
        private string _searchProperty = "";
        public string SearchProperty
        {
            get { return _searchProperty; }
            set { Set(ref _searchProperty, value, nameof(SearchProperty)); }
        }
        //Set проверяет изменилось ли значение. Проверяет кидаются ли новые данные. Уведомляет об изменениях значений. Обычный set ничего не меняетю - просто кидает данные. 


        public List<Product> Filter(List<Product> list)
        {
            switch (FilterProperty)
            {
                default: return list;
                    break;
                case 1:
                    return list.Where(p => p.ProductTypeId == 1).ToList();
                    break;
                case 2:
                    return list.Where(p => p.ProductTypeId == 2).ToList();
                    break;
                case 3:
                    return list.Where(p => p.ProductTypeId == 3).ToList();
                    break;
                case 4:
                    return list.Where(p => p.ProductTypeId == 4).ToList();
                    break;

            }
        }

        public List<Product> Sort(List<Product> list)
        {
            switch (SelectedSort)
            {
                default: return list;
                    break;
                case 1: 
                    return list.OrderByDescending(p => p.Price).ToList();
                    break;
                case 2:
                    return list.OrderBy(p => p.Price).ToList();
                    break;
                case 3:
                    return list.OrderByDescending(p => p.Title).ToList();
                    break;
                case 4:
                    return list.OrderBy(p => p.Title).ToList();
                    break;
            }
        }
        //Метод поиска
        public List<Product> Search(List<Product> list)
        {
            //Contains - Проверяет содержит ли название продукта из листа значение введеное в текстблок. Проверяет содержится ли в вызывающей строке(Title) передаваемая строка(SearchProperty).
            return SearchProperty == "" ? list : list.Where(p => p.Title.ToLower().Contains(SearchProperty.ToLower())).ToList();
        }

        public void MainAction()
        {
            Products = Sort(Search(Filter(AllProducts)));
        }
    }
}
