using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWPFBoilerplate.Model
{
    public class DBModel : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
