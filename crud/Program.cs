using System;
using System.Collections.Generic;

namespace DbConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Crud Application!");
            System.Console.WriteLine("Please Choose an action: 'Read', 'Add', 'Update', 'Delete'");
            string Action = "";
            while(Action !="Quit"){
            Action = Console.ReadLine();
            // System.Console.WriteLine($"You have choosen '{Action}'");
            switch(Action){
                case "Read":
                    Read();
                    break;
                 case "Add":
                    Add();
                    break;
                 case "Delete":
                    System.Console.WriteLine("in Delete");
                    Delete();
                    break;
                 case "Update":
                    Update();
                    break;
                case "Quit":
                    System.Console.WriteLine("Good Bye!");
                    break;   
                default:
                    System.Console.WriteLine("Sorry, that is not a valid option. Try again.");
                    break;                                                       
                }
            }
         }
        public static void Read(){
            List<Dictionary<string, object>> AllUsers= DbConnector.Query("SELECT * FROM user");
            for(var i = 0; i < AllUsers.Count; i++){
            System.Console.WriteLine(AllUsers[i]["idUser"] + ".) " + AllUsers[i]["FirstName"] + " " + AllUsers[i]["LastName"] + ", " + AllUsers[i]["FavoriteNumber"]);

            }   
        }
        public static void Add(){
            System.Console.WriteLine("Adding new user...");
            System.Console.WriteLine("First Name:");
            string FirstName = Console.ReadLine();
            System.Console.WriteLine("Last Name:");
            string LastName = Console.ReadLine();
            System.Console.WriteLine("Favorite Number:");
            string FavoriteNumber = Console.ReadLine();
            DbConnector.Execute($"INSERT INTO User (FirstName, LastName, FavoriteNumber) VALUES ('{FirstName}', '{LastName}', '{FavoriteNumber}')");
            Read();
        }
        public static void Delete(){
            System.Console.WriteLine("Which user would you like to delete?");
            Read();
            System.Console.WriteLine("Please select the user's ID:");
            string UserID = Console.ReadLine();
            DbConnector.Execute($"DELETE FROM User WHERE idUser = {UserID};");
            Read();
        }
        public static void Update(){
            Read();
            System.Console.WriteLine("Please select the user's ID number to update the information contained");
            string ID = Console.ReadLine();
            Console.WriteLine("Please enter First Name:");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Please enter Last Name:");
            string LastName = Console.ReadLine();
            Console.WriteLine("Please enter Favorite Number:");
            string FavoriteNumber = Console.ReadLine();
            DbConnector.Execute($"UPDATE User SET FirstName='{FirstName}', LastName='{LastName}', FavoriteNumber='{FavoriteNumber}' WHERE idUser={ID}");
            Read();
        }
    }
}
