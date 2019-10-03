using Infrastructure;

namespace DTO
{
    /// <summary>
    /// Inherit from EntityEmploye and add the property.
    /// </summary>
    public class EmployeDTO:EntityEmploye
    {
        public long AnualSalary { get; set; }
    }
}
