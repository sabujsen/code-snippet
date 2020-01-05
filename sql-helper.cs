public static class SqlHelper
    {
        #region "FILL DATA TABLE"

        public static void Fill(DataTable dataTable, String procedureName)
        {
            //SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());
            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;

                    oAdapter.Fill(dataTable);

                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oAdapter.Dispose();
                }
            }
        }

        public static void Fill(DataTable dataTable, String procedureName, SqlParameter[] parameters)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)

                oCommand.Parameters.AddRange(parameters);

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;

                    oAdapter.Fill(dataTable);

                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oAdapter.Dispose();
                }
            }
        }

        #endregion "FILL DATA TABLE"

        #region "Filter if Recort is Exist in the Table."

        public static bool recordExist(string sSQL, string sTable)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());
            long totalRow = 0;
            //Set the Data Adapter
            SqlDataAdapter da = new SqlDataAdapter(sSQL, oConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, sTable);

            totalRow = Convert.ToInt32(ds.Tables[sTable].Rows.Count);
            if (totalRow > 0) { return true; }
            else { return false; }
        }

        #endregion "Filter if Recort is Exist in the Table."

        #region "FILL DATASET"

        public static void Fill(DataSet dataSet, String procedureName)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;

                    oAdapter.Fill(dataSet);

                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oAdapter.Dispose();
                }
            }
        }

        public static DataSet Fill(String sql, string tableName)
        {
            DataSet dataSet = new DataSet();
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(sql, oConnection);

            oCommand.CommandType = CommandType.Text;

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;
                    oAdapter.Fill(dataSet, tableName);
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();
                    oAdapter.Dispose();
                }
            }
            return dataSet;
        }

        public static void Fill(DataSet dataSet, String procedureName, SqlParameter[] parameters)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)

                oCommand.Parameters.AddRange(parameters);

            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oAdapter.SelectCommand = oCommand;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oAdapter.SelectCommand.Transaction = oTransaction;

                    oAdapter.Fill(dataSet);

                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oAdapter.Dispose();
                }
            }
        }

        #endregion "FILL DATASET"

        #region "EXECUTE SCALAR"

        public static object ExecuteScalarSql(String sql)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(sql, oConnection);

            oCommand.CommandType = CommandType.Text;

            object oReturnValue;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oCommand.Transaction = oTransaction;

                    oReturnValue = oCommand.ExecuteScalar();

                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oCommand.Dispose();
                }
            }

            return oReturnValue;
        }

        public static object ExecuteScalar(String procedureName)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;

            object oReturnValue;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oCommand.Transaction = oTransaction;

                    oReturnValue = oCommand.ExecuteScalar();

                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oCommand.Dispose();
                }
            }

            return oReturnValue;
        }

        public static object ExecuteScalar(String procedureName, SqlParameter[] parameters)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;

            object oReturnValue;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    if (parameters != null)

                        oCommand.Parameters.AddRange(parameters);

                    oCommand.Transaction = oTransaction;

                    oReturnValue = oCommand.ExecuteScalar();

                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oCommand.Dispose();
                }
            }

            return oReturnValue;
        }

        #endregion "EXECUTE SCALAR"

        public static bool ExecuteReader(String sql)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(sql, oConnection);

            oCommand.CommandType = CommandType.Text;

            bool oReturnValue = false;
            oConnection.Close();
            SqlDataReader myReader;
            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oCommand.Transaction = oTransaction;

                    using (myReader = oCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            oReturnValue = true;
                        }
                        myReader.Close();
                    }
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oCommand.Dispose();
                }
            }

            return oReturnValue;
        }

        #region "EXECUTE NON QUERY"

        public static int ExecuteDML(string sql)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(sql, oConnection);

            oCommand.CommandType = CommandType.Text;

            int iReturnValue;
            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oCommand.Transaction = oTransaction;
                    iReturnValue = oCommand.ExecuteNonQuery();
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();

                    oConnection.Dispose();

                    oCommand.Dispose();
                }
            }

            return iReturnValue;
        }

        public static int ExecuteNonQuery(string Sql)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(Sql, oConnection);

            oCommand.CommandType = CommandType.Text;

            int iReturnValue;
            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    oCommand.Transaction = oTransaction;
                    iReturnValue = oCommand.ExecuteNonQuery();
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)
                        oConnection.Close();

                    oConnection.Dispose();

                    oCommand.Dispose();
                }
            }

            return iReturnValue;
        }

        public static int ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
        {
            SqlConnection oConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringImageService"].ToString());

            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);

            oCommand.CommandType = CommandType.StoredProcedure;

            int iReturnValue;

            oConnection.Open();

            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
            {
                try
                {
                    if (parameters != null)

                        oCommand.Parameters.AddRange(parameters);

                    oCommand.Transaction = oTransaction;

                    iReturnValue = oCommand.ExecuteNonQuery();

                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();

                    throw;
                }
                finally
                {
                    if (oConnection.State == ConnectionState.Open)

                        oConnection.Close();

                    oConnection.Dispose();

                    oCommand.Dispose();
                }
            }

            return iReturnValue;
        }

        #endregion "EXECUTE NON QUERY"
    }
