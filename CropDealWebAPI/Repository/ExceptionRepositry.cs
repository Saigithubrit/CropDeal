using CropDealWebAPI.Models;

namespace CropDealWebAPI.Repository
{
    public class ExceptionRepositry
    {
        CropDealContext _context;
        public ExceptionRepositry(CropDealContext context)
        {
            _context = context;
        }

        #region Exception Logging
        /// <summary>
        /// this method is used fro exception logging
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="causedAt"></param>
        public async Task AddException(Exception ex, string causedAt)
        {
            try
            {

                string filePath = @"D:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine(causedAt);
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    if (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);


                    }
                }
                if (ex != null)
                {
                    ExceptionLog log = new ExceptionLog();
                    log.ErrorCausedAt = causedAt;
                    log.ErrorMessage = ex.Message.ToString();
                    log.DateTime = DateTime.Now.ToString();
                    log.ErrorType = ex.GetType().FullName.ToString();
                    log.StackTrace = ex.StackTrace;
                    _context.ExceptionLogs.Add(log);
                    await _context.SaveChangesAsync();


                }
            }
            catch(Exception exe)
            {
                throw exe;
            }
            finally {

            }
          


        }
        #endregion
    }
}
