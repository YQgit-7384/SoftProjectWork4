using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testDemo
{
    //操作符生成器
    public class OperatorCreater
    {
        //选项标志位
        public int Flag
        {
            set;
            get;
        }
        public Dictionary<int,char> Operator
        {
            set;
            get;
        }
        public OperatorCreater(int flag)
        {
            Flag = flag;
            this.CreateOperator();
        }
        /// <summary>
        ///根据标志位生成操作符字典
        /// </summary>
        private void CreateOperator()
        {
            Dictionary<int, char> ope=new Dictionary<int, char>();
            switch (Flag)
            {
                case 1:
                    ope.Add(0,'+');
                    ope.Add(1, '-');
                    break;
                case 2:
                    ope.Add(0, '*');
                    ope.Add(1, '/');
                    break;
                case 3:
                    ope.Add(0, '+');
                    ope.Add(1, '-');
                    ope.Add(2, '*');
                    ope.Add(3, '/');
                    break;
                default:
                    ope.Add(0, '+');
                    ope.Add(1, '-');
                    break;
            }
            this.Operator = ope;
        }
        /// <summary>
        /// 随机产生操作符
        /// </summary>
        /// <returns>操作符</returns>
        Random random = new Random((int)DateTime.Now.Ticks);
        public char OperatorRandom()
        {
            Thread.Sleep(10);
            int r=0;
            switch (Flag)
            {
                case 1:
                    r = random.Next(0,2);
                    break;
                case 2:
                    r = random.Next(0, 2);
                    break;
                case 3:
                    r = random.Next(0, 4);
                    break;
            }
            return this.Operator[r];
        }
    }
}
