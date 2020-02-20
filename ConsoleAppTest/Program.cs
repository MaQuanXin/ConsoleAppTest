using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MD5Encrypt();
        }

        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        public static void MD5Encrypt()
        {
            string str = "Count=1&GuiGe=红色_XL&MemberId=C3B57B68-3BBF-45DA-9B16-B3BE88F2A535&ProductID=4&Timestamp=1581903401&Sign=zhijukeji";
            byte[] buffer = Encoding.UTF8.GetBytes(str); //将字符串解析成字节数组，随便按照哪种解析格式都行  2020-02-20 16:12:21 by-mQx 不是每种格式都行，需要两方进行协商
            MD5 md5 = MD5.Create();  //使用MD5这个抽象类的Creat()方法创建一个虚拟的MD5类的对象。
            byte[] bufferNew = md5.ComputeHash(buffer); //使用MD5实例的ComputerHash()方法处理字节数组。
            string strNew = null;
            for (int i = 0; i < bufferNew.Length; i++)
            {
                strNew += bufferNew[i].ToString("x2");  //对bufferNew字节数组中的每个元素进行十六进制转换然后拼接成strNew字符串
                //strNew += Convert.ToString(bufferNew[i], 16).PadLeft(2, '0');
            }
            Console.WriteLine(strNew);  //输出加密后的字符串
            Console.ReadKey();
        }
        #endregion

        #region 运气红包
        /// <summary>
        /// 运气红包
        /// </summary>
        public void RandomRedEnvelope()
        {
            int remainCount = 20;
            decimal remainMoney = 50;

            Console.WriteLine("==================================");
            Console.WriteLine("剩余次数：" + remainCount);
            Console.WriteLine("剩余金额：" + remainMoney);

            decimal amount = 0;
            decimal allAmount = 0;

            while (remainCount > 0)
            {
                if (remainCount == 1)
                {
                    amount = Math.Round(remainMoney * 100) / 100;
                }
                else if (remainCount > 1)
                {
                    Random random = new Random();
                    decimal min = 0.01M; //
                    decimal max = remainMoney / remainCount * 2;
                    amount = Convert.ToDecimal(random.NextDouble()) * max;
                    amount = amount <= min ? 0.01M : amount;
                    amount = Math.Floor(amount * 100) / 100;
                }
                remainCount--;
                remainMoney -= amount;
                Console.WriteLine("==================================");
                Console.WriteLine("剩余次数：" + remainCount);
                Console.WriteLine("剩余金额：" + remainMoney);
                Console.WriteLine("红包：" + amount);

                allAmount += amount;
            }

            Console.WriteLine("======结束=====");
            Console.WriteLine(allAmount);
            Console.WriteLine("======结束=====");
        } 
        #endregion
    }
}
