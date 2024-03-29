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
    /// Joins StateProvince table with CountryRegion table.
    /// </summary>
    [Keyless]
    public partial class VStateProvinceCountryRegion
    {
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [Required]
        [StringLength(3)]
        public string StateProvinceCode { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }
        [Required]
        [StringLength(50)]
        public string StateProvinceName { get; set; }
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Required]
        [StringLength(50)]
        public string CountryRegionName { get; set; }
    }
}