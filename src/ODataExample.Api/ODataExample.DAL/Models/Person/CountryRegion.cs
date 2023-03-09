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
    /// Lookup table containing the ISO standard codes for countries and regions.
    /// </summary>
    [Table("CountryRegion", Schema = "Person")]
    [Index("Name", Name = "AK_CountryRegion_Name", IsUnique = true)]
    public partial class CountryRegion
    {
        public CountryRegion()
        {
            CountryRegionCurrency = new HashSet<CountryRegionCurrency>();
            SalesTerritory = new HashSet<SalesTerritory>();
            StateProvince = new HashSet<StateProvince>();
        }

        /// <summary>
        /// ISO standard code for countries and regions.
        /// </summary>
        [Key]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        /// <summary>
        /// Country or region name.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("CountryRegionCodeNavigation")]
        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrency { get; set; }
        [InverseProperty("CountryRegionCodeNavigation")]
        public virtual ICollection<SalesTerritory> SalesTerritory { get; set; }
        [InverseProperty("CountryRegionCodeNavigation")]
        public virtual ICollection<StateProvince> StateProvince { get; set; }
    }
}