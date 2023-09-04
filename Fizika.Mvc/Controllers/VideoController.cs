using Fizika.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        [Route("video")]
        [HttpGet]
        public async Task<IActionResult> Index(int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
                var result = await _videoService.GetAllByPage(pageSize,currentPage,isAscending);
                return View(result.Data);
        }
    }
}
