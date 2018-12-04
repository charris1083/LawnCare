using LawnCare.Data;
using LawnCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Services
{
    public class MowerService
    {
        private readonly Guid _userId;

        public MowerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMower(MowerCreate model)
        {
            var entity =
                new Mower()
                {
                    LandscapeId = _userId,
                    MowerName = model.MowerName,
                    MowerCity = model.MowerCity,
                    MowerRate = model.MowerRate,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Mowers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MowerListItem> GetMowers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Mowers
                    .Where(e => e.LandscapeId == _userId)
                    .Select(
                        e =>
                        new MowerListItem
                        {
                            MowerId = e.MowerId,
                            MowerName = e.MowerName,
                        });
                return query.ToArray();
            }
        }
    }
}
