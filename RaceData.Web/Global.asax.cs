using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Autofac;
using AutoMapper;
using Kendo.Mvc.UI;
using RaceData.Dal.Core;
using RaceData.Dal.DataManagers;
using RaceData.Dal.DTO;
using RaceData.Dal.POCO;
using RaceData.Models.Models;
using RaceData.Service;
using RaceData.Web.Models;

namespace RaceData.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            InitMap();

        }

        private void InitMap()
        {
            Mapper.CreateMap<MeetingsSearchModel, MeetingsModel>()
                .ForMember(dest=>dest.CountryId, opt=>opt.MapFrom(src=>Convert.ToInt32(src.Country)))
                .ForMember(dest=>dest.RacecourseId, opt=>opt.MapFrom(src=>Convert.ToInt32(src.Racecourse)))
                .ForMember(dest=>dest.MeetingDate, opt=>opt.MapFrom(src=>src.StartDate))
                .ForMember(dest=>dest.CountryCode, opt=>opt.MapFrom(src=>SessionService.DbContainer.Resolve<CountrysDataManager>().GetById(Convert.ToInt32(src.Country)).Code))
                .ForMember(dest=>dest.Racecourse, opt=>opt.MapFrom(src=>SessionService.DbContainer.Resolve<RacecourseDataManager>().GetById(Convert.ToInt32(src.Racecourse)).Code));

            Mapper.CreateMap<MeetingsModel, Meeting>()
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.RaceCourseId, opt => opt.MapFrom(src => src.RacecourseId))
                .ForMember(dest => dest.WeatherId, opt => opt.MapFrom(src => Convert.ToInt32(src.Weather)))
                .ForMember(dest => dest.DefaultGoingId, opt => opt.MapFrom(src => Convert.ToInt32(src.Going)))
                .ForMember(dest => dest.NumberOfRaces, opt => opt.MapFrom(src => src.RaceNumber))
                .ForMember(dest => dest.MeetingDate, opt => opt.MapFrom(src => src.MeetingDate))
                .ForMember(dest => dest.HK_isNightMeet,opt => opt.MapFrom(src => src.MeetingType == MeetingType.nigth.ToString()));

            Mapper.CreateMap<MeetingsModel, MeetingsSearchModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.CountryId.ToString()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.MeetingDate))
                .ForMember(dest => dest.Racecourse, opt => opt.MapFrom(src => src.RacecourseId.ToString()));

            Mapper.CreateMap<Race, RaceDetailsModel>()
                .ForMember(dest=>dest.RaceType, opt=>opt.MapFrom(src=>src.RaceTypeId))
                .ForMember(dest=>dest.Distance, opt=>opt.MapFrom(src=>src.DistanceId))
                .ForMember(dest => dest.RaceWinningTime, opt => opt.MapFrom(src=>src.RaceWinningTime))
                .ForMember(dest=>dest.NumberOfRunners, opt=>opt.MapFrom(src=>src.NumberOfRunners))
                .ForMember(dest=>dest.RaceJumpTimeHour, opt=>opt.MapFrom(src=>(src.RaceJumpDateTimeUTC!=null?((DateTime)src.RaceJumpDateTimeUTC).Hour:0)))
                .ForMember(dest=>dest.RaceJumpTimeMin, opt=>opt.MapFrom(src=>(src.RaceJumpDateTimeUTC!=null?((DateTime)src.RaceJumpDateTimeUTC).Minute:0)))
                .ForMember(dest=>dest.Id, opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dest=>dest.HK_RaceIndex, opt=>opt.MapFrom(src=>src.HK_RaceIndex))
                .ForMember(dest=>dest.IsStarted, opt=>opt.MapFrom(src=>src.isStarted))
                .ForMember(dest=>dest.IsDone, opt=>opt.MapFrom(src=>src.isDone))
                .ForMember(dest=>dest.RaceName, opt=>opt.MapFrom(src=>src.RaceName));

            Mapper.CreateMap<RaceDetailsModel, Race>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MeetingId, opt => opt.MapFrom(src => src.MeetingId))
                .ForMember(dest => dest.NumberOfRunners, opt => opt.MapFrom(src => src.NumberOfRunners))
                .ForMember(dest => dest.RaceNumber, opt => opt.MapFrom(src => src.RaceNumber))
                .ForMember(dest => dest.RaceTypeId, opt => opt.MapFrom(src => src.RaceType))
                .ForMember(dest => dest.RaceWinningTime, opt => opt.MapFrom(src => src.RaceWinningTime.ToString()))
                .ForMember(dest => dest.DistanceId, opt => opt.MapFrom(src => src.Distance))
                .ForMember(dest => dest.RaceName, opt => opt.MapFrom(src => src.RaceName))
                .ForMember(dest => dest.HK_RaceIndex, opt => opt.MapFrom(src => src.HK_RaceIndex))
                .ForMember(dest => dest.isStarted, opt => opt.MapFrom(src => src.IsStarted))
                .ForMember(dest => dest.isDone, opt => opt.MapFrom(src => src.IsDone))
                .ForMember(dest => dest.isTurf, opt => opt.MapFrom(src => src.Weather == "turf"));

            Mapper.CreateMap<DTORaceType, RaceType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => SessionService.DbContainer.Resolve<CountrysDataManager>().GetCountryIdByName(src.Country.Name)));

            Mapper.CreateMap<Country, DTOCountry>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

       
            Mapper.CreateMap<HorseOdd, HorseOddModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.HorseId, opt => opt.MapFrom(src => src.HorseId))
                .ForMember(dest => dest.HorseNumber, opt => opt.MapFrom(src => src.HorseNumber))
                .ForMember(dest => dest.WinOdds, opt => opt.MapFrom(src => src.WinOdds))
                .ForMember(dest => dest.RaceId, opt => opt.MapFrom(src => src.RaceId))
                .ForMember(dest => dest.HorseName, opt => opt.MapFrom(src => SessionService.Horse.Where(w => w.Id == src.HorseId).FirstOrDefault().Name));

            Mapper.CreateMap<HorseOddModel, HorseOdd>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.HorseId, opt => opt.MapFrom(src => src.HorseId))
                .ForMember(dest => dest.RaceId, opt => opt.MapFrom(src => src.RaceId))
                .ForMember(dest => dest.HorseNumber, opt => opt.MapFrom(src => src.HorseNumber))
                .ForMember(dest => dest.WinOdds, opt => opt.MapFrom(src => src.WinOdds));

            Mapper.CreateMap<vwvRunner, DTORunner>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RaceId, opt => opt.MapFrom(src => src.RaceId))
                .ForMember(dest => dest.HorseNumber, opt => opt.MapFrom(src => src.HorseNumber))
                .ForMember(dest => dest.Barrier, opt => opt.MapFrom(src => src.Barrier))
                .ForMember(dest => dest.AUS_HcpWt, opt => opt.MapFrom(src => src.AUS_HcpWt))
                .ForMember(dest => dest.HK_ActualWtLbs, opt => opt.MapFrom(src => src.HK_ActualWtLbs))
                .ForMember(dest => dest.HK_DeclaredHorseWtLbs, opt => opt.MapFrom(src => src.HK_DeclaredHorseWtLbs))
                .ForMember(dest => dest.AUS_HcpRatingAtJump, opt => opt.MapFrom(src => src.AUS_HcpRatingAtJump))
                .ForMember(dest => dest.HK_Rating, opt => opt.MapFrom(src => src.HK_Rating))
                .ForMember(dest => dest.AUS_BM, opt => opt.MapFrom(src => src.AUS_BM))
                .ForMember(dest => dest.HK_LBW, opt => opt.MapFrom(src => src.HK_LBW))
                .ForMember(dest => dest.HK_LBW, opt => opt.MapFrom(src => src.HK_LBW))
                .ForMember(dest => dest.HK_FinishTime, opt => opt.MapFrom(src => src.HK_FinishTime))
                .ForMember(dest => dest.AUS_SPW, opt => opt.MapFrom(src => src.AUS_SPW))
                .ForMember(dest => dest.AUS_SPP, opt => opt.MapFrom(src => src.AUS_SPP))
                .ForMember(dest => dest.HK_WinOdds, opt => opt.MapFrom(src => src.HK_WinOdds))
                .ForMember(dest => dest.RP2000, opt => opt.MapFrom(src => src.RP2000))
                .ForMember(dest => dest.RP1600, opt => opt.MapFrom(src => src.RP1600))
                .ForMember(dest => dest.RP1200, opt => opt.MapFrom(src => src.RP1200))
                .ForMember(dest => dest.RP800, opt => opt.MapFrom(src => src.RP800))
                .ForMember(dest => dest.RP400, opt => opt.MapFrom(src => src.RP400))
                .ForMember(dest => dest.AUS_RP200, opt => opt.MapFrom(src => src.AUS_RP200))
                .ForMember(dest => dest.Z_AUS_FinishTime, opt => opt.MapFrom(src => src.Z_AUS_FinishTime))
                .ForMember(dest => dest.Z_newTrainerSinceLastStart,opt => opt.MapFrom(src => src.Z_newTrainerSinceLastStart))
                .ForMember(dest => dest.Z_WinOddsRank, opt => opt.MapFrom(src => src.Z_WinOddsRank))
                .ForMember(dest => dest.Z_BPAdvFactor, opt => opt.MapFrom(src => src.Z_BPAdvFactor))
                .ForMember(dest => dest.isScratched, opt => opt.MapFrom(src => src.isScratched))
                .ForMember(dest => dest.CarriedWt, opt => opt.MapFrom(src => src.CarriedWt))
                .ForMember(dest => dest.CarriedWt, opt => opt.MapFrom(src => src.CarriedWt))
                .ForMember(dest => dest.Gear,opt => opt.MapFrom(src => new DTOGear() {Id = src.GearId, Name = src.Gear}))
                .ForMember(dest => dest.Horse,opt => opt.MapFrom(src => new DTOHorse() {Id = src.HorseId, Name = src.HorseName}))
                .ForMember(dest => dest.Trainer,opt => opt.MapFrom(src => new DTOTrainer() {Id = src.TrainerId, Name = src.TrainerName}))
                .ForMember(dest => dest.Jockey,opt => opt.MapFrom(src => new DTOJockey() {Id = src.JockeyId, Name = src.JockeyName}));

            Mapper.CreateMap<DTORunner, Runner>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.RaceId, opt => opt.MapFrom(src => src.RaceId))
               .ForMember(dest => dest.HorseNumber, opt => opt.MapFrom(src => src.HorseNumber))
               .ForMember(dest => dest.Barrier, opt => opt.MapFrom(src => src.Barrier))
               .ForMember(dest => dest.AUS_HcpWt, opt => opt.MapFrom(src => src.AUS_HcpWt))
               .ForMember(dest => dest.HK_ActualWtLbs, opt => opt.MapFrom(src => src.HK_ActualWtLbs))
               .ForMember(dest => dest.HK_DeclaredHorseWtLbs, opt => opt.MapFrom(src => src.HK_DeclaredHorseWtLbs))
               .ForMember(dest => dest.AUS_HcpRatingAtJump, opt => opt.MapFrom(src => src.AUS_HcpRatingAtJump))
               .ForMember(dest => dest.HK_Rating, opt => opt.MapFrom(src => src.HK_Rating))
               .ForMember(dest => dest.AUS_BM, opt => opt.MapFrom(src => src.AUS_BM))
               .ForMember(dest => dest.HK_LBW, opt => opt.MapFrom(src => src.HK_LBW))
               .ForMember(dest => dest.HK_LBW, opt => opt.MapFrom(src => src.HK_LBW))
               .ForMember(dest => dest.HK_FinishTime, opt => opt.MapFrom(src => src.HK_FinishTime))
               .ForMember(dest => dest.AUS_SPW, opt => opt.MapFrom(src => src.AUS_SPW))
               .ForMember(dest => dest.AUS_SPP, opt => opt.MapFrom(src => src.AUS_SPP))
               .ForMember(dest => dest.HK_WinOdds, opt => opt.MapFrom(src => src.HK_WinOdds))
               .ForMember(dest => dest.RP2000, opt => opt.MapFrom(src => src.RP2000))
               .ForMember(dest => dest.RP1600, opt => opt.MapFrom(src => src.RP1600))
               .ForMember(dest => dest.RP1200, opt => opt.MapFrom(src => src.RP1200))
               .ForMember(dest => dest.RP800, opt => opt.MapFrom(src => src.RP800))
               .ForMember(dest => dest.RP400, opt => opt.MapFrom(src => src.RP400))
               .ForMember(dest => dest.AUS_RP200, opt => opt.MapFrom(src => src.AUS_RP200))
               .ForMember(dest => dest.Z_AUS_FinishTime, opt => opt.MapFrom(src => src.Z_AUS_FinishTime))
               .ForMember(dest => dest.Z_newTrainerSinceLastStart, opt => opt.MapFrom(src => src.Z_newTrainerSinceLastStart))
               .ForMember(dest => dest.Z_WinOddsRank, opt => opt.MapFrom(src => src.Z_WinOddsRank))
               .ForMember(dest => dest.Z_BPAdvFactor, opt => opt.MapFrom(src => src.Z_BPAdvFactor))
               .ForMember(dest => dest.isScratched, opt => opt.MapFrom(src => src.isScratched))
               .ForMember(dest => dest.CarriedWt, opt => opt.MapFrom(src => src.CarriedWt))
               .ForMember(dest => dest.CarriedWt, opt => opt.MapFrom(src => src.CarriedWt))
               .ForMember(dest => dest.GearId, opt => opt.MapFrom(src => src.Gear.Id))
               .ForMember(dest => dest.HorseId, opt => opt.MapFrom(src => src.Horse.Id))
               .ForMember(dest => dest.TrainerId, opt => opt.MapFrom(src => src.Trainer.Id))
               .ForMember(dest => dest.JockeyId, opt => opt.MapFrom(src =>src.Jockey.Id));

            Mapper.CreateMap<Horse, HorseGridDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PreviousName, opt => opt.MapFrom(src => src.PreviousName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            Mapper.CreateMap<Jockey, DTOJockey>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Fullname));

            Mapper.CreateMap<Trainer, DTOTrainer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Fullname));

           Mapper.CreateMap<vwvHorse, HorseModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CountryOfOrigin, opt => opt.MapFrom(src => new DTOCountryOfOrigin(){ Id = src.CountryOfOriginId, Name = src.CountryOfOrigin }))
                .ForMember(dest => dest.HK_ChineseName, opt =>opt.MapFrom(src => src.HK_ChineseName))
                .ForMember(dest => dest.HK_BrandNumber, opt =>opt.MapFrom(src => src.HK_BrandNumber))
                .ForMember(dest => dest.SG_hasBled, opt =>opt.MapFrom(src => src.SG_hasBled))
                .ForMember(dest => dest.Sex, opt =>opt.MapFrom(src => new DTOSex(){Id=src.SexId, Name = src.Sex}))
                .ForMember(dest => dest.CoatColor, opt =>opt.MapFrom(src => new DTOColor(){Id=src.CoatColorId, Name = src.CoatColor}))
                .ForMember(dest => dest.DateOfBirth, opt =>opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.SireName, opt =>opt.MapFrom(src => src.SireName))
                .ForMember(dest => dest.DamName, opt =>opt.MapFrom(src => src.DamName))
                .ForMember(dest => dest.IsActive, opt =>opt.MapFrom(src => src.isActive))
                .ForMember(dest => dest.Z_MaxHcpRating, opt =>opt.MapFrom(src => src.Z_MaxHcpRating))
                .ForMember(dest => dest.Z_CurrentHcpRating, opt =>opt.MapFrom(src => src.Z_CurrentHcpRating))
                .ForMember(dest => dest.Z_StartSeasonHcpRating, opt =>opt.MapFrom(src => src.Z_StartSeasonHcpRating))
                .ForMember(dest => dest.CountryOfRegistration, opt =>opt.MapFrom(src => new DTOCountry(){Id =src.CountryOfRegistrationId, Name = src.CountryOfRegistration}));

            Mapper.CreateMap<HorseModel, Horse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DamName, opt => opt.MapFrom(src => src.DamName))
                .ForMember(dest => dest.CountryOfOriginId, opt => opt.MapFrom(src => src.CountryOfOrigin.Id))
                .ForMember(dest => dest.CountryOfRegistrationId, opt => opt.MapFrom(src => src.CountryOfRegistration.Id))
                .ForMember(dest => dest.HK_ChineseName, opt => opt.MapFrom(src => src.HK_ChineseName))
                .ForMember(dest => dest.HK_BrandNumber, opt => opt.MapFrom(src => src.HK_BrandNumber))
                .ForMember(dest => dest.SG_hasBled, opt => opt.MapFrom(src => src.SG_hasBled))
                .ForMember(dest => dest.SexId, opt => opt.MapFrom(src => src.Sex.Id))
                .ForMember(dest => dest.CoatColorId, opt => opt.MapFrom(src => src.CoatColor.Id))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.SireName, opt => opt.MapFrom(src => src.SireName))
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Z_CurrentHcpRating, opt => opt.MapFrom(src => src.Z_CurrentHcpRating))
                .ForMember(dest => dest.Z_MaxHcpRating, opt => opt.MapFrom(src => src.Z_MaxHcpRating))
                .ForMember(dest => dest.Z_StartSeasonHcpRating, opt => opt.MapFrom(src => src.Z_StartSeasonHcpRating))
                .ForMember(dest => dest.CountryOfRegistrationId, opt => opt.MapFrom(src => src.CountryOfRegistration.Id));

             Mapper.CreateMap<vwvJockey, JockeyModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.isApprentice, opt => opt.MapFrom(src => src.isApprentice))
                .ForMember(dest => dest.CountryOfOrigin, opt => opt.MapFrom(src =>new DTOCountryOfOrigin(){Id = src.CountryOfOriginId, Name = src.CountryOfOrigin}))
                .ForMember(dest => dest.CountryOfRegistration, opt => opt.MapFrom(src =>new DTOCountryOfRegistration(){Id = src.CountryOfRegistrationId, Name = src.CountryOfRegistration}));

             Mapper.CreateMap<JockeyModel, Jockey>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                 .ForMember(dest => dest.isApprentice, opt => opt.MapFrom(src => src.isApprentice))
                 .ForMember(dest => dest.CountryOfOriginId, opt => opt.MapFrom(src => src.CountryOfOrigin.Id))
                 .ForMember(dest => dest.CountryOfRegistrationId, opt => opt.MapFrom(src =>src.CountryOfRegistration.Id));

            Mapper.CreateMap<vwvTrainer, TrainerModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Fullname))
                .ForMember(dest => dest.HomeTrack, opt => opt.MapFrom(src => new DTORaceCourse() {Id = src.Id, Name = src.HomeTrack}));

            Mapper.CreateMap<TrainerModel, Trainer>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.FullName))
               .ForMember(dest => dest.HomeTrackId, opt => opt.MapFrom(src =>src.HomeTrack.Id));

            Mapper.CreateMap<DTORaceType2, DTORaceType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Country,opt => opt.MapFrom(src => new DTOCountry() {Id = src.CountryId, Name = src.CountryName}))
                .ForMember(dest => dest.IsGroup, opt => opt.MapFrom(src => src.IsGroup))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            InitializeDataLayer();
            
        }

        protected void InitializeDataLayer()
        {

            var container = new ContainerBuilder();
            container.Register(c => new DbConnection()).SingleInstance();
            container.Register(c => new CountrysDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            //container.Register(c => new CityDataManager(c.Resolve<RDEntities>())).InstancePerLifetimeScope();
            container.Register(c => new MeetingDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new RacecourseDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new WeatherDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new GoingDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new RaceDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new CourseVariantDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new RunnerDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new RaceTypeDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new DistanceDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new HorseDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new HorseODDDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new vwvRunnerDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new TrainerDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new JockeyDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new GearDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new SexDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
            container.Register(c => new CoatColorDataManager(c.Resolve<DbConnection>())).InstancePerLifetimeScope();
           
            SessionService.DbContainer = container.Build();
        }

        public override void Init()
        {
            this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(
                SessionStateBehavior.Required);
        }
    }
}