using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Persons_list
{
    public class Persons
    {
        [Key] 
        public int id { get; set; } 
        public string lastname { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;

    }
}
