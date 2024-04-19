using System;
using System.Linq;
using System.Text;

namespace Module
{
    internal class SubstitutionCipher
    {
        private readonly string key;

        public SubstitutionCipher(string key = null)
        {
            if (key == null)
            {
                this.key = GenerateRandomKey();
            }
            else
            {
                this.key = key;
            }
        }

        private string GenerateRandomKey()
        {
            var alphabet = Enumerable.Range(0, 26).Select(x => (char)('a' + x)).ToArray();
            var digits = Enumerable.Range(0, 10).Select(x => (char)('0' + x)).ToArray();
            var random = new Random();
            var shuffledAlphabet = alphabet.OrderBy(x => random.Next()).ToArray();
            var shuffledDigits = digits.OrderBy(x => random.Next()).ToArray();
            return new string(shuffledAlphabet) + new string(shuffledDigits);
        }

        public string Encrypt(string text)
        {
            var encryptedText = new StringBuilder();
            foreach (var c in text.ToLower())
            {
                if (char.IsLetter(c))
                {
                    var index = c - 'a';
                    encryptedText.Append(char.IsUpper(c) ? char.ToUpper(key[index]) : key[index]);
                }
                else if (char.IsDigit(c))
                {
                    var index = c - '0' + 26; 
                    if (index >= 26 && index < key.Length)
                        encryptedText.Append(key[index]);
                    else
                        encryptedText.Append(c);
                }
                else
                {
                    encryptedText.Append(c);
                }
            }
            return encryptedText.ToString();
        }
        public string Decrypt(string ciphertext)
        {
            var decryptedText = new StringBuilder();
            foreach (var c in ciphertext.ToLower())
            {
                if (char.IsLetter(c))
                {
                    var index = key.IndexOf(c);
                    decryptedText.Append(char.IsUpper(c) ? char.ToUpper((char)('a' + index)) : (char)('a' + index));
                }
                else if (char.IsDigit(c))
                {
                    var index = key.IndexOf(c) - 26;
                    if (index >= 0 && index < 10)
                        decryptedText.Append((char)('0' + index));
                    else
                        decryptedText.Append(c);
                }
                else
                {
                    decryptedText.Append(c);
                }
            }
            return decryptedText.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter your card number:");
            string cardNumber = Console.ReadLine();

            Console.WriteLine("Enter your holder name:");
            string holderName = Console.ReadLine();

            Console.WriteLine("Enter your expiration date (MM/YY):");
            string expirationDate = Console.ReadLine();

            Console.WriteLine("Enter your CVV:");
            string cvv = Console.ReadLine();

            Account account = new Account(username, password, cardNumber, holderName, expirationDate, cvv);

            SubstitutionCipher cipher = new SubstitutionCipher();
            string encryptedData = cipher.Encrypt($"{account.Username} {account.Password} {account.CardNumber} {account.HolderName} {account.ExpirationDate} {account.CVV}");

            Console.WriteLine("\nEncrypted Data:");
            Console.WriteLine(encryptedData);

            string decryptedData = cipher.Decrypt(encryptedData);

            Console.WriteLine("\nDecrypted Data:");
            Console.WriteLine(decryptedData);
        }
    }
}