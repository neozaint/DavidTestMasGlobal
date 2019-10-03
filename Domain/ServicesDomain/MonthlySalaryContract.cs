using Infrastructure.IFactory;

namespace Domain.ServicesDomain
{
    /// <summary>
    /// Concrete class that implements the monthly salary.
    /// </summary>
    public class MonthlySalaryContract: IContract
    {
        public long CalculateSalaryByTypeContract(long salary)
        {
            return salary * 12;
        }
    }
}
