using System.Net.Http;

namespace Trakx.Coinbase.Custody.ApiClient.Utils
{
    public interface ICredentialsProvider
    {
        void AddCredentials(HttpRequestMessage msg);
    }

    public class NoCredentialsProvider : ICredentialsProvider
    {
        #region Implementation of ICredentialsProvider

        /// <inheritdoc />
        public void AddCredentials(HttpRequestMessage msg)
        {
            //don't add any credentials
        }

        #endregion
    }
}