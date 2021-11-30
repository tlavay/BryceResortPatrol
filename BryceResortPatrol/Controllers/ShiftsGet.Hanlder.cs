using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BryceResortPatrol.Controllers.Schedule
{
    public class ShiftGetHandler : IRequestHandler<ShiftsGetQuery, ShiftsGetResponse>
    {
        private readonly DatabaseContext databaseContext;

        public ShiftGetHandler(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<ShiftsGetResponse> Handle(ShiftsGetQuery schedulesGetQuery, CancellationToken cancellationToken)
        {
            var sql = $@"SELECT * FROM c
                        where c.year = '{schedulesGetQuery.Year}'";
            var shifts = await this.databaseContext.Members.Query<Shift>(sql);
            return new ShiftsGetResponse(shifts);
        }
    }
}