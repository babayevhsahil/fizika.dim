using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using Fizika.Entities.Concrete;
using Fizika.Mvc.Areas.Admin.Models;
using Fizika.Shared.Utilities.Helpers.Abstract;
using Fizika.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OptionController : Controller
    {
        private readonly ChooseUsPageInfo _chooseUsPageInfo;
        private readonly IWritableOptions<ChooseUsPageInfo> _chooseUsPageInfoWriter;
        private readonly SliderPageInfo _sliderPageInfo;
        private readonly IWritableOptions<SliderPageInfo> _sliderPageInfoWriter;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;
        private readonly IToastNotification _toastNotification;
        private readonly WebsiteInfo _websiteInfo;
        private readonly IWritableOptions<WebsiteInfo> _websiteInfoWriter;
        private readonly SmtpSettings _smtpSettings;
        private readonly IWritableOptions<SmtpSettings> _smtpSettingsWriter;
        private readonly ArticleRightSideBarWidgetOptions _articleRightSideBarWidgetOptions;
        private readonly IWritableOptions<ArticleRightSideBarWidgetOptions> _articleRightSideBarWidgetOptionsWriter;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public OptionController(
            IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo,
            IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter,
            IOptionsSnapshot<SliderPageInfo> sliderPageInfo,
            IWritableOptions<SliderPageInfo> sliderPageInfoWriter,
            IOptionsSnapshot<ChooseUsPageInfo> chooseUsPageInfo,
            IWritableOptions<ChooseUsPageInfo> chooseUsPageInfoWriter,
            IToastNotification toastNotification, IOptionsSnapshot<WebsiteInfo> websiteInfo,
            IWritableOptions<WebsiteInfo> websiteInfoWriter, IOptionsSnapshot<SmtpSettings> smtpSettings,
            IWritableOptions<SmtpSettings> smtpSettingsWriter,
            IOptionsSnapshot<ArticleRightSideBarWidgetOptions> articleRightSideBarWidgetOptions,
            IWritableOptions<ArticleRightSideBarWidgetOptions> articleRightSideBarWidgetOptionsWriter,
            ICategoryService categoryService, IMapper mapper)
        {
            _chooseUsPageInfo = chooseUsPageInfo.Value;
            _chooseUsPageInfoWriter = chooseUsPageInfoWriter;
            _sliderPageInfo = sliderPageInfo.Value;
            _sliderPageInfoWriter = sliderPageInfoWriter;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
            _toastNotification = toastNotification;
            _websiteInfo = websiteInfo.Value;
            _websiteInfoWriter = websiteInfoWriter;
            _smtpSettings = smtpSettings.Value;
            _smtpSettingsWriter = smtpSettingsWriter;
            _articleRightSideBarWidgetOptions = articleRightSideBarWidgetOptions.Value;
            _articleRightSideBarWidgetOptionsWriter = articleRightSideBarWidgetOptionsWriter;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Slider()
        {
            return View(_sliderPageInfo);
        }
        [HttpPost]
        public IActionResult Slider(SliderPageInfo sliderPageInfo)
        {
            if (ModelState.IsValid)
            {
                _sliderPageInfoWriter.Update(x =>
                {
                    x.Header = sliderPageInfo.Header;
                    x.Content = sliderPageInfo.Content;
                });
                _toastNotification.AddSuccessToastMessage("Slider bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(sliderPageInfo);
            }
            return View(sliderPageInfo);
        }
        public IActionResult Choose()
        {
            return View(_chooseUsPageInfo);
        }
        [HttpPost]
        public IActionResult Choose(ChooseUsPageInfo chooseUsPageInfo)
        {
            if (ModelState.IsValid)
            {
                _chooseUsPageInfoWriter.Update(x =>
                {
                    x.Header = chooseUsPageInfo.Header;
                    x.ContentFirst = chooseUsPageInfo.ContentFirst;
                    x.ContentSecond = chooseUsPageInfo.ContentSecond;
                    x.ContentThird = chooseUsPageInfo.ContentThird;
                    x.ContentFourth = chooseUsPageInfo.ContentFourth;
                });
                _toastNotification.AddSuccessToastMessage("ChooseUs bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(chooseUsPageInfo);
            }
            return View(chooseUsPageInfo);
        }
        [HttpGet]
        public IActionResult About()
        {
            return View(_aboutUsPageInfo);
        }
        [HttpPost]
        public IActionResult About(AboutUsPageInfo aboutUsPageInfo)
        {
            if (ModelState.IsValid)
            {
                _aboutUsPageInfoWriter.Update(x =>
                {
                    x.Header = aboutUsPageInfo.Header;
                    x.Content = aboutUsPageInfo.Content;
                    x.SeoAuthor = aboutUsPageInfo.SeoAuthor;
                    x.SeoDescription = aboutUsPageInfo.SeoDescription;
                    x.SeoTags = aboutUsPageInfo.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Haqqında bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(aboutUsPageInfo);
            }
            return View(aboutUsPageInfo);
        }
        [HttpGet]
        public IActionResult GeneralSettings()
        {
            return View(_websiteInfo);
        }
        [HttpPost]
        public IActionResult GeneralSettings(WebsiteInfo websiteInfo)
        {
            if (ModelState.IsValid)
            {
                _websiteInfoWriter.Update(x =>
                {
                    x.Title = websiteInfo.Title;
                    x.MenuTitle = websiteInfo.MenuTitle;
                    x.SeoAuthor = websiteInfo.SeoAuthor;
                    x.SeoDescription = websiteInfo.SeoDescription;
                    x.SeoTags = websiteInfo.SeoTags;
                    x.Facebook = websiteInfo.Facebook;
                    x.Instagram = websiteInfo.Instagram;
                    x.Youtube = websiteInfo.Youtube;
                    x.Whatsapp = websiteInfo.Whatsapp;
                });
                _toastNotification.AddSuccessToastMessage("Esas emeliyyatlar bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(websiteInfo);
            }
            return View(websiteInfo);
        }
        [HttpGet]
        public IActionResult EmailSettings()
        {
            return View(_smtpSettings);
        }
        [HttpPost]
        public IActionResult EmailSettings(SmtpSettings smtpSettings)
        {
            if (ModelState.IsValid)
            {
                _smtpSettingsWriter.Update(x =>
                {
                    x.Server = smtpSettings.Server;
                    x.Port = smtpSettings.Port;
                    x.SenderEmail = smtpSettings.SenderEmail;
                    x.SenderName = smtpSettings.SenderName;
                    x.Username = smtpSettings.Username;
                    x.Password = smtpSettings.Password;
                });
                _toastNotification.AddSuccessToastMessage("Saytin Email(Smtp) emeliyyatlar bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(smtpSettings);
            }
            return View(smtpSettings);
        }

        [HttpGet]
        public async Task<IActionResult> ArticleRightSideBarWidgetSettings(int categoryId)
        {
            var categoriesResult = await _categoryService.GetAllByNonDeleteAndActive();
            var articleRightSiderBarWidgetOptionsViewModel = _mapper.Map<ArticleRightSideBarWidgetOptionsViewModel>(_articleRightSideBarWidgetOptions);
            articleRightSiderBarWidgetOptionsViewModel.Categories = categoriesResult.Data.Categories;
            return View(articleRightSiderBarWidgetOptionsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ArticleRightSideBarWidgetSettings(ArticleRightSideBarWidgetOptionsViewModel articleRightSideBarWidgetOptions)
        {
            if (ModelState.IsValid)
            {
                var categoriesResult = await _categoryService.GetAllByNonDeleteAndActive();
                articleRightSideBarWidgetOptions.Categories = categoriesResult.Data.Categories;
                _articleRightSideBarWidgetOptionsWriter.Update(x =>
                {
                    x.Header = articleRightSideBarWidgetOptions.Header;
                    x.CategoryId = articleRightSideBarWidgetOptions.CategoryId;
                    x.TakeSize = articleRightSideBarWidgetOptions.TakeSize;
                    x.FilterBy = articleRightSideBarWidgetOptions.FilterBy;
                    x.OrderBy = articleRightSideBarWidgetOptions.OrderBy;
                    x.IsAscending = articleRightSideBarWidgetOptions.IsAscending;
                    x.StartAt = articleRightSideBarWidgetOptions.StartAt;
                    x.EndAt = articleRightSideBarWidgetOptions.EndAt;
                    x.MaxViewCount = articleRightSideBarWidgetOptions.MaxViewCount;
                    x.MinViewCount = articleRightSideBarWidgetOptions.MinViewCount;
                    x.MaxCommentCount = articleRightSideBarWidgetOptions.MaxCommentCount;
                    x.MinCommentCount = articleRightSideBarWidgetOptions.MinCommentCount;
                });
                _toastNotification.AddSuccessToastMessage("Meqale sehifesinin widget emeliyyatlar bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(articleRightSideBarWidgetOptions);
            }
            return View(articleRightSideBarWidgetOptions);
        }
    }
}
