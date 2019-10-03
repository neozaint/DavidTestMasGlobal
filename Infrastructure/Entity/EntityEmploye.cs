using Newtonsoft.Json;

namespace Infrastructure
{
    public class EntityEmploye
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contractTypeName")]
        public string ContractTypeName { get; set; }

        [JsonProperty("roleId")]
        public long RoleId { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("roleDescription")]
        public object RoleDescription { get; set; }

        [JsonProperty("hourlySalary")]
        public long HourlySalary { get; set; }

        [JsonProperty("monthlySalary")]
        public long MonthlySalary { get; set; }
    }
}
