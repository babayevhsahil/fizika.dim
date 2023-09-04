using Fizika.Shared.Entities.Abstract;
using Fizika.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.Concrete
{
    public class Register : EntityBase, IEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
    }
}
