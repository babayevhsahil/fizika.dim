using Fizika.Shared.Entities.Abstract;
using Fizika.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.Concrete
{
    public class Students: EntityBase, IEntity
    {
        public string Fullname { get; set; }
        public string Point { get; set; }
        public string PointPhysic { get; set; }
        public string University { get; set; }
        public string Photo { get; set; }
    }
}
