using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralSqlRepository.Constant;
using GeneralSqlRepository.Entity;
using GeneralSqlRepository.Interface;
using HighwayToHell.Repository.Interface;

namespace GeneralSqlRepository.Dao
{
    public class GeneralSqlPersonAndSinDao : IGeneralSqlDao
    {
        public List<int> FindSinIdsOf(GeneralSqlPersonEntity person, string connectionString)
        {
            List<int> sinIds = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlGetSinsByPersonId,
                                                    connection);
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParameterIdPerson,
                    Value = person.Id
                };
                command.Parameters.Add(parameter);
                using (command)
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sinIds.Add(reader.GetInt32(0));
                    }
                }
            }
            return sinIds;
        }

        public List<int> FindPersonIdsFor(GeneralSqlSinEntity sin, string connectionString)
        {
            List<int> personIds = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlGetPersonsBySinId,
                                                    connection);
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParameterIdPerson,
                    Value = sin.Id
                };
                command.Parameters.Add(parameter);
                using (command)
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personIds.Add(reader.GetInt32(0));
                    }
                }
            }
            return personIds;
        }

        public void AddPersonSin(GeneralSqlPersonEntity person, GeneralSqlSinEntity sin, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;

                    if (person.Id == 0)
                    {
                        if (sin.Id == 0)
                        {
                            command.CommandText = Constant.SqlString.SqlInsertPersonSinIdentity;
                        }
                        else
                        {
                            command.CommandText = Constant.SqlString.SqlInsertPersonSinIdentityPerson;
                        }
                    }
                    else
                    {
                        if (sin.Id == 0)
                        {
                            command.CommandText = Constant.SqlString.SqlInsertPersonSinIdentitySin;
                        }
                        else
                        {
                            command.CommandText = Constant.SqlString.SqlInsertPersonSin;
                        }
                    }

                    SqlParameter parameter1 = new SqlParameter
                    {
                        ParameterName = Constant.SqlString.SqlParameterIdPerson,
                        Value = person.Id
                    };
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter
                    {
                        ParameterName = Constant.SqlString.SqlParameterIdSin,
                        Value = sin.Id
                    };
                    command.Parameters.Add(parameter2);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }

        public void RemoveByPerson(GeneralSqlPersonEntity person, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlRemovePersonSinByPerson,
                                                    connection);
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParameterIdPerson,
                    Value = person.Id
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveBySin(GeneralSqlSinEntity sin, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlRemovePersonSinBySin,
                                                    connection);
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParameterIdSin,
                    Value = sin.Id
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

    }
}
