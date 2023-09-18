using CodeChallenge.Models;

namespace CodeChallenge.Repositories
{
    public interface IEmployeeRepository2 : IEmployeeRepository
    {
        Compensation Add(Compensation compensation);
        Compensation GetCompensationById(string employeeId);
    }
}