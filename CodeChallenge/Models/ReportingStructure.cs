using System;

namespace CodeChallenge.Models
{
    public class ReportingStructure
    {
        public Employee employee { get; set; }
        public int numberOfReports { get { return GetNumberOfReports( employee ); } }
        private int GetNumberOfReports(Employee employee)
        {
            int result = 0;

            if (employee != null)
            {
                if (employee.DirectReports != null)
                {
                    employee.DirectReports.ForEach(e =>
                    {
                        result = result + GetNumberOfReports(e);
                    });

                    result = result + employee.DirectReports.Count;
                }
            }

            return result;
        }
    }
}
