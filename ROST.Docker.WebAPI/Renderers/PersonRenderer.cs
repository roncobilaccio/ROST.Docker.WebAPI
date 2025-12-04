using System;
using ROST.Docker.Models.Models;
using ROST.Docker.Models.Models.Base;

namespace ROST.Docker.WebAPI.Renderers
{
    public static class PersonRenderer
    {
        public static string Render(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            return person switch
            {
                Customer c => RenderCustomer(c),
                Employee e => RenderEmployee(e),
                _ => RenderGeneric(person)
            };
        }

        private static string RenderGeneric(Person p)
        {
            return $"Person: {p.GetFullName()} (Email: {p.Email ?? "-"}, Id: {p.Id})";
        }

        private static string RenderCustomer(Customer c)
        {
            return $"Customer: {c.GetFullName()} (Customer#: {c.CustomerNumber ?? "-"}, DOB: {FormatDate(c.DateOfBirth)}, Email: {c.Email ?? "-"})";
        }

        private static string RenderEmployee(Employee e)
        {
            return $"Employee: {e.GetFullName()} (Emp#: {e.EmployeeNumber ?? "-"}, Dept: {e.Department ?? "-"}, Hired: {FormatDate(e.HireDate)}, Email: {e.Email ?? "-"})";
        }

        private static string FormatDate(DateTime? dt) => dt?.ToString("yyyy-MM-dd") ?? "-";
    }
}
