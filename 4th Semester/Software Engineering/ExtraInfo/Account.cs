using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ExtraInfo
{
    public class Account
    {
        private string cardNumber;
        private string holderName;
        private string expirationDate;
        private string cvv;

        public User User { get; private set; }
        public string CardNumber
        {
            get => cardNumber;
            set
            {
                /*if (!IsNumeric(value) || value.Length != 16)
                {
                    throw new ArgumentException("Card Number must be a string of 16 digits (numeric input only).");
                }*/
                cardNumber = value;
            }
        }

        public string HolderName
        {
            get => holderName;
            set
            {
                /*if (!IsAlphabetic(value))
                {
                    throw new ArgumentException("Holder Name must contain alphabetic characters only.");
                }*/
                holderName = value;
            }
        }

        public string ExpirationDate
        {
            get => expirationDate;
            set
            {
                /*if (!IsValidExpirationDate(value))
                {
                    throw new ArgumentException("Expiration Date must be in MM/YY format (numeric input only).");
                }*/
                expirationDate = value;
            }
        }

        public string CVV
        {
            get => cvv;
            set
            {
                /*if (!IsNumeric(value) || value.Length != 3)
                {
                    throw new ArgumentException("CVV must be a three-digit code (numeric input only).");
                }*/
                cvv = value;
            }
        }

        public Account(User user, string cardNumber, string holderName, string expirationDate, string cvv)
        {
            User = user;
            CardNumber = cardNumber;
            HolderName = holderName;
            ExpirationDate = expirationDate;
            CVV = cvv;
        }

        private bool IsNumeric(string value)
        {
            return long.TryParse(value, out _);
        }

        private bool IsAlphabetic(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private bool IsValidExpirationDate(string value)
        {
            if (value.Length != 5 || value[2] != '/')
            {
                return false;
            }

            string[] parts = value.Split('/');
            if (parts.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(parts[0], out int month) || !int.TryParse(parts[1], out int year))
            {
                return false;
            }

            if (month < 1 || month > 12 || year < DateTime.Now.Year % 100 || year > DateTime.Now.Year % 100 + 10)
            {
                return false;
            }

            return true;
        }
    }
}
