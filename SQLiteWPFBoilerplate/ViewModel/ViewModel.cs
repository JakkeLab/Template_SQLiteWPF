using SQLiteWPFBoilerplate.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWPFBoilerplate.ViewModel
{
    public static class ViewModel
    {
		private static DBModel _dbModel;

		public static DBModel DBModel
		{
			get { return _dbModel; }
			set { _dbModel = value; }
		}

	}
}
