using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Utilities
{
    public class Function
    {
        public static int _UserId = 0;
        public static string _UserName = String.Empty;
        public static string _Email = String.Empty;
        public static string _Message = String.Empty;
        public static string _MessageEmail= String.Empty;
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] resul = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < resul.Length; i++)
            {
                strBuilder.Append(resul[i].ToString("x2"));
            }
            return strBuilder.ToString();


        }
        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);
            for (int i = 0; i <= 5; i++)
                str = MD5Hash(str + "_" + str);
            return str;
        }

        
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Function._UserName) || string.IsNullOrEmpty(Function._Email) || (Function._UserId <= 0)) 
            return false;
            return true;
        }      

    }
}
