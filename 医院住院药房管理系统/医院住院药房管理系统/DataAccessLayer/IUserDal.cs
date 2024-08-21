using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 医院住院药房管理系统.Model;

namespace 医院住院药房管理系统.DataAccessLayer
{
    /// <summary>
    /// 用户数据访问层接口
    /// </summary>
    public interface IUserDal
    {
        /// <summary>
		/// 插入用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		int Insert(User user);
        /// <summary>
        /// 查询用户；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>用户</returns>
        User Select(string userNo);
        /// <summary>
        /// 查询用户计数;
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>计数</returns>
        int SelectCount(string userNo);
        /// <summary>
        /// 更新用户；
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>受影响行数</returns>
        int Update(User user);
    }
}
