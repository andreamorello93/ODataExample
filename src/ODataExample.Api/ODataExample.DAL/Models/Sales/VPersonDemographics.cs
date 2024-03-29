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
    /// Displays the content from each element in the xml column Demographics for each customer in the Person.Person table.
    /// </summary>
    [Keyless]
    public partial class VPersonDemographics
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("TotalPurchaseYTD", TypeName = "money")]
        public decimal? TotalPurchaseYtd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateFirstPurchase { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [StringLength(1)]
        public string MaritalStatus { get; set; }
        [StringLength(30)]
        public string YearlyIncome { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        public int? TotalChildren { get; set; }
        public int? NumberChildrenAtHome { get; set; }
        [StringLength(30)]
        public string Education { get; set; }
        [StringLength(30)]
        public string Occupation { get; set; }
        public bool? HomeOwnerFlag { get; set; }
        public int? NumberCarsOwned { get; set; }
    }
}