using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BryceResortPatrol.Common.DataServices;
using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Models.Enums;

namespace BryceResortPatrol.UtilityConsole
{
    internal sealed class ShiftHelper
    {
        public async Task CreateShifts()
        {
            var serviceProvider = ConsoleHelper.GetServiceProvider();
            var databaseContext = (DatabaseContext)serviceProvider.GetService(typeof(DatabaseContext));
            var shifts = CreateShiftDetails();
            var shiftCreateTasks = shifts.Select(s => databaseContext.Members.CreateItemAsync(s));
            await Task.WhenAll(shiftCreateTasks);
        }

        private IEnumerable<Shift> CreateShiftDetails()
        {
            var shifts = new List<Shift>();
            var startDate = new DateTime(2021, 12, 25);
            var endDate = new DateTime(2022, 3, 13);
            var currentDate = startDate;
            var year = "2022";
            var type = "schedule";
            while (currentDate <= endDate)
            {
                if (currentDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, currentDate, ShiftType.Day));
                    shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, currentDate, ShiftType.Night));
                }
                else if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, currentDate, ShiftType.Day));
                }

                currentDate = currentDate.AddDays(1);
            }

            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 26), ShiftType.Night));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 27), ShiftType.Day));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 27), ShiftType.Night));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 28), ShiftType.Day));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 28), ShiftType.Night));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 29), ShiftType.Day));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 29), ShiftType.Night));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 30), ShiftType.Day));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 30), ShiftType.Night));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 31), ShiftType.Day));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2021, 12, 31), ShiftType.Night));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2022, 01, 17), ShiftType.Day));
            shifts.Add(new Shift(Guid.NewGuid().ToString(), year, type, new DateTime(2022, 02, 21), ShiftType.Day));

            return shifts.OrderBy(shift => shift.Date);
        }
    }
}
