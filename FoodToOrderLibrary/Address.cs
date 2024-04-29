using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderLibrary
{
    public class Address
    {
        private int id;
        private int houseNo;
        private string street;
        private string area;
        private string city;
        private string state;
        private string country;
        private double pincode;
        private int userId;
        
        public int Id { get => id; set => id = value; }
        public int HouseNo { get => houseNo; set => houseNo = value; }
        public string Street { get => street; set => street = value; }
        public string Area { get => area; set => area = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Country { get => country; set => country = value; }
        public double Pincode { get => pincode; set => pincode = value; }
        public int UserId { get => userId; set => userId = value; }

        public Address()
        {
            
        }

        public Address(int id, int houseNo, string street, string area, string city, string state, string country, double pincode, int userId)
        { 
            this.Id = id;
            this.HouseNo = houseNo;
            this.Street = street;
            this.Area = area;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.Pincode = pincode;
            this.UserId = userId;
            
        }
    }
}
