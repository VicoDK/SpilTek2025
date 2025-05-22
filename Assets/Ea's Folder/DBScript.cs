using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using NUnit.Framework;
using System;
using Unity.VisualScripting;
using Mirror;

public class DBScript : MonoBehaviour
{
    private string dataBaseName = "URI=file:myDB.db";

    private PointsManager points;
    public Scoreboard scoreboard;
    private bool PlayedOnce;


    // Start is called before the first frame update
    void Start()
    {
        CreateDB();
        PlayedOnce = false;
       

    }

    // Update is called once per frame
    public void click()
    {
        if (scoreboard.winner != "shkdfhsjgfhgsfkjsfgdsajlgefræpsagfuisgefgbweKAYHPSEFUHUFD" && !PlayedOnce )
        {
            Debug.Log(scoreboard.winner);
            CreatePlayer(scoreboard.winner,Pointchecker(scoreboard.winner) + 1);
            Debug.Log("miv");
            PlayedOnce=true;
        }
    }

    //makes a new db (if it doesn't exist) and add a table "players" (if it doesn't exist)
    public void CreateDB()
    {
        //creates a connection object
        using SqliteConnection connection = new SqliteConnection(dataBaseName);
        //open the connection
        connection.Open();

        using SqliteCommand command = new("create table if not exists player( name TEXT,point INTEGER)", connection);

        command.ExecuteNonQuery();

        Debug.Log("DB created");
    }

    //adds a record for a new player
    public void CreatePlayer(string name, int point)
    {
        using SqliteConnection connection = new SqliteConnection(dataBaseName);
        connection.Open();
        using SqliteCommand command = new("INSERT INTO Player (name,point) VALUES (@name,@point)", connection);

        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@point", point);



        command.ExecuteNonQuery();


        Debug.Log("Data inserted");
    }

    public int Pointchecker(string name)
    {
        int Point = 0;
        using (SqliteConnection connection = new SqliteConnection(dataBaseName))
        {
            connection.Open();

            using SqliteCommand command = new SqliteCommand("SELECT * FROM Player WHERE name = @name", connection);
            command.Parameters.AddWithValue("@name", name);

            using SqliteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Point = Convert.ToInt32(reader["point"]);
            }
        }
        return Point;
    }



    /* public void ReadRecords()
     {
         using (SqliteConnection connection = new SqliteConnection(dataBaseName))
         {
             connection.Open();

             using (SqliteCommand command = connection.CreateCommand())
             {
                 //this time we're asking to select all thee rows in the players table
                 command.CommandText = "SELECT * FROM players;";

                 //instead of calling ExecuteNonQuery, this time we use ExecuteReader
                 using (IDataReader reader = command.ExecuteReader())
                 {
                     //while reader still has lines 
                     while (reader.Read())
                     {
                         //we print the values returned from the db.
                         //we can access each field like it was a dictionary
                         Debug.Log("Name: " + reader["name"] + " Exp: " + reader["exp"]);
                     }
                 }
             }
         }
     }*/

}
