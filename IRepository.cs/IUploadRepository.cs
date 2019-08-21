using System.Threading.Tasks;
using Document.Domain;

namespace Document.Interface.Repository
{
    public interface IUploadRepository
    {
        Task<FileModel> GetAsync(int id);
        Task InsertAsync(FileModel file);
        Task<int> Save();
    }
}