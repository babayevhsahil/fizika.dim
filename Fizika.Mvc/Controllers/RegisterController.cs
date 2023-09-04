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
    public class RegisterController : Controller
    {
        private readonly IRegisterService _RegisterService;

        public RegisterController(IRegisterService RegisterService)
        {
            _RegisterService = RegisterService;
        }
        [HttpPost]
        public async Task<JsonResult> Add(RegisterAddDto RegisterAddDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _RegisterService.Add(RegisterAddDto,"Nihad");
                    if (result.ResultStatus == ResultStatus.Succes)
                    {
                        var RegisterAddAjaxViewModel = JsonSerializer.Serialize(new RegisterAddAjaxViewModel
                        {
                            RegisterDto = result.Data,
                            RegisterAddPartial = await this.RenderViewToStringAsync("_RegisterAddPartial", RegisterAddDto),
                        }, new JsonSerializerOptions
                        {
                            ReferenceHandler = ReferenceHandler.Preserve
                        });
                        return Json(RegisterAddAjaxViewModel);
                    }
                    ModelState.AddModelError("", result.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }

            }
            var RegisterAddAjaxErrorViewModel = JsonSerializer.Serialize(new RegisterAddAjaxViewModel
            {
                RegisterAddDto = RegisterAddDto,
                RegisterAddPartial = await this.RenderViewToStringAsync("_RegisterAddPartial", RegisterAddDto),
            });
            return Json(RegisterAddAjaxErrorViewModel);
        }
    }
}
