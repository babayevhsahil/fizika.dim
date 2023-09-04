using AutoMapper;
using Fizika.Entities.Concrete;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using Fizika.Services.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RegistersController : Controller
    {
        private readonly IRegisterService _registerService;
        public RegistersController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _registerService.GetAll();
            return View(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int registerId)
        {
            var result = await _registerService.Get(registerId);
            if (result.ResultStatus == ResultStatus.Succes)
            {
                return PartialView("_RegisterDetailPartial", result.Data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int registerId)
        {
            var result = await _registerService.HardDelete(registerId);
            var HardDeletedRegister = JsonSerializer.Serialize(result);
            return Json(HardDeletedRegister);
        }
    }
}
