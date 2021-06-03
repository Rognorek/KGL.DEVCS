using IPLootbox;
using Microsoft.Data.SqlClient;

namespace WF_LOOTBOX
{
    public class DBMSSQLEXP
    {
        private static readonly SqlConnection KEDR = Init();

        static private SqlConnection Init()
        {
            string usersrc = @"W10\KEDR";
            string usercat = @"DB_LOOTBOX";
            string usersec = @"True";

            string src = @"Data Source = " + usersrc;
            string cat = @"Initial Catalog = " + usercat;
            string sec = @"Integrated Security = " + usersec;

            return new SqlConnection(src + ";" + cat + ";" + sec);
        }



        public void SelectWorkers()
        {
            Lootbox.ClearWorkers();
            string sqlquery = @"select * from workers order by id";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, KEDR);

            KEDR.Open();
            using (SqlDataReader reader = sqlcmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string fname = (string)reader["f_name"];
                        string lname = (string)reader["l_name"];
                        string mname = (string)reader["m_name"];
                        float speed = (float)(double)reader["speed"];
                        int boxsize = (int)reader["box_size"];
                        bool isbusy = (bool)reader["is_busy"];
                        Worker worker = new Worker(id, fname, lname, mname, speed, (BoxSize)boxsize, isbusy);
                        Lootbox.AddWorker(worker);
                    }
                }
            }
            KEDR.Close();
        }

        public void DeleteWorker(int id)
        {
            string sqlquery = @$"delete from workers where id = {id}";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, KEDR);
            KEDR.Open();
            sqlcmd.ExecuteNonQuery();            
            KEDR.Close();
            SelectWorkers();
        }

        public void AddWorker(string fname, string lname, string mname, float speed, int boxsize)
        {   
            string sqlquery = @$"insert into workers values('{fname}', '{lname}', '{mname}', {speed}, {boxsize}, 0)";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, KEDR);
            KEDR.Open();
            sqlcmd.ExecuteNonQuery();
            KEDR.Close();
            SelectWorkers();
        }



        public void SelectClients()
        {
            Lootbox.ClearClients();
            string sqlquery = @"select * from clients order by id";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, KEDR);

            KEDR.Open();
            using (SqlDataReader reader = sqlcmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string fname = (string)reader["f_name"];
                        string lname = (string)reader["l_name"];
                        string mname = (string)reader["m_name"];
                        float distance = (float)(double)reader["distance"];
                        int boxsize = (int)reader["box_size"];
                        System.DateTime stamp = (System.DateTime)reader["Stamp"];
                        Client client = new Client(id, fname, lname, mname, distance, (BoxSize)boxsize, stamp);
                        Lootbox.AddClient(client);
                    }
                }
            }
            KEDR.Close();
        }
    }
}