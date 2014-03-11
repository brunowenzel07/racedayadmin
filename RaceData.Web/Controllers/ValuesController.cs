using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using RaceData.Dal.DataManagers;
using RaceData.Dal.POCO;
using RaceData.Service;

namespace RaceData.Web
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       [HttpGet]
        public string GetCountry(int id)
       {
           Country country = SessionService.DbContainer.Resolve<CountrysDataManager>().GetById(id);
           return country==null?"":country.Name;
       }

       [HttpGet]
       public string GetGear(int? id)
        {
            string result = string.Empty;
            if (id != null)
            {
                Gear gear = SessionService.DbContainer.Resolve<GearDataManager>().GetById(id);
                result = gear == null ? "" : gear.Name;
            } 
            
            return result;
        }

        [HttpGet]
        public string GetHorse(int? id)
        {
            string result = string.Empty;
            if (id != null)
            {
                Horse horse = SessionService.DbContainer.Resolve<HorseDataManager>().GetById(id);
                result = horse == null ? "" : horse.Name;
            }

            return result;
        }

        [HttpGet]
        public string GetJockey(int? id)
        {
            string result = string.Empty;
            if (id != null)
            {
                Jockey jockey= SessionService.DbContainer.Resolve<JockeyDataManager>().GetById(id);
                result = jockey == null ? "" : jockey.Fullname;
            }

            return result;
        }

        [HttpGet]
        public string GetTariner(int? id)
        {
            string result = string.Empty;
            if (id != null)
            {
                Trainer trainer = SessionService.DbContainer.Resolve<TrainerDataManager>().GetById(id);
                result = trainer == null ? "" : trainer.Fullname;
            }

            return result;
        }
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}