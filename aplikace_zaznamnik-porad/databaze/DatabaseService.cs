using System;
using System.Collections.Generic;
using aplikace_zaznamnik_porad.databaze;
using Microsoft.Data.Sqlite;

namespace aplikace_zaznamnik_porad
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Data Source=C:\\Users\\jirco\\Documents\\GitHub\\zaznamnik_porad\\aplikace_zaznamnik-porad\\meetingApp.db;";

        public List<Osoba> GetAllOsoby()
        {
            var osoby = new List<Osoba>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Jmeno, Prijmeni FROM Osoba";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                osoby.Add(new Osoba
                {
                    Id = reader.GetInt32(0),
                    Jmeno = reader.GetString(1),
                    Prijmeni = reader.GetString(2),
                });
            }

            return osoby;
        }

        public List<ProgramPorady> GetAllPrograms()
        {
            var programs = new List<ProgramPorady>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM BodProgramu";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                programs.Add(new ProgramPorady
                {
                    Id = reader.GetInt32(0),
                    Date = reader.GetString(1),
                    Lokace = reader.GetString(2),
                });
            }

            return programs;
        }

        public void AddOsoba(string jmeno, string prijmeni)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Osoba (Jmeno, Prijmeni) VALUES ($jmeno, $prijmeni)";
            command.Parameters.AddWithValue("$jmeno", jmeno);
            command.Parameters.AddWithValue("$prijmeni", prijmeni);
            command.ExecuteNonQuery();
        }

        public void UpdateOsoba(int id, string jmeno, string prijmeni)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Osoba SET Jmeno = $jmeno, Prijmeni = $prijmeni WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$jmeno", jmeno);
            command.Parameters.AddWithValue("$prijmeni", prijmeni);
            command.ExecuteNonQuery();
        }



        public void DeleteOsoba(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Osoba WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }



    }
}