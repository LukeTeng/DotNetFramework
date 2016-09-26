using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public class Student : CommonFields
    {
        [MinLength(1), MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(0), MaxLength(50)]
        public string SurName { get; set; }

        [Range(0, 100, ErrorMessage ="Age should be within the range between 0 and 100")]
        public int Age { get; set; }

    }
}
