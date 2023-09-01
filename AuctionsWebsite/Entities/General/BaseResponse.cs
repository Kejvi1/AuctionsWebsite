namespace Entities.General
{
    /// <summary>
    /// Base response model
    /// </summary>
    /// <typeparam name="T">Generic type of data response</typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }
    }
}