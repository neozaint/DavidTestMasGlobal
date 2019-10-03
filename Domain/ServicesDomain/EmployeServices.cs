using Domain.Enums;
using Domain.Factory;
using DTO;
using Infrastructure;
using Infrastructure.IFactory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ServicesDomain
{
    /// <summary>
    /// Class of the employee's business layer.
    /// </summary>
    public class EmployeServices
    {
        #region Attributes
        private IContract iContract;
        private ContractFactory employeFactory = new ContractFactory(); 
        #endregion

        #region Methods
        /// <summary>
        /// Orchestrated business layer method.
        /// </summary>
        /// <param name="employeModel">Modelo entre </param>
        /// <returns></returns>
        public async Task<List<EmployeDTO>> GetEmployees(EmployeDTO employeModel)
        {
            List<EntityEmploye> employeesQuery = new List<EntityEmploye>();
            List<EntityEmploye> entityEmployees = await GetEntityEmployees();


            ///Filter by data model.
            if (employeModel.Id == null)
            {
                employeesQuery = entityEmployees;
            }
            else
            {
                EntityEmploye entityEmployeQuery= entityEmployees.Where(e => e.Id == employeModel.Id).FirstOrDefault();
                if(entityEmployeQuery != null)
                    employeesQuery.Add(entityEmployeQuery);
            }

            ///Create EmployeDTO object mapping the classes.
            List<EmployeDTO> employeesDTO = new List<EmployeDTO>();
            EmployeDTO employeDTO;
            foreach (EntityEmploye item in employeesQuery)
            {
                employeDTO = Map(item);
                employeDTO.AnualSalary = GetAnualSalary(item);
                employeesDTO.Add(employeDTO);
            }

            return employeesDTO;
        }

        /// <summary>
        /// Get employees from DAL and Deserialize Object.
        /// </summary>
        /// <returns></returns>
        public async Task<List<EntityEmploye>> GetEntityEmployees()
        {
            EmployeDAL employeDAL = new EmployeDAL();
            string json = await employeDAL.GetEmployeesAsync();
            //string json = ReadFile();
            List<EntityEmploye> employes = JsonConvert.DeserializeObject<List<EntityEmploye>>(json);
            return employes;
        }

        /// <summary>
        /// Calculate Annual Salary by Contract type name.
        /// </summary>
        /// <param name="employe"></param>
        /// <returns></returns>
        public long GetAnualSalary(EntityEmploye employe)
        {
            long anualSalary = 0;
            switch (employe.ContractTypeName)
            {
                case Constants.ContractType.HourlySalaryContract:
                    iContract = employeFactory.GetSalaryType(Constants.ContractType.HourlySalaryContract);
                    anualSalary = iContract.CalculateSalaryByTypeContract(employe.HourlySalary);
                    break;
                case Constants.ContractType.MonthlySalaryContract:
                    iContract = employeFactory.GetSalaryType(Constants.ContractType.MonthlySalaryContract);
                    anualSalary = iContract.CalculateSalaryByTypeContract(employe.MonthlySalary);
                    break;
            }

            return anualSalary;
        }

        /// <summary>
        /// Map object EntityEmploye to EmployeDTO.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private EmployeDTO Map(EntityEmploye item)
        {
            EmployeDTO employeDTO = new EmployeDTO();
            employeDTO.ContractTypeName = item.ContractTypeName;
            employeDTO.HourlySalary = item.HourlySalary;
            employeDTO.Id = item.Id;
            employeDTO.MonthlySalary = item.MonthlySalary;
            employeDTO.Name = item.Name;
            employeDTO.RoleDescription = item.RoleDescription;
            employeDTO.RoleId = item.RoleId;
            employeDTO.RoleName = item.RoleName;

            return employeDTO;
        }

        /// <summary>
        /// Test read json.
        /// </summary>
        /// <returns></returns>
        private string ReadFile()

        {
            
                string file = @"C: \Users\852038\Desktop\waTest\waTest\App_LocalResources\jsonMasGl.json";
            //string file = @"C:\Users\858277\Desktop\waTest\waTest\App_LocalResources\jsonMasGl.json";
            //string file = "/App_LocalResources/jsonMasGl.json";
            string content = String.Empty;

            if (File.Exists(file))
            {
                content = File.ReadAllText(file);
            }

            return content;
        } 
        #endregion
    }
}
