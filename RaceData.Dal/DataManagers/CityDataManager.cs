using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.Core;

namespace RaceData.Dal.DataManagers
{
    public class CityDataManager : BaseDataManager<RaceCity>
    {
        public CityDataManager(RDEntities entities)
        {
        }

        public override RaceCity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<RaceCity> GetByCountry(int? countryId)
        {
           return _entities.RaceCities.Where(w => w.CountryId == countryId).ToList()??new List<RaceCity>();
        } 
    }
}
