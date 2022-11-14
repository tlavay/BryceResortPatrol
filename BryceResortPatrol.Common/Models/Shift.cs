using System;
using BryceResortPatrol.Common.Models.Enums;

namespace BryceResortPatrol.Common.Models
{
    public record Shift(string Id, string Year, string Type, DateTime Date, ShiftType ShiftType, string userAlias = null);
}
