using System;
namespace T10
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string CreatedAt { get; set; }

		public Customer()
		{
		}

        public Customer(int id, string name, string phone, string address, string createdAt)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
            CreatedAt = createdAt;
        }

        public override string? ToString()
        {
            return Id + "," + Name + ", " + Phone;
        }
    }
}

