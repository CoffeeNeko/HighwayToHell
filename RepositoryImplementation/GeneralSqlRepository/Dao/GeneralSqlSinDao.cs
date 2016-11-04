using System.Collections.Generic;
using System.Data.SqlClient;
using GeneralSqlRepository.Constant;
using GeneralSqlRepository.Entity;
using GeneralSqlRepository.Interface;
using HighwayToHell.Repository.Interface;

namespace GeneralSqlRepository.Dao
{
    public class GeneralSqlSinDao : IGeneralSqlDao
    {
        /// <summary>
        /// 
        /// </summary>
        public List<IEntity> GetAllSins(string connectionString)
        {
            List<IEntity> sins = new List<IEntity>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SqlString.SqlGetAllSins, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sins.Add(BuildSinEntity(reader.GetInt32(0),
                                                   reader.GetString(1),
                                                   reader.GetString(2))
                                );
                    }
                }

                connection.Close();
            }
            return sins;
        }

        public IEntity GetSinById(int id, string connectionString)
        {
            IEntity sin = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlGetSinById,
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
                        sin = BuildSinEntity(reader.GetInt32(0),
                                                   reader.GetString(1),
                                                   reader.GetString(2));
                    }
                }

                connection.Close();
            }
            return sin;
        }

        public void InsertSin(GeneralSqlSinEntity entity, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlInsertSin,
                                                    connection);
                SqlParameter parameter1 = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParameterName,
                    Value = entity.Name
                };
                command.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParamedterDescription,
                    Value = entity.Description
                };
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter
                {
                    ParameterName = Constant.SqlString.SqlParameterIdSin,
                    Value = entity.Id
                };
                command.Parameters.Add(parameter3);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveSin(GeneralSqlSinEntity entity, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constant.SqlString.SqlRemoveSinById,
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

        private IEntity BuildSinEntity(int id, string name, string description)
        {
            return new GeneralSqlSinEntity()
            {
                Id = id,
                Name = name,
                Description = description
            };
        }
    }
}
