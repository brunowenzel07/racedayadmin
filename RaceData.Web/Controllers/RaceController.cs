using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
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
    public class RaceController : Controller
    {
        //
        // GET: /Race/

        public PartialViewResult RaceDetails(int? id, int tabid)
        {
            var detailsModel = new RaceDetailsModel
                               {
                                   RaceNumber = tabid,
                                   MeetingId = SessionService.CurrentMeetingId
                               };
            if (id > 0)
            {
                detailsModel =
                    Mapper.Map<RaceDetailsModel>(SessionService.DbContainer.Resolve<RaceDataManager>().GetById(id));
                detailsModel.Runners = SessionService.DbContainer.Resolve<RunnerDataManager>().GetByRaceId(id);
             
            }

         
            //RestoreConfiguration();


            SessionService.CurrentRaceId = id;

            return PartialView("_RaceDetails", detailsModel);
        }

        private void RestoreConfiguration()
        {
            MemoryStream encModel;
            var serializer = new XmlSerializer(typeof (TabAllModel));
            HttpCookie httpCookie = Request.Cookies[SessionService.RuleDisplay];
            if (httpCookie != null)
            {
                encModel = new MemoryStream(Convert.FromBase64String(httpCookie.Value));
                SessionService.RuleOfDisplaying = serializer.Deserialize(encModel) as TabAllModel;
            }
            else
            {
                var tabAllModel = new TabAllModel(true);
                encModel = new MemoryStream();
                serializer.Serialize(encModel, tabAllModel);
                string base64String = Convert.ToBase64String(encModel.ToArray());
                var cookie = new HttpCookie(SessionService.RuleDisplay)
                             {
                                 Value = base64String,
                                 Expires = DateTime.Now.AddYears(1)
                             };
                Request.Cookies.Add(cookie);
                SessionService.RuleOfDisplaying = tabAllModel;
            }
        }

        [HttpPost]
        public PartialViewResult Update(RaceDetailsModel model)
        {
            var manager = SessionService.DbContainer.Resolve<RaceDataManager>();
            var entity = Mapper.Map<RaceDetailsModel, Race>(model);
            DateTime dateTime = DateTime.Now;
            entity.RaceJumpDateTimeUTC = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, model.RaceJumpTimeHour, model.RaceJumpTimeMin,0,0);
            
            if (model.Id == 0)
            {
                manager.Insert(entity);
            }
            else
            {
                manager.Update(entity);
            }
            SessionService.CurrentTab = model.RaceNumber-1;
            
            return PartialView("_RaceDetails", model);
        }
        public JsonResult GetRaceType()
        {
            List<RaceType> byCountryId = SessionService.DbContainer.Resolve<RaceTypeDataManager>().GetByCountryId(Convert.ToInt32(SessionService.SearchModel.Country));
            return Json(byCountryId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistance()
        {
            return Json(SessionService.Distances, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGoing()
        {
            List<Going> going = SessionService.DbContainer.Resolve<GoingDataManager>().GetAll();
            return Json(going, JsonRequestBehavior.AllowGet);
        }
      
        public JsonResult ReadRT([DataSourceRequest] DataSourceRequest request)
        {
            var raceType = SessionService.DbContainer.Resolve<RaceTypeDataManager>();
            List<DTORaceType> raceTypes = raceType.GetAllDto(Convert.ToInt32(SessionService.SearchModel.Country)).Select(Mapper.Map<DTORaceType2, DTORaceType>).ToList();
            return Json(raceTypes.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult CreateRT([DataSourceRequest] DataSourceRequest request, DTORaceType raceType)
        {
            if (raceType != null && ModelState.IsValid)
            {
                SessionService.DbContainer.Resolve<RaceTypeDataManager>().Insert(Mapper.Map<DTORaceType, RaceType>(raceType));
            }

            return Json(new[] { raceType }.ToDataSourceResult(request, ModelState));
        }

     
        public ActionResult UpdateRT([DataSourceRequest] DataSourceRequest request, DTORaceType raceType)
        {
            if (raceType != null && ModelState.IsValid)
            {
                SessionService.DbContainer.Resolve<RaceTypeDataManager>().Update(Mapper.Map<DTORaceType, RaceType>(raceType));
            }

            return Json(new[] { raceType }.ToDataSourceResult(request, ModelState));
        }

       
        public ActionResult DestroyRT([DataSourceRequest] DataSourceRequest request, DTORaceType raceType)
        {
            if (raceType != null)
            {
                SessionService.DbContainer.Resolve<RaceTypeDataManager>().Delete(Mapper.Map<DTORaceType, RaceType>(raceType));
            }

            return Json(new[] { raceType }.ToDataSourceResult(request, ModelState));
        }

        public PartialViewResult RaceType()
        {
            return PartialView("_RaceType");
        }

        public JsonResult ReadH([DataSourceRequest] DataSourceRequest request)
        {
            List<HorseOdd> byRaceId = SessionService.DbContainer.Resolve<HorseODDDataManager>().GetByRaceId(SessionService.CurrentRaceId);
            List<HorseOddModel> horseOddModels = byRaceId.Select(Mapper.Map<HorseOdd, HorseOddModel>).ToList();

            return Json(horseOddModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateH([DataSourceRequest] DataSourceRequest request, HorseOddModel horseOddModel)
        {
            if (horseOddModel != null && ModelState.IsValid)
            {
                HorseOdd newEntity = Mapper.Map<HorseOddModel, HorseOdd>(horseOddModel);
                newEntity.CurrentTime = DateTime.Now;
                newEntity.RaceId = SessionService.CurrentRaceId;

                SessionService.DbContainer.Resolve<HorseODDDataManager>().Insert(newEntity);
                horseOddModel.HorseName = SessionService.Horse.Where(w => w.Id == horseOddModel.HorseId).FirstOrDefault().Name;
            }

            return Json(new[] { horseOddModel }.ToDataSourceResult(request, ModelState));
        }


        public ActionResult UpdateH([DataSourceRequest] DataSourceRequest request, HorseOddModel horseOddModel)
        {
            if (horseOddModel != null && ModelState.IsValid)
            {
                horseOddModel.HorseName =
                    SessionService.Horse.Where(w => w.Id == horseOddModel.HorseId).FirstOrDefault().Name;
                HorseOdd horseOdd = Mapper.Map<HorseOddModel, HorseOdd>(horseOddModel);
                SessionService.DbContainer.Resolve<HorseODDDataManager>().Update(horseOdd);
            }

            return Json(new[] { horseOddModel }.ToDataSourceResult(request, ModelState));
        }

        public PartialViewResult TabAll()
        {
            RestoreConfiguration();
            return PartialView("_TabAll", SessionService.RuleOfDisplaying);
        }

        public RedirectToRouteResult SaveSelection(TabAllModel model)
        {
            SessionService.RuleOfDisplaying = model;

            var serializer = new XmlSerializer(typeof (TabAllModel));
            var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, model);
            string sModel = Convert.ToBase64String(memoryStream.ToArray());
            
            Response.Cookies.Remove(SessionService.RuleDisplay);

            var cookie = new HttpCookie(SessionService.RuleDisplay, sModel) {Expires = DateTime.Now.AddYears(10)};
            Response.Cookies.Add(cookie);

            SessionService.CurrentTab = 1;
            return RedirectToAction("MeetingDetails","Meetings", new{@id=SessionService.CurrentMeetingId});
        }
    }
}
