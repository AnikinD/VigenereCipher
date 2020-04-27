using System.Linq;

namespace VigenereCipher.WPF.Models.Cipher
{
    public static class Cipher
    {
        private static readonly string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        /// <summary>
        /// Метод, шифрующий текстовое сообщение
        /// </summary>
        /// <param name="text">Текст сообщения для шифрования</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Строка с шифрованным текстом</returns>
        public static string Encrypt(string text, string key)
        {
            int i = 0;
            string result = "";
            foreach (char sym in text)
            {
                char lowerSym = char.ToLower(sym);
                if (alphabet.Contains(lowerSym))
                {
                    int p = alphabet.IndexOf(lowerSym);
                    int k = alphabet.IndexOf(char.ToLower(key[i++ % key.Length]));
                    result += char.IsUpper(sym) ? alphabet[(p + k) % alphabet.Length].ToString().ToUpper()
                                                : alphabet[(p + k) % alphabet.Length].ToString();
                }
                else
                    result += sym;
            }
            return result;
        }
        /// <summary>
        /// Метод, дешифрующий текстовое сообщение
        /// </summary>
        /// <param name="text">Текст зашифрованного сообщения</param>
        /// <param name="key">Ключ шифрования</param>
        /// <returns>Строка с дешифрованным текстом</returns>
        public static string Decrypt(string text, string key)
        {
            int i = 0;
            string result = "";
            foreach (char sym in text)
            {
                char lowerSym = char.ToLower(sym);
                if (alphabet.Contains(lowerSym))
                {
                    int c = alphabet.IndexOf(lowerSym);
                    int k = alphabet.IndexOf(char.ToLower(key[i++ % key.Length]));
                    result += char.IsUpper(sym) ? alphabet[(c - k + alphabet.Length) % alphabet.Length].ToString().ToUpper()
                                                : alphabet[(c - k + alphabet.Length) % alphabet.Length].ToString();
                }
                else
                    result += sym;
            }
            return result;
        }
    }
}
