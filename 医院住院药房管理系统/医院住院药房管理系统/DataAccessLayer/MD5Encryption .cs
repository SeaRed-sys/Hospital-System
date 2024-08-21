using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 医院住院药房管理系统.DataAccessLayer
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class MD5Encryption
    {
        public  string ComputeMD5Hash(string input)
        {
            // 使用UTF8编码  
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // 创建一个MD5CryptoServiceProvider对象  
            using (MD5 md5Hash = MD5.Create())
            {
                // 计算输入字符串的哈希值  
                byte[] data = md5Hash.ComputeHash(inputBytes);

                // 创建一个StringBuilder来收集字节并创建字符串  
                StringBuilder sBuilder = new StringBuilder();

                // 遍历数据并格式化为十六进制字符串  
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // 返回十六进制字符串  
                return sBuilder.ToString();
            }
        }
    }
}