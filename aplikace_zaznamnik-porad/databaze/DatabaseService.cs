using System.Collections.Generic;
using aplikace_zaznamnik_porad.databaze;
using Microsoft.Data.Sqlite;

namespace aplikace_zaznamnik_porad
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Data Source=meetingApp.db;";

        public List<ProgramPorady> GetAllPrograms()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Program";
            using var reader = command.ExecuteReader();

            var result = new List<ProgramPorady>();
            while (reader.Read())
            {
                result.Add(new ProgramPorady
                {
                    Id = reader.GetInt32(0),
                    Date = reader.GetDateTime(1).ToString(),
                    Lokace = reader.GetString(2),
                });
            }
            return result;
        }

        public List<Osoba> GetAllOsoby()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Osoba";
            using var reader = command.ExecuteReader();

            var result = new List<Osoba>();
            while (reader.Read())
            {
                result.Add(new Osoba
                {
                    Id = reader.GetInt32(0),
                    Jmeno = reader.GetString(1),
                    Prijmeni = reader.GetString(2),
                });
            }
            return result;
        }

        public List<BodProgramu> GetBodyProgramu(int programId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM BodProgramu WHERE ProgramId = $programId";
            command.Parameters.AddWithValue("$programId", programId);
            using var reader = command.ExecuteReader();

            var result = new List<BodProgramu>();
            while (reader.Read())
            {
                result.Add(new BodProgramu
                {
                    Id = reader.GetInt32(0),
                    ProgramId = reader.GetInt32(1),
                    Nazev = reader.GetString(2),
                    Text = reader.GetString(3),
                    Dulezity = reader.GetInt32(4),
                });
            }
            return result;
        }

        public void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
        CREATE TABLE IF NOT EXISTS Osoba (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Jmeno TEXT NOT NULL,
            Prijmeni TEXT NOT NULL
        );

        CREATE TABLE IF NOT EXISTS Program (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Date TEXT NOT NULL,
            Lokace TEXT NOT NULL
        );

        CREATE TABLE IF NOT EXISTS BodProgramu (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            ProgramId INTEGER NOT NULL,
            Nazev TEXT NOT NULL,
            Text TEXT,
            Dulezity BOOLEAN,
            FOREIGN KEY (ProgramId) REFERENCES Program(Id)
        );

        CREATE TABLE IF NOT EXISTS Hlasovani (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            BodProgramuId INTEGER NOT NULL,
            OsobaId INTEGER NOT NULL,
            DateTime TEXT NOT NULL,
            Hlasoval BOOLEAN,
            FOREIGN KEY (BodProgramuId) REFERENCES BodProgramu(Id),
            FOREIGN KEY (OsobaId) REFERENCES Osoba(Id)
        );
    ";
            command.ExecuteNonQuery();
        }



    }
}
