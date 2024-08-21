using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 医院住院药房管理系统.Model
{
    public class User
    {
        /// <summary>
        /// 用户类型；
        /// </summary>
        public string TypeNo { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string IDName { get; set; }
        /// <summary>
        /// 密码加密
        /// </summary>
        public byte[] Password { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActivated { get; set; }
        /// <summary>
        /// 登录错误次数；
        /// </summary>
        public int LoginFailCount { get; set; }
    }
}
