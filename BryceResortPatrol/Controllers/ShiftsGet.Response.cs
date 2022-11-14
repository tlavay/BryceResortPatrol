using System.Collections.Generic;
using BryceResortPatrol.Common.Models;

namespace BryceResortPatrol.Controllers.Schedule
{
    public record ShiftsGetResponse(IEnumerable<Shift> Shifts);
}
