using ODataExample.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataExample.Application.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    public virtual ProductModel ProductModel { get; set; }
}