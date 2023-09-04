using Fizika.Shared.Entities.Abstract;
using Fizika.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.Concrete
{
    public class Business:EntityBase
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Students { get; set; }
        public string Lectures { get; set; }
        public string Language { get; set; }
        public string Price { get; set; }
        public string Link { get; set; }
    }
}
