using Fizika.Entities.DTOs;
using Fizika.Mvc.Models;
using Fizika.Services.Abstract;
using Fizika.Shared.Utilities.Extensions;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fizika.Mvc.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public async Task<JsonResult> Add(CommentAddDto commentAddDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _commentService.Add(commentAddDto);
                    if (result.ResultStatus == ResultStatus.Succes)
                    {
                        var commentAddAjaxViewModel = JsonSerializer.Serialize(new CommendAddAjaxViewModel
                        {
                            CommentDto = result.Data,
                            CommentAddPartial = await this.RenderViewToStringAsync("_CommentAddPartial", commentAddDto),
                        }, new JsonSerializerOptions
                        {
                            ReferenceHandler = ReferenceHandler.Preserve
                        });
                        return Json(commentAddAjaxViewModel);
                    }
                    ModelState.AddModelError("", result.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }

            }
            var commentAddAjaxErrorViewModel = JsonSerializer.Serialize(new CommendAddAjaxViewModel
            {
                CommentAddDto = commentAddDto,
                CommentAddPartial = await this.RenderViewToStringAsync("_CommentAddPartial", commentAddDto),
            });
            return Json(commentAddAjaxErrorViewModel);
        }
    }
}
