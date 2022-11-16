using NordicDoorSuggestionSystem.Entities;
using System.Data;

namespace NordicDoorSuggestionSystem.DataAccess
{
    public interface ISqlConnector
    {
        IDbConnection GetDbConnection();
    }
}