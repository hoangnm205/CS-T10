using System.Data.SqlClient;

namespace T10;

class Program
{
    static void Main(string[] args)
    {
        SqlConnection conn = null;
        try
        {
            string connStr = "Data Source=172.16.3.167,1433;Initial Catalog=T4;User Id=sa;Password=123123";
            conn = new SqlConnection(connStr);

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Db Connected");

                // 1. SELECT Ko tham so
                string sql = "SELECT * FROM CUSTOMERS";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Field COunt = {0}",reader.FieldCount);
                Console.WriteLine("COL 1 = {0}", reader.GetName(1));
                while (reader.Read()) // row pointer
                {
                    
                    //Console.WriteLine("Id={0},Name={1}", reader[0], reader[1]);
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    Console.WriteLine(reader[i]);
                    //}

                    Console.WriteLine("Id={0},Phone={1}", reader["ID"], reader["PHONE"]);
                }

                // 2. SELECT co tham so WHERE ID = ?

                //int id = Convert.ToInt16(Console.ReadLine());
                ////string name = Console.ReadLine();
                //string sql = "SELECT * FROM CUSTOMERS WHERE ID = @id AND NAME = @name"; 
                //SqlCommand cmd = new SqlCommand(sql, conn);
                ////cmd.Parameters.Add(new SqlParameter("id", 1));
                //cmd.Parameters.AddWithValue("id", id);
                ////cmd.Parameters.AddWithValue("name", name);

                //SqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    Console.WriteLine("Id={0},Name={1}", reader["ID"], reader["NAME"]);
                //}

                // 3. INSERT/UPDATE/DELETE

                //string sql = "INSERT INTO [dbo].[CUSTOMERS]([NAME],[PHONE],[ADDRESS],[CREATEDAT]) VALUES (@0,@1,@2,@3)";
                //SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("0", "TEST01");
                //cmd.Parameters.AddWithValue("1", "0912317823");
                //cmd.Parameters.AddWithValue("2", "HANOI");
                //cmd.Parameters.AddWithValue("3", "2023-01-01");

                //int insertedRows = cmd.ExecuteNonQuery();
                //Console.WriteLine(insertedRows);
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            conn.Close();
        }
        
    }
}

