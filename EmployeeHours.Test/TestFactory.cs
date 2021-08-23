using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHours.Test
{
    public static class TestFactory
    {
        public static EmployeeHours.Model.Employee StandardEmpolyee()
        {
            return new Model.Employee()
            {
                Name = "C Killian",
                JobDesc = "Developer",
                IsNightshift = false,
                EmployeeHours = new List<EmployeeHours.Model.EmployeeHour>()
            { new Model.EmployeeHour {Hours = 6,BreakTime = 0 } }
            };
        }

        public static EmployeeHours.Model.Employee NightShiftEmpolyee()
        {
            return new Model.Employee()
            {
                Name = "J Doe",
                JobDesc = "Foreman",
                IsNightshift = true,
                EmployeeHours = new List<EmployeeHours.Model.EmployeeHour>()
            { new Model.EmployeeHour {Hours = 4,BreakTime = 0 } }
            };
        }
    }
}
