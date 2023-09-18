using CodeChallenge.Models;

namespace CodeChallenge.Services
{
    public interface IEmployeeService2 : IEmployeeService
    {
        Compensation CreateCompensation(Compensation compensation);
        Compensation GetCompensationByID(string id);
        ReportingStructure GetReportingStructureById(string id);
    }
}
