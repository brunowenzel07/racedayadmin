using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RaceData.Dal.DataManagers;
using RaceData.Dal.DTO;
using RaceData.Dal.POCO;
using RaceData.Models.Models;
using RaceData.Service;

namespace RaceData.Web.Controllers
{
    public class HorsesController : Controller
    {
        public ActionResult _Horses()
        {
            return View();
        }
        public JsonResult ReadHorse([DataSourceRequest] DataSourceRequest request)
        {
            List<HorseModel> horseModels = SessionService.DbContainer.Resolve<HorseDataManager>().GetByCountryFromView(SessionService.CurrentCountry).Select(Mapper.Map<vwvHorse, HorseModel>).ToList();
            return Json(horseModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateHorse([DataSourceRequest] DataSourceRequest request, HorseModel horse)
        {
            if (horse != null)
            {
                var newHorse = Mapper.Map<HorseModel, Horse>(horse);
                SessionService.DbContainer.Resolve<HorseDataManager>().Insert(newHorse);
            }
            SessionService.HorseFlag = true;
            return Json(new[] { horse }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult UpdateHorse([DataSourceRequest] DataSourceRequest request, HorseModel horse)
        {
            if (horse != null)
            {
                var upHorse = Mapper.Map<HorseModel, Horse>(horse);
                var horseDataManager = SessionService.DbContainer.Resolve<HorseDataManager>();

                horseDataManager.Update(upHorse);
            }
            SessionService.HorseFlag = true;
            return Json(new[] { horse }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult DeleteHorse([DataSourceRequest] DataSourceRequest request, HorseModel horse)
        {
            if (horse != null)
            {
                var upHorse = Mapper.Map<HorseModel, Horse>(horse);
                var horseDataManager = SessionService.DbContainer.Resolve<HorseDataManager>();

                horseDataManager.Delete(upHorse);
            }
            SessionService.HorseFlag = true;
            return Json(new[] { horse }.ToDataSourceResult(request, ModelState));
        }

        
        [HttpPost]
        public ActionResult Index(HorseSearchModel model)
        {
            if (ModelState.IsValid)
            {
                List<Horse> horseModels = SessionService.DbContainer.Resolve<HorseDataManager>().GetByCountry(model.CountryId);
                model.HorseModels = horseModels;
                SessionService.CurrentCountry = model.CountryId;
            }
            return View(model);
        }

        public ActionResult Index()
        {
            return View("Index", new HorseSearchModel());
        }
    }
}
