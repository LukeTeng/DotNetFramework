using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Model;

namespace Framework.Service
{
    public class ClassService : EntityService<ClassInSchool>, IClassService
    {
        IContext _context;

        public ClassService(IContext context)
            : base(context)
        {
            _context = context;
        }

    }
}
