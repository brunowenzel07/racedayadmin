using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Autofac;
using RaceData.Dal.DataManagers;
using RaceData.Dal.POCO;
using RaceData.Models.Models;
using RaceData.Web.Models;

namespace RaceData.Service
{
    public class SessionService
    {

        private const string ContainerName = "SESSION_CONTAINER";

        public static SessionService GetService
        {
            get
            {
                HttpSessionState session = HttpContext.Current.Session;
                if (session[ContainerName] == null)
                {
                    session[ContainerName] = new SessionService();
                }

                return session[ContainerName] as SessionService;
            }
        }

        private IContainer _dbContainer;

        public static IContainer DbContainer
        {
            get { return GetService._dbContainer; }
            set { GetService._dbContainer = value; }
        }

        private MeetingsSearchModel _meetingsSearchModel;

        public static MeetingsSearchModel SearchModel
        {
            get { return GetService._meetingsSearchModel; }
            set { GetService._meetingsSearchModel = value; }
        }
        private MeetingsSearchModel _restoreSearchModel;

        public static MeetingsSearchModel RestoreSearchModel
        {
            get { return GetService._restoreSearchModel; }
            set { GetService._restoreSearchModel = value; }
        }

        private int _meetingId;
        public static int CurrentMeetingId
        {
            get { return GetService._meetingId; }
            set { GetService._meetingId = value; }
        }

        private int _currentTab;
        public static int CurrentTab
        {
            get { return GetService._currentTab; }
            set { GetService._currentTab = value; }
        }

        private List<Country> _countries; 
        public static List<Country> Countries
        {
            get
            { 
                return GetService._countries ?? (GetService._countries=GetService._dbContainer.Resolve<CountrysDataManager>().GetAll());
            }
        }

        private List<Sex> _sexs;
        public static List<Sex> Sex
        {
            get { return GetService._sexs??(GetService._sexs=GetService._dbContainer.Resolve<SexDataManager>().GetAll().OrderBy(m=>m.Name).ToList()); }
        }

        private List<CoatColor> _coatColors;
        public static List<CoatColor> CoatColors
        {
            get { return GetService._coatColors??(GetService._coatColors=GetService._dbContainer.Resolve<CoatColorDataManager>().GetAll().OrderBy(m => m.Name).ToList()); }
        }

        private List<RaceCourse> _raceCourses; 
        public static List<RaceCourse> RaceCourses
        {
            get { return GetService._raceCourses??(GetService._raceCourses=GetService._dbContainer.Resolve<RacecourseDataManager>().GetAll().ToList()); }
        }

        private bool _horseFlag = false;
        public static bool HorseFlag
        {
            get { return GetService._horseFlag; }
            set { GetService._horseFlag = value; }
        }
        private  List<Horse> _horse;
        public static List<Horse> Horse
        {
            get 
            {
                if (GetService._horseFlag || GetService._horse == null)
                {
                   GetService._horse = GetService._dbContainer.Resolve<HorseDataManager>().GetAll();
                   GetService._horseFlag = false;
                }
                  return   GetService._horse;
            }
        }

        private bool _jokeysFlag = false;
        public static bool JokeysFlag
        {
            get { return GetService._jokeysFlag; }
            set { GetService._jokeysFlag = value; }
        }

        private List<Jockey> _jockeys; 
        public static List<Jockey> Jokeys
        {
            get
            {
                if (GetService._jokeysFlag || GetService._jockeys == null)
                {
                    GetService._jockeys = GetService._dbContainer.Resolve<JockeyDataManager>().GetAll();
                    GetService._jokeysFlag = false;
                }

                return GetService._jockeys;
            }
        }


        private bool _trainerFlag = false;
        public static bool TrainerFlag
        {
            get { return GetService._jokeysFlag; }
            set { GetService._jokeysFlag = value; }
        }


        private List<Trainer> _trainers;
        public static List<Trainer> Trainer
        {
            get
            {
                if (GetService._trainerFlag || GetService._trainers == null)
                {
                    GetService._trainers = GetService._dbContainer.Resolve<TrainerDataManager>().GetAll();
                    GetService._trainerFlag = false;
                }

                return GetService._trainers;
            }
        }

        private bool _raceTypeFlag = false;
        public static bool RaceTypeFlag
        {
            get { return GetService._raceTypeFlag; }
            set { GetService._raceTypeFlag = value; }
        }

        private List<RaceType> _raceTypes;
        public static List<RaceType> RaceTypes
        {
            get
            {
                if (GetService._raceTypeFlag || GetService._raceTypes == null)
                {
                    GetService._raceTypes = GetService._dbContainer.Resolve<RaceTypeDataManager>().GetAll();
                    GetService._raceTypeFlag = false;
                }

                return GetService._raceTypes;
            }
        }

        private List<Distance> _distances;
        public static List<Distance> Distances
        {
            get
            {
                return GetService._distances?? (GetService._distances = DbContainer.Resolve<DistanceDataManager>().GetAll());
            }
        }

        private List<Gear> _gears; 
        public static List<Gear> Gear
        {
            get
            {
                return GetService._gears??(GetService._gears=GetService._dbContainer.Resolve<GearDataManager>().GetAll());
            }
        } 

        private int? _currentRaceId = 0;
        public static int? CurrentRaceId
        {
            get { return GetService._currentRaceId; }
            set { GetService._currentRaceId = value; }
        }

        private TabAllModel _ruleOfDisplaying;
        public static TabAllModel RuleOfDisplaying
        {
            get { return GetService._ruleOfDisplaying; }
            set { GetService._ruleOfDisplaying = value; }
        }

        private string _ruleDisplay = "RDRaces";

        public static string RuleDisplay
        {
            get { return GetService._ruleDisplay; }
        }


        private int? _totalRace = 0;
        public static int? TotalRace
        {
            get { return GetService._totalRace; }
            set { GetService._totalRace = value; }
        }

        private int? _currentCountry = 0;

        public static int? CurrentCountry
        {
            get { return GetService._currentCountry; }
            set { GetService._currentCountry = value; }
        }

        public static dynamic Gender
        {
            get { return new List<dynamic>() {new {GenderName = "M"}, new {GenderName = "F"}}; }
        }
    }
}
