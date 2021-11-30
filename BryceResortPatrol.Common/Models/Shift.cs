using BryceResortPatrol.Common.Models.Enums;
using System;

namespace BryceResortPatrol.Common.Models
{
    public record Shift(string Id, string Year, string Type, DateTime Date, ShiftType ShiftType, string userAlias = null);
}
