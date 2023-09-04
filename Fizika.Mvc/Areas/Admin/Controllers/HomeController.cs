using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Fizika.Entities.Concrete;
using Fizika.Mvc.Areas.Admin.Models;
using Fizika.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IArticleService _articleService;
        private readonly UserManager<User> _userManager;

        public HomeController(ICommentService commentService, ICategoryService categoryService, IArticleService articleService, UserManager<User> userManager)
        {
            _commentService = commentService;
            _categoryService = categoryService;
            _articleService = articleService;
            _userManager = userManager;
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        public async Task<IActionResult> Index()
        {
            var categoriesCountResult = await _categoryService.CountByNonDeleted();
            var commentsCountResult = await _commentService.CountByNonDeleted();
            var articlesCountResult = await _articleService.CountByNonDeleted();
            var usersCount = await _userManager.Users.CountAsync();
            var articlesResult = await _articleService.GetAll();
            if (categoriesCountResult.ResultStatus==ResultStatus.Succes 
                && commentsCountResult.ResultStatus==ResultStatus.Succes
                && articlesCountResult.ResultStatus==ResultStatus.Succes
                && usersCount>-1
                && categoriesCountResult.ResultStatus==ResultStatus.Succes
                && articlesResult.ResultStatus==ResultStatus.Succes)
            {
                return View(new DashboardViewModel
                {
                    ArticleCount = articlesCountResult.Data,
                    CommentCount = commentsCountResult.Data,
                    CategoryCount = categoriesCountResult.Data,
                    UserCount = usersCount,
                    Articles = articlesResult.Data
                });
            }
            return NotFound();
        }
    }
}
