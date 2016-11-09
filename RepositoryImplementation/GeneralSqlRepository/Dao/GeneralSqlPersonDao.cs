using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GeneralSqlRepository.Entity;
using GeneralSqlRepository.Interface;
using HighwayToHell.Repository.Interface;

namespace GeneralSqlRepository.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class GeneralSqlPersonDao : IGeneralSqlDao
    {
        /// <summary>
        /// 
        /// </summary>
        public List<IEntity> GetAllPersons(string connectionString)
        {
            List<IEntity> persons = new List<IEntity>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Constant.SqlString.SqlGetAllPersons, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        persons.Add(BuildPersonEntity(reader.GetInt32(0),
                                                   reader.GetString(1),
                                                   reader.GetString(2))
                                );
                    }
                }

            }
            return persons;
        }

        public IEntity GetPersonById(int id, string connectionString)
        {
            IEntity person = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlGetPersonById,
                                                    connection);
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParameterIdSin,
                    Value = id
                };

                command.Parameters.Add(parameter);

                using (command)
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        person = BuildPersonEntity(reader.GetInt32(0),
                                                   reader.GetString(1),
                                                   reader.GetString(2));
                    }
                }

             
            }
            return person;
        }

        public void InsertPerson(GeneralSqlPersonEntity entity, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                //using (SqlCommand command = new SqlCommand(Constant.SqlString.SqlInsertPerson, connection, transaction))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = Constant.SqlString.SqlInsertPerson;

                    SqlParameter parameter1 = new SqlParameter
                    {
                        ParameterName = Constant.SqlString.SqlParameterName,
                        Value = entity.Name
                    };
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter
                    {
                        ParameterName = Constant.SqlString.SqlParamedterSurname,
                        Value = entity.Surname
                    };
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter
                    {
                        ParameterName = Constant.SqlString.SqlParameterIdPerson,
                        Value = entity.Id
                    };
                    command.Parameters.Add(parameter3);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
            
        }

        public void RemovePerson(GeneralSqlPersonEntity entity, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlRemovePersonById,
                                                    connection);
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParameterName,
                    Value = entity.Id
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        private GeneralSqlPersonEntity BuildPersonEntity(int id, string name, string surname)
        {
            return new GeneralSqlPersonEntity()
            {
                Id = id,
                Name = name,
                Surname = surname
            };
        }
    }
}
