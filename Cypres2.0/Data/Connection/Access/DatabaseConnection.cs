using System;
using System.Data.OleDb;
using System.IO;
using System.Windows; 

namespace Cypres2._0.Data.Connection.Access
{
    public class DatabaseConnection: IDatabaseConnection
    {
        private const string DatabaseFolder = "Database"; // relative to .exe output folder
        private const string DatabaseFileName = "Cypres2.0.accdb"; // change extension if it's .mdb

        private string? _connectionString;
        public string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
                    string dbFullPath = Path.Combine(projectRoot, DatabaseFolder, DatabaseFileName);

                    if (!File.Exists(dbFullPath))
                        throw new FileNotFoundException($"Database file not found: {dbFullPath}");

                    _connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbFullPath};";
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// Tests if the connection can be opened successfully.
        /// Use this for startup checks or a "Test Connection" button.
        /// </summary>
        public bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (var connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    return true; 
                }
            }
            catch (OleDbException ex)
            {
                errorMessage = $"OLEDB Error: {ex.Message} (Code: {ex.ErrorCode})";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Unexpected error: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// Returns an open connection (caller must dispose it!).
        /// Use in using blocks: using var conn = GetOpenConnection();
        /// </summary>
        public OleDbConnection GetOpenConnection()
        {
            var conn = new OleDbConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        // Example: Quick helper to get row count from a table (for testing)
        public int GetTableRowCount(string tableName)
        {
            using var conn = GetOpenConnection();
            using var cmd = new OleDbCommand($"SELECT COUNT(*) FROM [{tableName}]", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}