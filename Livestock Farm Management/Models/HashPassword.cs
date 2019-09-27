using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using Livetock_Farm_Management.Models;

namespace Open_Chequelist_Template.Models
{
    public class HashPassword
    {
        private string saltValue;
        public string salt
        {
            set
            {

            }
            get
            {
                return saltValue;
            }
        }

        public HashPassword()
        {
            saltValue = this.getRandomSalt();
        }
        protected String getRandomSalt()
        {
            var f = new byte[24];
            RNGCryptoServiceProvider gt = new RNGCryptoServiceProvider();
            gt.GetBytes(f);
            return Convert.ToBase64String(f);
        }
        public Boolean isPasswordCorrect(user me, String passd)
        {
            string passwordSave = generateHashedPassword(passd, me.passwordSalt);
            if (passwordSave == me.password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string createHashedPassword(string password)
        {
            string fullpassword = password + salt;
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Encoding.ASCII.GetBytes(fullpassword);
            byte[] resultBytes = sha.ComputeHash(dataBytes);
            return Convert.ToBase64String(resultBytes);
        }
        private string generateHashedPassword(string thepassword, string thesalt)
        {
            string fullpassword = thepassword + thesalt;
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Encoding.ASCII.GetBytes(fullpassword);
            byte[] resultBytes = sha.ComputeHash(dataBytes);
            return Convert.ToBase64String(resultBytes);
        }
    }
}