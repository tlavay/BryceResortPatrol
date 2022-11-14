namespace BryceResortPatrol.UtilityConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shiftHelper = new ShiftHelper();
            shiftHelper.CreateShifts().Wait();
        }
    }
}
