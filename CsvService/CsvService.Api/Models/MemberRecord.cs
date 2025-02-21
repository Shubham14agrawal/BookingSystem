using System;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace CsvService.Api.Models
{
    public class MemberRecord
    {
        [Name("Name")]
        [Required]
        public string Name { get; set; }

        [Name("Surname")]
        [Required]
        public string Surname { get; set; }

        [Name("DateJoined")]
        [Required]
        public DateTime DateJoined { get; set; }
    }
}
