using LawnCare.Data;
using LawnCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Services
{
    public class ClientService
    {
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    CustomerId = _userId,
                    ClientName = model.ClientName,
                    ClientCity = model.ClientCity,
                    ClientNeeds = model.ClientNeeds,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Clients
                    .Where(e => e.CustomerId == _userId)
                    .Select(
                        e =>
                        
                            new ClientListItem
                            {
                                ClientId = e.ClientId,
                                ClientName = e.ClientName
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
