using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleTest
{
    public class IdGenerator
    {
        public IdGenerator()
        {
        }


        public static void testUsers()
        {
            Dictionary<string, Guid> dict = new Dictionary<string, Guid>();
            
            var sb = new StringBuilder();
            sb.Append("重复的字符串：\n");
            using (StreamReader sr = new StreamReader("userids.csv"))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    var linedata = line.Split(',');
                    var guid = Guid.Parse(linedata[0].Trim('"'));
                    var shortStr = ToShortString2(guid);
                    Console.WriteLine($"{guid} 转8位：{shortStr} \n");
                    if (dict.ContainsKey(shortStr))
                    {
                        sb.Append($"{guid} 转8位后 {shortStr} 与 {dict[shortStr]} 转换后的一样  \n");
                    }
                    else
                    {
                        dict.Add(shortStr, guid);
                    }
                }
            }
            Console.WriteLine(sb);

        }

        public static void testUsers2()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var rd = new Random();
            var sb = new StringBuilder();
            sb.Append("重复的字符串：\n");
            using (StreamReader sr = new StreamReader("userids.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var userid = line.Split(',')[0].Trim('"');
                    var useridstr = userid.Replace("-", String.Empty);
                    var tempstr = useridstr.Substring(0, 8) + rd.Next(1000, 9999);
                    
                    var convertedstr = "00" + toShortString3(tempstr);
                    Console.WriteLine($"{tempstr} 转8位：{convertedstr} \n");
                    if (dict.ContainsKey(convertedstr))
                    {
                        sb.Append($"{tempstr} 转8位后 {convertedstr} 与 {dict[convertedstr]} 转换后的一样  \n");
                    }
                    else
                    {
                        dict.Add(convertedstr, tempstr);
                    }
                }
            }
            Console.WriteLine(sb);
        }

        public static void test()
        {


            //var num = 10000000;

           
            //Dictionary<string, string> dict = new Dictionary<string, string>();

            //var sb = new StringBuilder();
            //int repeatNum = 0;

            //sb.Append("重复的：\n");

            //while (--num >= 0)
            //{
            //    //var shortstr = GenerateUniqueId(8);
            //    //Random random = new Random(GetRandomSeed());
            //    var shortstr = GetUniqueIdentifier(8);
            //    if (dict.ContainsKey(shortstr))
            //    {
            //        sb.Append($"{shortstr}, {shortstr}  \n");
            //        repeatNum++;
            //    }
            //    else
            //    {
            //        dict.Add(shortstr, shortstr);
            //    }
            //    Console.WriteLine($"对应的8位字符串：{shortstr}");
            //}

           
            //Console.WriteLine(sb);
            //Console.WriteLine($"重复数量：{repeatNum}");

            
        }


        public static void testStep()
        {
            Guid g1 = Guid.Parse("a2676c8a-c1aa-4da4-8624-abcf00ce5ba9");
            Guid g2 = Guid.Parse("e2e61cd2-01b0-4548-ae04-ab6f008e56bb");
            string r1 = ToShortString2(g1);
            string r2 = ToShortString2(g2);


        }


        public static string ToShortString(Guid guid)
        {
            byte[] buffer = guid.ToByteArray();
            string s = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
            var d = "";
            for (var f = 0; f < 16; f+=2)
            {
                var g = Convert.ToInt32(buffer[f]);
                d += s[(g ^ Convert.ToInt32(buffer[f + 1])) - g & 0x1F];
            }
            return d;
        }

        public static string ToShortString2(Guid guid)
        {
            byte[] buffer = guid.ToByteArray();
            string s = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
            var d = "";
            for (var f = 0; f < 16; f+=2)
            {
                var g = Convert.ToInt32(buffer[f]);
                if (f < 14)
                {
                    d += s[(g ^ Convert.ToInt32(buffer[f + 1]) ^ Convert.ToInt32(buffer[f + 2])) - g & 0x1F];
                }
                else
                {
                    d += s[(g ^ Convert.ToInt32(buffer[f + 1])) - g & 0x1F];
                }
                
            }
            return d;
        }


        public static string toShortString3(string str)
        {
            string s = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
            var d = "";
            for (var i = 0; i < str.Length; i+=2)
            {
                var d1 = Convert.ToInt32(str.Substring(i, 2), 16);
                if (i < 10)
                {
                    var d2 = Convert.ToInt32(str.Substring(i + 2, 2), 16);
                    d += s[(d1 ^ d2) - d1 & 0x1F];
                }
                else
                {
                    d += s[d1 & 0x1F];
                }
                
            }
            return d;
        }


        private static int rep = 0;

        public static string GenerateCheckCode(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
        /// <summary>
        /// 重复多
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string GenerateCheckCodeNum(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                int num = random.Next();
                str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
            }
            return str;
        }

        /// <summary>
        /// 重复多
        /// </summary>
        /// <param name="CodeCount"></param>
        /// <returns></returns>
        private static string GetRandomCode(int CodeCount)
        {
            string allChar = "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(allCharArray.Length - 1);

                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }
            return RandomCode;
        }

        /// <summary>
        /// 重复率低 1000万个26个重复
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GenerateUniqueId(int num)
        {
            string randomResult = string.Empty;
            string readyStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] rtn = new char[num];
            Guid gid = Guid.NewGuid();
            var ba = gid.ToByteArray();
            for (var i = 0; i < num; i++)
            {
                rtn[i] = readyStr[((ba[i] * ba[i] + ba[num + i]) % 35)];
            }
            foreach (char r in rtn)
            {
                randomResult += r;
            }
            return randomResult;

        }

        /// <summary>
        /// 测试1000万重复50几万
        /// </summary>
        /// <returns></returns>
        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }


        /// <summary>
        /// TODO:测试
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string getRandomDom(int count)
        {
            string t62 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            long ticks = DateTime.Now.Ticks;

            string gen = "";
            int ind = 0;
            while (ind < count)
            {
                byte low = (byte)((ticks >> ind * 6) & 61);
                gen += t62[low];
                ind++;
            }
            return gen;
        }


        /// <summary>
        /// TODO:测试 1000万重复50个
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetUniqueIdentifier(int length)
        {
            int maxSize = length;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            // Unique identifiers cannot begin with 0-9
            if (result[0] >= '0' && result[0] <= '9')
            {
                return GetUniqueIdentifier(length);
            }
            return result.ToString().ToUpper();
        }

        public static long GuidToInt64()
        {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(bytes, 0);
        }
    }
}
