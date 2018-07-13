using Microsoft.EntityFrameworkCore;
using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStoreApplicationLibrary.Repos_and_Mapper
{
    public class LocationRepo
    {
        private readonly Project1PizzaApplicationContext _db;

        public LocationRepo(Project1PizzaApplicationContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<StoreLocation> GetLocations()
        {
            List<StoreLocation> locations = _db.StoreLocation.AsNoTracking().ToList();
            return locations;
        }

        public Location GetLocationByCityname(string name)
        {
            return Mapper.Map(_db.StoreLocation.AsNoTracking().First(l => l.CityName.ToLower().Equals(name.ToLower())));
        }

        public void EditLocation(StoreLocation location)
        {
            _db.Update(location);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
