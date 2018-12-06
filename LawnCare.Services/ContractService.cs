using LawnCare.Data;
using LawnCare.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = LawnCare.Data.Contract;

namespace LawnCare.Services
{
    public class ContractService
    {
        private readonly Guid _userId;

        public ContractService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateContract(ContractCreate model)
        {
            var entity =
                new Contract()
                {
                    //OwnerId = _userId,
                    ClientId = model.ClientId,
                    MowerId = model.MowerId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contracts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
            public IEnumerable<ContractListItem> GetContracts()
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                        .Contracts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new ContractListItem
                            {
                                ContractId = e.ContractId,
                                ClientId = e.ClientId,
                                MowerId = e.MowerId
                            });
                    return query.ToArray();
                }
            }
    }
}
