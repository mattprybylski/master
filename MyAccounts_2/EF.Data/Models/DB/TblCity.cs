﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace EF.Data.Models.DB
{
    public partial class TblCity
    {
        public int Id { get; set; }
        public int StateProvinceId { get; set; }
        public string Name { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}