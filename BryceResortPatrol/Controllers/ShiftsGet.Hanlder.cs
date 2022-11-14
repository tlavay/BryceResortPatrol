using System.Threading;
using System.Threading.Tasks;
using BryceResortPatrol.Common.DataServices;
using BryceResortPatrol.Common.Models;
using MediatR;

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
            //var sql = $@"SELECT * FROM c
            //            where c.year = '{schedulesGetQuery.Year}'";
            //var shifts = await this.databaseContext.Members.Query<Shift>(sql);
            await Task.Run(() => { });
            return new ShiftsGetResponse(null);
        }
    }
}