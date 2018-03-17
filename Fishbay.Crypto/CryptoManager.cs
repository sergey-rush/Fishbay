namespace Fishbay.Crypto
{
    public class CryptoManager
    {
        private static DataEncryptor dataEncryptor;
        private static RijndaelEncryptor rijndaelEncryptor;
        private static HashEncryptor hashEncryptor;

        public static BaseEncryptor GetEncryptor(Encryptor encryptor)
        {
            BaseEncryptor cryptoProvider = null;

            if (encryptor == Encryptor.Aes)
            {
                if (rijndaelEncryptor == null)
                {
                    rijndaelEncryptor = new RijndaelEncryptor();
                }
                cryptoProvider = rijndaelEncryptor;
            }

            if (encryptor == Encryptor.Des)
            {
                if (dataEncryptor == null)
                {
                    dataEncryptor = new DataEncryptor();
                }
                cryptoProvider = dataEncryptor;
            }

            if (encryptor == Encryptor.Hash)
            {
                if (hashEncryptor == null)
                {
                    hashEncryptor = new HashEncryptor();
                }
                cryptoProvider = hashEncryptor;
            }

            return cryptoProvider;
        }
    }
}