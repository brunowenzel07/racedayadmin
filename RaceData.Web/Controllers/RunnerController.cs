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
    public class RunnerController : Controller
    {
        public JsonResult GetRunners([DataSourceRequest] DataSourceRequest request)
        {
            List<vwvRunner> byRaceId =
                SessionService.DbContainer.Resolve<vwvRunnerDataManager>().GetByRaceId(SessionService.CurrentRaceId);
            List<DTORunner> dtoRunners = byRaceId.Select(Mapper.Map<DTORunner>).ToList();
            return Json(dtoRunners.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateRunner([DataSourceRequest] DataSourceRequest request, DTORunner runner)
        {
            if (runner != null)
            {
                var upRunner = Mapper.Map<DTORunner, Runner>(runner);
                var runnerDataManager = SessionService.DbContainer.Resolve<RunnerDataManager>();

                runnerDataManager.Update(upRunner);
            }

            return Json(new[] {runner}.ToDataSourceResult(request, ModelState));
        }

        public ActionResult DeleteRunner([DataSourceRequest] DataSourceRequest request, DTORunner runner)
        {
            if (runner != null)
            {
                var upRunner = Mapper.Map<DTORunner, Runner>(runner);
                var horseDataManager = SessionService.DbContainer.Resolve<RunnerDataManager>();

                horseDataManager.Delete(upRunner);
            }

            return Json(new[] {runner}.ToDataSourceResult(request, ModelState));
        }
    }
}