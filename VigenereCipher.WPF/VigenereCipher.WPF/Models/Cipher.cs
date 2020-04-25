﻿using System.Linq;

namespace VigenereCipher.WPF.Models.Cipher
{
    public static class Cipher
    {
        private static readonly string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
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
