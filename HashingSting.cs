using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Nastol
{
    public class HashingSting
    {
        public static string HashingPassword(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashingPass = BitConverter.ToString(hash).Replace("-", "");
            var sha256 = new SHA256Managed();
            hashingPass = BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(hashingPass))).Replace("-", "");

            return hashingPass;
        }
    }
}
