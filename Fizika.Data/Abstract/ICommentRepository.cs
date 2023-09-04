using Fizika.Shared.Data.Abstract;
using Fizika.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Data.Abstract
{
    public interface ICommentRepository:IEntityRepository<Comment>
    {
    }
}
