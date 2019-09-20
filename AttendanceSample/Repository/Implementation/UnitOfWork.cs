using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AttendanceSample.Repository.Interface;

namespace AttendanceSample.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction {get; set; }
        
        private bool _disposed;

        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;
        }

        public void Begin()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Dispose();
        }

        #region Default Implementation For IDisposable. Do not change

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                        Transaction = null;
                    }
                }
                _disposed = true;
            }
        }

        #endregion

    }
}
