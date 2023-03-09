﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ODataExample.DAL.Models
{
    /// <summary>
    /// High-level product categorization.
    /// </summary>
    [Table("ProductCategory", Schema = "Production")]
    [Index("Name", Name = "AK_ProductCategory_Name", IsUnique = true)]
    [Index("Rowguid", Name = "AK_ProductCategory_rowguid", IsUnique = true)]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductSubcategory = new HashSet<ProductSubcategory>();
        }

        /// <summary>
        /// Primary key for ProductCategory records.
        /// </summary>
        [Key]
        [Column("ProductCategoryID")]
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Category description.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("ProductCategory")]
        public virtual ICollection<ProductSubcategory> ProductSubcategory { get; set; }
    }
}