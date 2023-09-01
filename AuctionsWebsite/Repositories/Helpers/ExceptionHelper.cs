using System;

namespace Repositories.Helpers
{
    public class ExceptionHelper
    {
        public static string GetExceptionMessage(Exception ex)
        {
            string message = ex.Message;

            if (ex.InnerException != null)
            {
                string innerExceptionMessage = ex.InnerException.Message;
                message += $" (Inner Exception: {innerExceptionMessage})";
            }

            return message;
        }
    }
}