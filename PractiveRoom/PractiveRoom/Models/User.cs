﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PractiveRoom.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiveRoom.Models
{
    [Table("student")]
    public class User
    {
        [Required]
        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(50)]
        public string username { get; set; }
        [Required]
        [StringLength(20)]
        public string password { get; set; }
        [Required]
        [StringLength(100)]
        public string fullname { get; set; }
        [Required]
        public bool isActive { get; set; }
        public ICollection<StudentSchedule> studentCalenders { get; set; }
    }
}
