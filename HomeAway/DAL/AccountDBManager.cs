﻿using BOL;
using System.Data;
using MySql.Data.MySqlClient;
namespace DAL;
public class AccountDBManager
{
    public User GetUser(string email,string password)
{
    User u=null;
    //database connectivity Code
    string conString=@"server=localhost;uid=root;"+"pwd=Jagruti@27;database=HomeAway";
    MySqlConnection con=new MySqlConnection(conString);
    string query="(SELECT  * FROM user where UserEmail='"+email+"' and UserPassword='"+password+"')";
    MySqlCommand cmd=new MySqlCommand();
    cmd.Connection=con;
    cmd.CommandText=query;
    con.Open();
    MySqlDataReader reader=cmd.ExecuteReader();
    Console.WriteLine("Records from MySQL database user table");
    if(reader.Read())
    {
        int id = int.Parse(reader["UserId"].ToString());
        string uname = reader["UserEmail"].ToString();
        string pwd= reader["UserPassword"].ToString();
        int role=int.Parse(reader["RoleId"].ToString());
             u=new User{
                            UserId = id,
                            Email = uname,
                            Password = pwd,
                            Role=role
                        };
    }
        Console.WriteLine("Inside DBManager");
       con.Close();
       return u;
}
}
