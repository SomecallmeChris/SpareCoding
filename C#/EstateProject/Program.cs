using System;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/*
To type in SQL terminal:
    1) CREATE DATABASE Estate
    2) use <name_of_table>

Code Dependencies:
    Only include function 'CreateLoginTable' on first program run
*/

namespace EstateProject
{
    class Program
    {
        static MySqlConnection SqlConnect(string server, string userid, string password,
                               string database)
        {
            /* 'cs' is required as the MySqlConnection function accepts the credientials only
               in this format */
            string cs = $"server={server};userid={userid};password={password};database={database}";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            return con;
        }
        static void CreateLoginTable(MySqlConnection con, MySqlCommand cmd)
        {
            // Create Login table
            cmd.CommandText = @"CREATE TABLE login(username TEXT, password TEXT)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO login(username, password) VALUES('chrisjreader', 'Georgie27')";
            cmd.ExecuteNonQuery();
        }

        static void RequestLogin(MySqlConnection con)
        {
            usernamePrompt:
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine($"Enter the password for '{username}': ");
            string password = Console.ReadLine();
            var sql = $@"SELECT * FROM login WHERE username = '{username}' AND password = '{password}'";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine("\n\nsuccess\n\n");
                reader.Close();
                return;
            }
            Console.WriteLine($"Incorrect username/password");
            Console.WriteLine("\nTry again: ");
            reader.Close();
            goto usernamePrompt; 
        }

        static void Unavailable(MySqlConnection con)
        {
            Console.WriteLine("This feature is currently unavailable:");
            Console.WriteLine("Back to Main Menu, otherwise application will close...");
            Console.WriteLine("Y/N: ");
            string decision = Console.ReadLine();
            if(decision == "Y")
                MainMenu(con);
            else{
                System.Environment.Exit(1);
            }
        }

        static void MainMenu(MySqlConnection con)
        {
            Console.Clear();
            Console.WriteLine("-------Welcome to Reader's Estates-------");
            Console.WriteLine("\n\nMain Menu:");
            Console.WriteLine("1) User Management");
            Console.WriteLine("2) Property Rentals");
            Console.WriteLine("3) Property Sales");
            Console.WriteLine("4) Log Out");

            Console.WriteLine("\n\nWhat would you like to do?");
            int menuIndex = Convert.ToInt32(Console.ReadLine());

            switch(menuIndex)
            {
                case 1:
                    UserManagement(con);
                    break;
                case 2:
                    Unavailable(con);
                    break;
                case 3:
                    Unavailable(con);
                    break;
                case 4:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
                    
            }
        }

        static void UserManagement(MySqlConnection con)
        {
            Console.Clear();
            Console.WriteLine("-------Welcome to Reader's Estates-------");
            Console.WriteLine("\n\nUser Management:");
            Console.WriteLine("1) Add new user");
            Console.WriteLine("2) Delete user");
            Console.WriteLine("3) Change current user password");
            Console.WriteLine("4) Show all users - Admin Only");
            Console.WriteLine("5) Back to Main Menu");

            Console.WriteLine("\n\nWhat would you like to do?");
            int menuIndex = Convert.ToInt32(Console.ReadLine());
            switch(menuIndex)
            {
                case 1:
                    Console.WriteLine("Add new user");
                    AddNewUser(con);
                    break;
                case 2:
                    Console.WriteLine("Delete user");
                    DeleteUser(con);
                    break;
                case 3:
                    Console.WriteLine("Change password");
                    Unavailable(con);
                    break;
                case 4:
                    Console.WriteLine("Show all users");
                    Unavailable(con);
                    break;
                case 5:
                    MainMenu(con);
                    break;
                default:
                    break;
            }
        }

        static void AddNewUser(MySqlConnection con)
        {
            start:
                Console.Clear();
                Console.WriteLine("-------Welcome to Reader's Estates-------");
                Console.WriteLine("\n\nAdd New User:");

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                string decisionUserName = "";
                string decisionPassword = "";
                string username = "";
                string password = "";

                while(decisionUserName != "Y")
                {
                    Console.WriteLine("Enter new username");
                    username = Console.ReadLine();
                    Console.WriteLine("Are you sure? Y/N");
                    decisionUserName = Console.ReadLine();
                }
                while(decisionPassword != "Y")
                {
                    Console.WriteLine($"Enter new password for {username}");
                    password = Console.ReadLine();
                    Console.WriteLine("Are you sure? Y/N");
                    decisionPassword = Console.ReadLine();
                }
                cmd.CommandText = $@"INSERT INTO login(username, password) VALUES('{username}', '{password}')";
                cmd.ExecuteNonQuery();
            
                Console.WriteLine("New User added, back to Main Menu? Y/N");
                string menuDecision = Console.ReadLine();

                if(menuDecision == "Y")
                {
                    MainMenu(con);
                }
                else{
                    Console.WriteLine("Add another user? Y/N");
                    menuDecision = Console.ReadLine();
                    
                    if(menuDecision == "Y")
                        goto start;
                    else{
                        MainMenu(con);
                    }
                }
                goto start;
        }

        static void DeleteUser(MySqlConnection con)
        {
            deleteUser:
                Console.Clear();
                Console.WriteLine("-------Welcome to Reader's Estates-------");
                Console.WriteLine("\n\nDelete User:");

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                string decisionUserName = "";
                string decisionGeneral = "N";
                string username = "";
                string password = "";

                while(decisionUserName != "Y")
                {
                    Console.WriteLine("Enter username to delete: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Are you sure? Y/N");
                    decisionUserName = Console.ReadLine();
                }
                Console.WriteLine($"Enter the password for '{username}'");
                password = Console.ReadLine();

                cmd.CommandText = $@"DELETE FROM login 
                                     WHERE username = '{username}' AND password = '{password}'";
                int deleteSuccess = cmd.ExecuteNonQuery();

                if(deleteSuccess == 1)
                {
                    Console.WriteLine($"{username} was succesfully removed.");
                    Console.WriteLine("Back to Main Menu? Y/N");
                    decisionGeneral = Console.ReadLine();
                    if(decisionGeneral == "Y")
                        MainMenu(con);
                    else{
                        Console.WriteLine("Delete another user? Y/N");
                        decisionGeneral = Console.ReadLine();
                        if(decisionGeneral == "Y")
                            goto deleteUser;
                        else{
                            MainMenu(con);
                        }
                    }

                }

        }
        static void Main(string[] args)
        {
            string server = "localhost";
            string userid = "root";
            string password = "carnotaurus£3";
            string database = "Estate";

            MySqlConnection con = SqlConnect(server, userid, password, database);

            //CreateLoginTable(con, cmd);
            RequestLogin(con);
            MainMenu(con);
        }
    }
}
