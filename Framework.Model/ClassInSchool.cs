using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Framework.Model
{
    public class ClassInSchool :CommonFields
    {
        [MinLength(5), MaxLength(50)]
        public string ClassName { get; set; }

        [Range(0, 20, ErrorMessage = "Age should be within the range between 0 and 20")]
        public int YearGrade { get; set; }
    }
}
