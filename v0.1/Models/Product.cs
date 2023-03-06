using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace v0._1.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ProductTypeId { get; set; }

    public string ArticleNumber { get; set; } = null!;

    public string? Description { get; set; }

    private string? _image = null;
    public string? Image { get => _image; set => _image = value; }

    [NotMapped]
    public string? ImagePath
    {
        get => (_image == null) ?
            "..\\Resources\\picture.png" :
            $"..\\Resources{_image}";
    }

    public int? ProductionPersonCount { get; set; }

    public int? ProductionWorkshopNumber { get; set; }

    public decimal MinCostForAgent { get; set; }
    //Отмечате что этого свойства нет в этой таблице и не пытался брать из базы
    [NotMapped]
    public string Materials
    {
        get
        {
            //Создаёт абстрактную строку с расширенными функциями
            StringBuilder sb = new StringBuilder();
            //Append добавляет
            sb.Append("Материалы: ");
            //итерирует элементами в коллекции
            foreach (var pm in ProductMaterials)
                sb.Append($"{pm.Material.Title}, ");

            return ProductMaterials.Count == 0 ? "Материалов нет": sb.Remove(sb.Length - 2, 2).ToString();
        }
    }

    [NotMapped]
    public decimal Price
    {
        get
        {
            decimal price = 0;
            foreach (var pm in ProductMaterials)
                price += Convert.ToDecimal(pm.Count) * pm.Material.Cost;
            return price == 0 ? MinCostForAgent:price;

        }
    }


    public virtual ICollection<ProductCostHistory> ProductCostHistories { get; } = new List<ProductCostHistory>();

    public virtual ICollection<ProductMaterial> ProductMaterials { get; } = new List<ProductMaterial>();

    public virtual ICollection<ProductSale> ProductSales { get; } = new List<ProductSale>();

    public virtual ProductType? ProductType { get; set; }
}
