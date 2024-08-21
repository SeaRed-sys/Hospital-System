using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 医院住院药房管理系统.DataAccessLayer
{
    /// <summary>
	/// 违反唯一性异常；
	/// </summary>
	public class NotUniqueException : Exception { }
    /// <summary>
    /// SQL助手；
    /// </summary>
    public class SQLHepler
    {
        /// <summary>
        /// SQL命令；
        /// </summary>
        public  SqlCommand SqlCommand { get; set; }
        /// <summary>
        /// SQL参数；
        /// </summary>
        private SqlParameter SqlParameter { get; set; }
       
        /// <summary>
        /// 新建SQL命令；
        /// </summary>
        /// <returns>SQL助手</returns>
        public SQLHepler NewCommand()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            this.SqlCommand = sqlConnection.CreateCommand();
            return this;
        }
        /// <summary>
        /// 新建SQL命令；
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <returns>SQL助手</returns>
        public SQLHepler NewCommand(string commandText)
        {
            this.NewCommand();
            return this.CommandText(commandText);
        }
        /// <summary>
        /// 设置SQL命令的命令文本
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <returns>SQL助手</returns>
        public SQLHepler CommandText(string commandText)
        {
            this.SqlCommand.CommandText = commandText;
            return this;
        }
        /// <summary>
        /// 设置SQL命令是否存储过程；
        /// </summary>
        /// <param name="isStoredProcedure">是否存储过程</param>
        /// <returns>SQL助手</returns>
        public SQLHepler IsStoredProcedure(bool isStoredProcedure = true)
        {
            this.SqlCommand.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            return this;
        }
        /// <summary>
        /// 新建SQL参数；
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <returns>SQL助手</returns>
        public SQLHepler NewParameter(string parameterName)
        {
            this.SqlParameter = new SqlParameter();
            this.SqlParameter.ParameterName = parameterName;
            this.SqlCommand.Parameters.Add(this.SqlParameter);
            return this;
        }
        /// <summary>
        /// 新建SQL参数；
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="value">参数值</param>
        /// <returns>SQL助手</returns>
        public SQLHepler NewParameter(string parameterName, object value)
        {
            this.NewParameter(parameterName);
            this.SqlParameter.Value = value;
            return this;
        }
        /// <summary>
        /// 设置SQL参数的SQL Server数据类型；
        /// </summary>
        /// <param name="sqlDbType">SQL Server数据类型</param>
        /// <returns>SQL助手</returns>
        public SQLHepler ParameterType(SqlDbType sqlDbType)
        {
            this.SqlParameter.SqlDbType = sqlDbType;
            return this;
        }
        /// <summary>
        /// 设置SQL参数的长度；
        /// </summary>
        /// <param name="size">长度</param>
        /// <returns>SQL助手</returns>
        public SQLHepler ParameterSize(int size)
        {
            this.SqlParameter.Size = size;
            return this;
        }
        /// <summary>
        /// 设置SQL参数的值；
        /// </summary>
        /// <param name="value">参数值</param>
        /// <returns>SQL助手</returns>
        public SQLHepler ParameterValue(object value)
        {
            this.SqlParameter.Value = value;
            return this;
        }
        /// <summary>
        /// 设置SQL参数的方向；
        /// </summary>
        /// <param name="parameterDirection">参数方向</param>
        /// <returns>SQL助手</returns>
        public SQLHepler ParameterDirection(ParameterDirection parameterDirection)
        {
            this.SqlParameter.Direction = parameterDirection;
            return this;
        }
        /// <summary>
        /// 执行SQL命令，获取标量；
        /// </summary>
        /// <typeparam name="T">标量类型</typeparam>
        /// <returns>标量值</returns>
        public T GetScalar<T>()
        {
            object result = null;
            this.SqlCommand.Connection.Open();
            result = this.SqlCommand.ExecuteScalar();
            this.SqlCommand.Connection.Close();
            return (T)result;
        }
        /// <summary>
        /// 执行SQL命令，获取数据读取器；
        /// 完成读取后，请手动关闭数据读取器；
        /// </summary>
        /// <returns>数据读取器</returns>
        public SqlDataReader GetReader()
        {
            this.SqlCommand.Connection.Open();
            SqlDataReader sqlDataReader = this.SqlCommand.ExecuteReader();
            return sqlDataReader;
        }
        public SqlDataAdapter GetAdapter()
        {
            this.SqlCommand.Connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(this.SqlCommand);
            return sqlDataAdapter;
        }
        /// <summary>
        /// 执行SQL命令，写入表
        /// </summary>
        /// <returns>数据表</returns>
        public DataTable GetTable()
        {
            this.SqlCommand.Connection.Open();
            DataTable table = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(this.SqlCommand);
            sqlDataAdapter.Fill(table);
            return table;
        }
        /// <summary>
        /// 执行SQL命令，写入表
        /// </summary>
        /// <returns>数据表</returns>
        public DataSet GetDataSet()
        {
            this.SqlCommand.Connection.Open();
            DataSet table = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(this.SqlCommand);
            sqlDataAdapter.Fill(table);
            return table;
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        public void GetCom()
        {
            this.SqlCommand.Connection.Open();
            this.SqlCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行SQL命令，写入数据；
        /// </summary>
        /// <returns>受影响行数</returns>
        public int NonQuery()
        {
            int rowAffected = 0;
            try
            {
                this.SqlCommand.Connection.Open();
                rowAffected = this.SqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627)
                {
                    MessageBox.Show("编号已存在！");
                }
                else
                {
                    MessageBox.Show("添加失败。请联系管理员！");
                }
            }
            finally
            {
                this.SqlCommand.Connection.Close();
            }
            return rowAffected;
        }

    }
}
