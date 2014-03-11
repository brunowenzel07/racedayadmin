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
using RaceData.Dal.POCO;
using RaceData.Models.Models;
using RaceData.Service;

namespace RaceData.Web.Controllers
{
    public class JockeyController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", new JockeySearchModel());
        }
        [HttpPost]
        public ActionResult Index(JockeySearchModel model)
        {
            if (ModelState.IsValid)
            {
                List<vwvJockey> byCountryId = SessionService.DbContainer.Resolve<JockeyDataManager>().GetByCountryId(model.CountryId);
                model.JockeyModels = byCountryId;
                SessionService.CurrentCountry = model.CountryId;
            }
            return View("Index", model);
        }

        public JsonResult ReadJockey([DataSourceRequest] DataSourceRequest request)
        {
            List<JockeyModel> jockeyModels = SessionService.DbContainer.Resolve<JockeyDataManager>().GetByCountryId(SessionService.CurrentCountry).Select(Mapper.Map<vwvJockey, JockeyModel>).ToList();
            return Json(jockeyModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateJockey([DataSourceRequest] DataSourceRequest request, JockeyModel model)
        {
            if (model != null)
            {
                var newJockey = Mapper.Map<JockeyModel, Jockey>(model);
                SessionService.DbContainer.Resolve<JockeyDataManager>().Insert(newJockey);
            }
            SessionService.JokeysFlag = true;
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult UpdateJockey([DataSourceRequest] DataSourceRequest request, JockeyModel model)
        {
            if (model != null)
            {
                var upJockey = Mapper.Map<JockeyModel, Jockey>(model);
                var horseDataManager = SessionService.DbContainer.Resolve<JockeyDataManager>();

                horseDataManager.Update(upJockey);
            }
            SessionService.JokeysFlag = true;
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult DeleteJockey([DataSourceRequest] DataSourceRequest request, JockeyModel model)
        {
            if (model != null)
            {
                var upJockey = Mapper.Map<JockeyModel, Jockey>(model);
                var jockeyDataManager = SessionService.DbContainer.Resolve<JockeyDataManager>();

                jockeyDataManager.Delete(upJockey);
            }
            SessionService.JokeysFlag = true;
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}