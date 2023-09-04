using Fizika.Entities.Concrete;
using Fizika.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Data.Abstract
{
    public interface IStudentsRepository:IEntityRepository<Students>
    {
    }
}
