using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QA.Services;

namespace QA.Areas.MasterData.Controllers
{
    [Area("MasterData")]
    [Route("MasterData/[controller]/[action]")]
    public class MasterController : Controller
    {
        private readonly IMasterData _masterData;
        public MasterController(IMasterData masterdata)
        {
            this._masterData = masterdata;
        }
        public IActionResult Index()
        {
            var masData = _masterData.GetAllMasterData();
            return View(masData);
        }
    }
}