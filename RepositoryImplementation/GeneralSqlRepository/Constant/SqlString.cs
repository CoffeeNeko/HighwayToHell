using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSqlRepository.Constant
{
    internal static class SqlString
    {
        public const string SqlParameterIdSin = "@idSin";
        public const string SqlParameterIdPerson = "@idPerson";
        public const string SqlParameterName = "@name";
        public const string SqlParamedterSurname = "@surname";
        public const string SqlParamedterDescription = "@description";

        public const string SqlGetAllPersons = "SELECT * FROM Person";
        public const string SqlGetAllSins = "SELECT * FROM Sin";

        public const string SqlInsertPerson = "INSERT INTO Person (Name, Surname) values("+SqlParameterName+","+SqlParamedterSurname+")";
        public const string SqlInsertSin = "INSERT INTO Sin (Name, Description) values("+SqlParameterName+","+SqlParamedterDescription+")";
        public const string SqlInsertPersonSin =
            "INSERT INTO Person_Sin (PersonId, SinId) values(" + SqlParameterIdPerson + "," + SqlParameterIdSin + ")";

        public const string SqlRemovePersonById = "DELETE FROM Person WHERE id =";
        public const string SqlRemoveSinById = "DELETE FROM Sin WHERE id =";
        public const string SqlRemovePersonSinByPerson = "DELETE FROM Person_Sin WHERE PersonId = " +SqlParameterIdPerson;
        public const string SqlRemovePersonSinBySin = "DELETE FROM Person_Sin WHERE SinId = " + SqlParameterIdSin;

        public const string SqlGetPersonById = "SELECT * FROM Person WHERE Id =";
        public const string SqlGetSinById = "SELECT * FROM Sin WHERE Id =";

        public const string SqlGetSinsByPersonId = "SELECT SinId FROM Person_Sin WHERE PersonId = " + SqlParameterIdPerson;
        public const string SqlGetPersonsBySinId = "SELECT PersonId FROM Person_Sin WHERE SinId = " + SqlParameterIdSin;
    }
}
