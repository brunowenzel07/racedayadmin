using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public class TrainerController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ReadTrainer([DataSourceRequest] DataSourceRequest request)
        {
            List<TrainerModel> trainerModels = SessionService.DbContainer.Resolve<TrainerDataManager>().GetAllFromView().Select(Mapper.Map<vwvTrainer, TrainerModel>).ToList();
            return Json(trainerModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateTrainer([DataSourceRequest] DataSourceRequest request, TrainerModel model)
        {
            if (model != null)
            {
                var newTrainer = Mapper.Map<TrainerModel, Trainer>(model);
                SessionService.DbContainer.Resolve<TrainerDataManager>().Insert(newTrainer);
            }

            SessionService.TrainerFlag = true;
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult UpdateTrainer([DataSourceRequest] DataSourceRequest request, TrainerModel model)
        {
            if (model != null)
            {
                var upTrainer = Mapper.Map<TrainerModel, Trainer>(model);
                var trainerDataManager = SessionService.DbContainer.Resolve<TrainerDataManager>();

                trainerDataManager.Update(upTrainer);
            }
            SessionService.TrainerFlag = true;
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult DeleteTrainer([DataSourceRequest] DataSourceRequest request, TrainerModel model)
        {
            if (model != null)
            {
                var upTrainer = Mapper.Map<TrainerModel, Trainer>(model);
                var trainerDataManager = SessionService.DbContainer.Resolve<TrainerDataManager>();

                SessionService.TrainerFlag = true;
                trainerDataManager.Delete(upTrainer);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}