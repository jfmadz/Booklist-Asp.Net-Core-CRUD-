using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booklist.Model
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Cannot be blank")]
        //[Display(Name ="Name of Book")]
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }


    }
}
