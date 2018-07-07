using Microsoft.EntityFrameworkCore;
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

        public void EditLocation(Location location)
        {
            _db.Update(location);
            _db.SaveChanges();
        }
    }
}
