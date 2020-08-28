using crmguruapp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace crmguruapp.DAL
{
    public static class DAL
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private const string InsertCountrySp = "InsertCountry";
        private const string GetCountriesSp = "GetCountry";
        public static bool InsertCity(string Name, string Code, string Capital, double Area,
                int Population, string Region)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(InsertCountrySp, connection) { CommandType = CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Code", Code);
                    command.Parameters.AddWithValue("@Capital", Capital);
                    command.Parameters.AddWithValue("@Area", Area);
                    command.Parameters.AddWithValue("@Population", Population);
                    command.Parameters.AddWithValue("@Region", Region);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<CountryModel> GetCountries()
        {
            var countries = new List<CountryModel>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(GetCountriesSp, connection) { CommandType = CommandType.StoredProcedure })
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        return countries;
                    }
                    while (reader.Read())
                    {
                        countries.Add(new CountryModel()
                        {
                            Name = reader.GetString(0),
                            Code = reader.GetString(1),
                            Capital = reader.GetString(2),
                            Area = reader.GetDouble(3),
                            Population = reader.GetInt32(4),
                            Region = reader.GetString(5)
                        });
                    }
                    reader.Close();
                }
            }
            return countries;
        }
    }
}
