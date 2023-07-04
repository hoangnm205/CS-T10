using System;
using System.Data.SqlClient;
namespace T10
{
	public class CustomerManager
	{
		List<Customer> list;
		public CustomerManager()
		{
			list = new List<Customer>();
		}

		public void LoadData()
		{
			try
			{
                SqlConnection conn = new DbConnector().GetConnection();
				//SqlConnection conn = new DbConnector("123.1231.23.", "T3","","").GetConnection();
				conn.Open();

				string sql = "SELECT * FROM CUSTOMERS";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Customer c = new Customer();
					c.Id = (int) reader["ID"];
					c.Name = reader.GetString(1);
					c.Phone = (string) reader["PHONE"];
					c.Address = (string) reader["ADDRESS"];
					list.Add(c);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void PrintList()
		{
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}
    }
}

