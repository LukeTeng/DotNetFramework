using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Model;

namespace Framework.Service
{
    public class StudentService : EntityService<Student>, IStudentService
    {
        IContext _context;
        public StudentService(IContext context)
            : base(context)
        {
            _context = context;
            _dbset = _context.Set<Student>();
        }

         

    }
}
