using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testDemo
{
    //中缀表达式生成器
    static class InfixCreater
    {
        //操作符个数
        public static int OperatorNum
        {
            set;
            get;
        }
        //操作数个数
        public static int OperandNum
        {
            set;
            get;
        }
        public static bool HaveBracket
        {
            set;
            get;
        }
        /// <summary>
        /// 初始化中缀表达式生成器
        /// </summary>
        /// <param name="haveBracket">是否有括号</param>
        public static void InitInfixCreater(bool haveBracket)
        {
            Random r = new Random();
            OperatorNum =r.Next(2,6);
            OperandNum = OperatorNum + 1;
            HaveBracket = haveBracket;
        }
        /// <summary>
        /// 生成一个中缀表达式
        /// </summary>
        /// <param name="haveDecimal">是否含有小数</param>
        /// <param name="Max">数字最大值是多少</param>
        /// <param name="type">题目类型</param>
        /// <returns></returns>
        public static string InfixCreate(bool haveDecimal,int Max,int type)
        {
            ArrayList list = new ArrayList();
            OperatorCreater operatorCreater = new OperatorCreater(type+1);
            bool operatorflag = false;
            Random r = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i <OperandNum+OperatorNum; i++)
            {
                list.Add(' ');
                if (!operatorflag && OperandNum > 0)
                {
                    if (haveDecimal && OperandNum > 0)
                    {
                        Thread.Sleep(10);
                        int operand1 = r.Next(1, Max);
                        double operand2 = r.NextDouble();
                        string str = operand2.ToString();
                        double operand = Convert.ToDouble(str.Substring(0, 3)) + (double)operand1;
                        list.Add(operand);
                    }
                    else
                    {
                        Thread.Sleep(10);
                        int operand = r.Next(1, Max);
                        list.Add(operand);
                    }
                    operatorflag = true;
                }
                else if (operatorflag && OperatorNum > 0)
                {
                    list.Add(operatorCreater.OperatorRandom());
                    operatorflag = false;
                }
            }
            list.Add(' ');
            // 0 4 8 12 16
            // 6 10 14 18 22
            if (HaveBracket)
            {
                int left = r.Next(0, OperatorNum) * 4;
                Thread.Sleep(10);
                int right = left + r.Next(1, OperatorNum) * 4 + 2;
                while (right > list.Count)
                {
                    Thread.Sleep(10);
                    right = left + r.Next(1, OperatorNum) * 4 + 2;
                }
                list[left] = '(';
                list[right] = ')';
            }
            list.Add('=');
            string strp=null;
            foreach (var item in list)
            {
                if(item is char)
                {
                    if ((char)item == ' ')
                    {
                        continue;
                    }
                    strp += (char)item;
                }
                if (item is int)
                {
                    strp += ((int)item).ToString();
                }
                if(item is double)
                {
                    strp += ((double)item).ToString();
                }
            }
            //bool left = true;

            return strp;
        }


    }
}
