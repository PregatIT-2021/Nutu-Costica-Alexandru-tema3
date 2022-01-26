using System;
using System.Data.Common;

namespace Pregatit.MonkeyFinder.Infrastructure.DataAccess
{
    public interface IDbConnectionFactory
    {
        DbConnection GetConnection();
    }
}
