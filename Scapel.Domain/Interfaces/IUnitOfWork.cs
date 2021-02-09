using System;
namespace Scapel.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // IBooksRepository Books { get; }
        //  ICatalogueRepository Catalogues { get; }
        int Complete();
    }
}
