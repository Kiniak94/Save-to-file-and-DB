using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RecruitmentTask.Services
{
    public class AsyncFileWriter: IAsyncFileWriter
    {
        public AsyncFileWriter()
        {
        }

        private static SemaphoreSlim _fileLock = new SemaphoreSlim(1);

        public async Task WriteToFile(string value)
        {
            await _fileLock.WaitAsync();

            try
            {
                using (StreamWriter writer = File.AppendText("fancyTexts.txt"))
                {
                    await writer.WriteLineAsync(value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _fileLock.Release();
            }
        }
    }
}
