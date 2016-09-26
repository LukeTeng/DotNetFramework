using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Model;

namespace Framework.Service
{
    public interface IStudentService : IEntityService<Student>
    {
        // custom services other than common services could be listed here 
        // bool AddStudentWithClass(Student student, ClassInSchool studentClass);
    }
}
