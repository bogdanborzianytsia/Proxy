using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prroxy
{
    public interface IDatabase
    {
        void Query(string command);
    }
    public class Database : IDatabase
    {
        public void Query(string command)
        {
            MessageBox.Show($"Executing command: {command}");
        }
    }

    public class DatabaseProxy : IDatabase
    {
        private Database _realDatabase;
        private bool _isAdmin;

        public DatabaseProxy(bool isAdmin)
        {
            _isAdmin = isAdmin;
        }

        public void Query(string command)
        {
            if (_realDatabase == null)
            {
                _realDatabase = new Database();
            }

            if (_isAdmin)
            {
                _realDatabase.Query(command);
            }
            else
            {
                if (command.StartsWith("SELECT"))
                {
                    _realDatabase.Query(command);
                }
                else
                {
                    MessageBox.Show("Access denied. Only SELECT commands are allowed for non-admin users.");
                }
            }
        }
    }
}
