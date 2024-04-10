﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Learing_Core.DTO
{
    public class CarDto
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string? Name { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Price $")]
        public int Price { get; set; }

        [Required]
        [DisplayName("Car model")]
        public string? Car_Model { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        public string? ContactNumbr { get; set; }

        [DisplayName("Company")]
        public int? CompanyId { get; set; }

        [DisplayName("Gallery")]
        public int? GalleryId { get; set; }

        [DisplayName("Rental Length")]
        public int? RentalCarId { get; set; }
        public byte[]? CarImage1 { get; set; }
        public byte[]? CarImage2 { get; set; }
        public byte[]? CarImage3 { get; set; }
    }
}