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

        // Without SRP (BAD EXAMPLE)
        class TaxiServiceWithoutSRP
        {
            public bool Login(string username, string password)
            {
                // code...
                return false;
            }

            public int Register(User user)
            {
                // code...
                return user.Id;
            }

            public List<User> GetAllUsers()
            {
                // code...
                return new List<User>();
            }

            public List<Driver> GetAllDrivers()
            {
                // code...
                return new List<Driver>();
            }

            public List<Car> GetAllCars()
            {
                // code...
                return new List<Car>();
            }

            public List<string> GetAllLicensePlates()
            {
                // code...
                return new List<string>();
            }
        }
        // With SRP (GOOD EXAMPLE)
        class UserService
        {
            public bool Login(string username, string password)
            {
                // code...
                return false;
            }

            public int Register(User user)
            {
                // code...
                return user.Id;
            }

            public List<User> GetAllUsers()
            {
                // code...
                return new List<User>();
            }
        }

        class DriverService
        {
            public List<Driver> GetAllDrivers()
            {
                // code...
                return new List<Driver>();
            }
        }

        class CarService
        {
            public List<Car> GetAllCars()
            {
                // code...
                return new List<Car>();
            }

            public List<string> GetAllLicensePlates()
            {
                // code...
                return new List<string>();
            }
        }



        // Without SRP (BAD EXAMPLE)
        class PersonWithoutSRP
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Street { get; set; }
            public string? StreetNumber { get; set; }
            public string? City { get; set; }
            public string? PostalCode { get; set; }
        }

        // With SRP(GOOD EXAMPLE)
    class PersonWithSRP
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public Address? Address { get; set; }

        }

        class Address
        {
            public string? Street { get; set; }
            public string? StreetNumber { get; set; }
            public string? City { get; set; }
            public string? PostalCode { get; set; }
        }

    }
}
