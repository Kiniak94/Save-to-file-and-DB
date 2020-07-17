using System.Threading.Tasks;

namespace RecruitmentTask.Services
{
    public interface IAsyncFileWriter
    {
        Task WriteToFile(string value);
    }
}
