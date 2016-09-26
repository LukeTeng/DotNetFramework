using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Framework.Model
{
    public abstract class CommonFields : Entity, ICommonFields
    {
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }


    }
}
