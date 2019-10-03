using Infrastructure.IFactory;

namespace Domain.ServicesDomain
{
    /// <summary>
    /// Concrete class that implements the Hourly salary.
    /// </summary>
    public class HourlySalaryContract: IContract
    {
        public long CalculateSalaryByTypeContract(long salary)
        {
            return 120 * salary * 12;
        }
    }
}
