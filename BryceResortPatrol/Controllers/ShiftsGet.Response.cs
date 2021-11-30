using BryceResortPatrol.Common.Models;
using System.Collections.Generic;

namespace BryceResortPatrol.Controllers.Schedule
{
    public record ShiftsGetResponse(IEnumerable<Shift> Shifts);
}
