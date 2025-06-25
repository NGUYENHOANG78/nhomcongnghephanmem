using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    /// <summary>
    /// Singleton data provider for database operations
    /// </summary>
    public sealed class DataProvider
    {
        private static readonly object _lock = new object();
        private static volatile DataProvider _instance;

        /// <summary>
        /// Gets the singleton instance of DataProvider
        /// </summary>
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new DataProvider();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Database context for data operations
        /// </summary>
        public DBContext Database { get; private set; }

        /// <summary>
        /// Private constructor to ensure singleton pattern
        /// </summary>
        private DataProvider()
        {
            Database = new DBContext();
        }

        /// <summary>
        /// Dispose database resources
        /// </summary>
        public void Dispose()
        {
            Database?.Dispose();
        }
    }
}