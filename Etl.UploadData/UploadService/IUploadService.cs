using Etl.DataAccess.Postgres.Model;

namespace Etl.UploadData.UploadService
{
    public interface IUploadService
    {
        IAsyncEnumerable<UniversitetEntity?> UploadData(Uri uri, Dictionary<string, string> parameters);
    }
}