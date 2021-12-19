using System;

namespace EmployeeConsoleApp.Database

{
    public class Repository : IRepository
    {
        private EmploymentDBContext _context;
        public Repository(EmploymentDBContext context)
        {
            _context = context;
        }

        public Guid InsertEmployee(Employee employee)
        {
            return _context.Employment.Add(employee).Entity.EmployeeID;
        }


        public Employee GetEmployeeByID(Guid employeeID)
        {
            return _context.Employment.Find(employeeID);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
