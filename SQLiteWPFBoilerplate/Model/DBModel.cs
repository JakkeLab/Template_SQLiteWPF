using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWPFBoilerplate.Model
{
    public class DBModel : INotifyPropertyChanged
    {
		public DBModel()
		{

        }

		//DBPath
		private string _dbPath;
		public string DBPath
		{
			get { return _dbPath; }
			set 
			{ 
				_dbPath = value;
				OnPropertyChanged("DBPath");
            }
		}

		//DBConnection
		private SQLiteConnection _dbConnection;
		public SQLiteConnection DBConnection
		{
			get { return _dbConnection; }
			set 
			{ 
				_dbConnection = value;
				OnPropertyChanged("DBConnection");
			}
		}

		//INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
