using ODataExample.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataExample.Application.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string ProductNumber { get; set; }
    public bool MakeFlag { get; set; }
    public bool FinishedGoodsFlag { get; set; }
    public short SafetyStockLevel { get; set; }
    public short ReorderPoint { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public int DaysToManufacture { get; set; }
    public DateTime SellStartDate { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }
    public virtual ProductModel ProductModel { get; set; }
}