using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHours.ViewModel
{
   public static class HoursProcessor
    {
        public static double CalculateBreakTime(EmployeeHours.Model.Employee _selectedEmployee)
        {

            var hoursWorked = _selectedEmployee.EmployeeHours.FirstOrDefault().Hours;

            double calculatedBreak;
            //Determine if nightshift to point to correct calculation
            if ((bool)_selectedEmployee.IsNightshift)
                calculatedBreak = CalculateNightShiftBreak(hoursWorked);
            else
                calculatedBreak = CalculateStandardBreak(hoursWorked);

            //Return break in hours 
            return (ConvertMinutesToHours(calculatedBreak));
        }
              
        private static double ConvertMinutesToHours(double minutes)
        {
            //convert minutes value to hours  
            return Math.Round(minutes / 60,2);
        }

        //Standard employee calculation
        private static double CalculateStandardBreak(int hours)
        {   
            //10mins break per hour worked
            //For every 4 hours they get an additional 20min break

            double breaktime = hours * 10;            
            double additionalbreak = (hours / 4) * 20;
            return (breaktime + additionalbreak);
        }

        //Nightshift Employee Calculation
        private static double CalculateNightShiftBreak(int hours)
        {
            // 15mins break per hour worked
            // For every 4 hours they get an additional 30min break

            double breaktime = hours * 15;
            double additionalbreak = (hours / 4) * 30;
            return (breaktime + additionalbreak);
        }

    }
}
