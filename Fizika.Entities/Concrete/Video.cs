using Fizika.Shared.Entities.Abstract;
using Fizika.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.Concrete
{
    public class Video : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Thumbnail { get; set; }
    }
}
