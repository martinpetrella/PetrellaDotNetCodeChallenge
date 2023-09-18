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

            if (employee == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                if (employee.DirectReports == null)
                {
                    result = 0;
                }
                else
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
