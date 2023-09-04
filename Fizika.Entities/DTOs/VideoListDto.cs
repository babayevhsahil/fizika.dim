using Fizika.Entities.Concrete;
using Fizika.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class VideoListDto:DtoGetBase
    {
        public IList<Video> Videos { get; set; }
    }
}
