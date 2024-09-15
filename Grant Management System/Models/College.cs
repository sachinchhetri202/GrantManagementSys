using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Grant_Management_System.Models
{
    public class College
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Dean { get; set; }

    }
}
