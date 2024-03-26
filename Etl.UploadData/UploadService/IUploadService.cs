using Etl.DataAccess.Postgres.Model;

namespace Etl.UploadData.UploadService
{
    public interface IUploadService
    {
        void Init(int initCount, int maxCount,string threadName);
        IAsyncEnumerable<UniversitetEntity?> UploadData(Uri uri, Dictionary<string, string> parameters);
        void UploadDataNoReturn(Uri uri, Dictionary<string, string> parameters);
    }
}