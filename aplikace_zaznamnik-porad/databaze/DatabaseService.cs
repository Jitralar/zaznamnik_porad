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
            command.CommandText = "SELECT * FROM ProgramPorady";
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

        public void AddProgram(string date, string lokace)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO ProgramPorady (Date, Lokace) VALUES ($date, $lokace)";
            command.Parameters.AddWithValue("$date", date);
            command.Parameters.AddWithValue("$lokace", lokace);
            command.ExecuteNonQuery();
        }

        public void AddBodProgramu(int programId, string nazev, string? text) 
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO BodProgramu (ProgramId, Nazev, Text) VALUES ($programId, $nazev, $text)";
            command.Parameters.AddWithValue("$programId", programId);
            command.Parameters.AddWithValue("$nazev", nazev);
            command.Parameters.AddWithValue("$text", text ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
        }

        public List<BodProgramu> GetBodyProgramu(int programId)
        {
            var bodyProgramu = new List<BodProgramu>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, ProgramId, Nazev, Text FROM BodProgramu WHERE ProgramId = $programId";
            command.Parameters.AddWithValue("$programId", programId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                bodyProgramu.Add(new BodProgramu
                {
                    Id = reader.GetInt32(0),
                    ProgramId = reader.GetInt32(1),
                    Nazev = reader.GetString(2),
                    Text = reader.IsDBNull(3) ? null : reader.GetString(3),
                });
            }

            return bodyProgramu;
        }


        public void AddHlasovani(Hlasovani hlasovani)
        {
            if (hlasovani == null) throw new ArgumentNullException(nameof(hlasovani));
            if (hlasovani.BodProgramuId <= 0) throw new ArgumentException("Neplatný BodProgramuId");
            if (hlasovani.OsobaId <= 0) throw new ArgumentException("Neplatný OsobaId");

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
        INSERT INTO Hlasovani (BodProgramuId, OsobaId, DateTime, Hlasoval)
        VALUES ($bodProgramuId, $osobaId, $dateTime, $hlasoval)";
            command.Parameters.AddWithValue("$bodProgramuId", hlasovani.BodProgramuId);
            command.Parameters.AddWithValue("$osobaId", hlasovani.OsobaId);
            command.Parameters.AddWithValue("$dateTime", hlasovani.DateTime ?? DBNull.Value.ToString());
            command.Parameters.AddWithValue("$hlasoval", hlasovani.Hlasoval ?? string.Empty);
            command.ExecuteNonQuery();
        }


        public bool ExistsBodProgramu(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(1) FROM BodProgramu WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        public bool ExistsOsoba(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(1) FROM Osoba WHERE ID = $id";
            command.Parameters.AddWithValue("$id", id);

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }









    }
}