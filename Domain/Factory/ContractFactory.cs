using Domain.Enums;
using Domain.ServicesDomain;
using Infrastructure.IFactory;
using System;

namespace Domain.Factory
{
    /// <summary>
    /// Factory class for type contract.
    /// </summary>
    public class ContractFactory
    {
        /// <summary>
        /// Define the type object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IContract GetSalaryType(string type)
        {
            switch (type)
            {
                case Constants.ContractType.HourlySalaryContract:
                    return new HourlySalaryContract();
                case Constants.ContractType.MonthlySalaryContract:
                    return new MonthlySalaryContract();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
