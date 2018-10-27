using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class StaffMapper : IDataMapper<Definition.Models.Staff, Staff>
    {

        public Staff ToData(NsuGo.Definition.Models.Staff domain)
        {
            return new Staff
            {
                Id = domain.Id,
                Name = domain.Name,
                EmailAddress = domain.EmailAddress,
                OfficeAddress = domain.OfficeAddress,
                OfficeHours = domain.OfficeHours,
                Phone = domain.Phone
            };
        }

        public Definition.Models.Staff ToDomain(Staff data)
        {
            return new Definition.Models.Staff
            {
                Id = data.Id,
                Name = data.Name,
                EmailAddress = data.EmailAddress,
                OfficeAddress = data.OfficeAddress,
                OfficeHours = data.OfficeHours,
                Phone = data.Phone
            };
        }
    }
}
