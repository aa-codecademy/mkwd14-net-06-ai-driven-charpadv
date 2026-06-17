using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principles
{
    internal class SingleResponsibility
    {
        class User
        {
            public int Id { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        class Driver
        {
            public int Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
        }

        class Car
        {
            public int Id { get; set; }
            public string? Model { get; set; }
            public string? LicensePlate { get; set; }
        }
    }
}
