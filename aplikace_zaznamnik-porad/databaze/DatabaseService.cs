using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

public class DatabaseService
{
    private string _connectionString = "Data Source=meetingApp.db;Version=3;";

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Osoba (Id INTEGER PRIMARY KEY, Jmeno TEXT, Prijmeni TEXT, ProstredniJmeno TEXT, Prezdivka TEXT);
            CREATE TABLE IF NOT EXISTS Program (Id INTEGER PRIMARY KEY, Date TEXT, Lokace TEXT);
            CREATE TABLE IF NOT EXISTS BodProgramu (Id INTEGER PRIMARY KEY, ProgramId INTEGER, Nazev TEXT, Text TEXT, Dulezity BOOLEAN);
            CREATE TABLE IF NOT EXISTS Hlasovani (Id INTEGER PRIMARY KEY, BodProgramuId INTEGER, OsobaId INTEGER, DateTime TEXT, Hlasoval BOOLEAN);
        ";
        command.ExecuteNonQuery();
    }
}
