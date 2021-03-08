using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Libs.CQRS.Interfaces
{

    public interface IQuery
    {

    }
    public interface IQuery<T> : IQuery where T : class
    {
        IQueryable<T> Apply(IQueryable<T> query);
    }

    public interface IQuery<T, R> : IQuery where T : class
    {
        IQueryable<R> Apply(IQueryable<T> query);
    }

    public interface IDapperQuery<T> : IQuery where T : class
    {
        IEnumerable<T> Apply(IDbConnection connection);
    }
}

