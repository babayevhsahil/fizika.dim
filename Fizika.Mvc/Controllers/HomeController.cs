using Fizika.Data.Abstract.UnitOfWorks;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Mvc.Models;
using Fizika.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Fizika.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly SliderPageInfo _sliderPageInfo;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly ChooseUsPageInfo _chooseUsPageInfo;
        private readonly IExamService _examService;
        private readonly IArticleService _articleService;
        private readonly IStudentsService _studentsService;
        private readonly IRegisterService _registerService;
        private readonly IToastNotification _toastNotification;
        private readonly IMailService _mailService;
        private readonly IVideoService _videoService;
        public HomeController(IOptionsSnapshot<SliderPageInfo> sliderPageInfo
            , IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo,
            IOptionsSnapshot<ChooseUsPageInfo> chooseUsPageInfo,
            IExamService examService,
            IArticleService articleService,
            IStudentsService studentsService,
            IRegisterService registerService,
            IMailService mailService,
            IToastNotification toastNotification,
            IVideoService videoService)
        {
            _sliderPageInfo = sliderPageInfo.Value;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _chooseUsPageInfo = chooseUsPageInfo.Value;
            _examService = examService;
            _articleService = articleService;
            _studentsService = studentsService;
            _registerService = registerService;
            _mailService = mailService;
            _toastNotification = toastNotification;
            _videoService = videoService;
        }
        [Route("/sitemap.xml")]
        public void SitemapXml()
        {
            string host = Request.Scheme + "://" + Request.Host;

            Response.ContentType = "application/xml";

            using (var xml = XmlWriter.Create(Response.Body, new XmlWriterSettings { Indent = true }))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                xml.WriteStartElement("url");
                xml.WriteElementString("loc", host);
                xml.WriteEndElement();

                xml.WriteEndElement();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exams = await _examService.GetAllByPaging(null, 1, 8, false);
            var articles = await _articleService.GetAllByPaging(null, 1, 3, false);
            var students = await _studentsService.GetAllBySize(5, false);
            var videos = await _videoService.GetAllByPage(3, 1, false);

            return View(new HomeViewModel
            {
                ExamListDto = exams.Data,
                ArticleListDto = articles.Data,
                StudentsListDto = students.Data,
                VideoListDto=videos.Data
            });
        }
        [Route("Haqqimda")]
        [HttpGet]
        public async Task<IActionResult> About()
        {
            var studentresult = await _studentsService.GetAllByNonDeleteAndActive();
            return View(new AboutViewModel
            {
                StudentsListDto = studentresult.Data,
                aboutUsPageInfo = _aboutUsPageInfo,
                chooseUsPageInfo = _chooseUsPageInfo
            });
        }

        [Route("Elaqe")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Elaqe")]
        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat",
                    CloseButton = true,
                    ProgressBar = true,
                    HideDuration = 4
                });
                return View();
            }
            return View(emailSendDto);
        }
    }
}
