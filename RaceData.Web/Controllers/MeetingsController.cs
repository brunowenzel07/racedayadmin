using System;
using System.Web.Mvc;
using Autofac;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RaceData.Dal.DataManagers;
using RaceData.Dal.POCO;
using RaceData.Models.Models;
using RaceData.Service;
using RaceData.Web.Models;

namespace RaceData.Web.Controllers
{
    
    public class MeetingsController : Controller
    {
        //
        // GET: /MeetingsModel/

        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                return RedirectToAction("Login", "Account");
            }
            var meetingsSearchModel = SessionService.RestoreSearchModel;
            if (meetingsSearchModel != null)
            {
                Search(meetingsSearchModel);
                SessionService.RestoreSearchModel = null;
                return View(meetingsSearchModel);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(MeetingsSearchModel searchModel)
        {
            if (ModelState.IsValid && !(searchModel.IsCreateNew??false))
            {
                Search(searchModel);
            }

            return View(searchModel);
        }

        private void Search(MeetingsSearchModel searchModel)
        {
            searchModel.SearchResult = SessionService.DbContainer.Resolve<MeetingDataManager>()
                .SearchMeetings(Convert.ToInt32(searchModel.Country), searchModel.Racecourse, searchModel.StartDate,
                    searchModel.EndDate);

            SessionService.SearchModel = searchModel;
        }

        public JsonResult GetCountrys()
        {
            return Json(SessionService.Countries, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRacecourse(int? racecourse)
        {
            var racecourseData = SessionService.DbContainer.Resolve<RacecourseDataManager>().GetByCountry(racecourse);
            return Json(racecourseData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetWeather()
        {
            var weathers = SessionService.DbContainer.Resolve<WeatherDataManager>().GetAll();
            return Json(weathers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGoing()
        {
            var going = SessionService.DbContainer.Resolve<GoingDataManager>().GetAll();
            return Json(going, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMGridDataSource([DataSourceRequest] DataSourceRequest request)
        {
            var meetings = SessionService.SearchModel;
            return meetings!=null?Json(meetings.SearchResult.ToDataSourceResult(request), JsonRequestBehavior.AllowGet):null;
        }

        public PartialViewResult EmptyResult()
        {
            return PartialView("_EmptyResult", Mapper.Map<MeetingsModel>(SessionService.SearchModel));
        }
        [HttpPost]
        public PartialViewResult NewMeeting(MeetingsModel model)
        {
            if (ModelState.IsValid)
            {
                Meeting newEntity = Mapper.Map<MeetingsModel, Meeting>(model);
                var meetingDataManager = SessionService.DbContainer.Resolve<MeetingDataManager>();
                if (meetingDataManager.SearchDuplication(newEntity))
                {
                    ModelState.AddModelError("", "Meeting exist.");
                }
                else if (meetingDataManager.Insert(newEntity))
                {
                    ViewBag.WndClose = true;
                    SessionService.RestoreSearchModel = Mapper.Map<MeetingsModel, MeetingsSearchModel>(model);
                    SessionService.RestoreSearchModel.StartDate = SessionService.SearchModel.StartDate;

                }
            }
            return PartialView("_EmptyResult", model);;

        }

        public ViewResult MeetingDetails(int id)
        {
            Meeting meeting = SessionService.DbContainer.Resolve<MeetingDataManager>().GetById(id);
            var model = new MeetingsDetailsModel();

            model.MeetingId = id;

            Country country = SessionService.DbContainer.Resolve<CountrysDataManager>().GetById(meeting.CountryId);
            model.CountryCode =country==null?"":country.Code;

            RaceCourse raceCourse = SessionService.DbContainer.Resolve<RacecourseDataManager>().GetById(meeting.RaceCourseId);
            model.RaceCourseCode = raceCourse==null?"":raceCourse.Code; ;

            model.Date = meeting.MeetingDate.ToShortDateString();

            Weather weather = SessionService.DbContainer.Resolve<WeatherDataManager>().GetById(meeting.WeatherId);
            model.WeatherName = weather == null?"":weather.Name;

            Going going = SessionService.DbContainer.Resolve<GoingDataManager>().GetById(meeting.DefaultGoingId);
            model.GoingName = going==null?"":going.Name;

            model.DayNight = model.CountryCode.Contains("HK")?((meeting.HK_isNightMeet!=null && (bool) meeting.HK_isNightMeet)?MeetingType.nigth.ToString():MeetingType.day.ToString()):string.Empty;

            CourseVariant courseVariant = SessionService.DbContainer.Resolve<CourseVariantDataManager>().GetById(meeting.CourseVariantId);
            model.CourseVariantName = courseVariant==null?"":courseVariant.Name;

            model.NumberOfRaces = SessionService.DbContainer.Resolve<MeetingDataManager>().GetById(id).NumberOfRaces;
            model.Races = SessionService.DbContainer.Resolve<RaceDataManager>().GetByMeetingId(id);

            return View("Details", model);
        }
    }
}
