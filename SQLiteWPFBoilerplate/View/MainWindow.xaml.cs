using Microsoft.Win32;
using SQLiteWPFBoilerplate.SQLiteControls;
using SQLiteWPFBoilerplate.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VM = SQLiteWPFBoilerplate.ViewModel.ViewModel;

namespace SQLiteWPFBoilerplate.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBControl dbControl = new DBControl();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM.DBModel;
            btnConnectDB.IsEnabled = false;
            btnSendQuery.IsEnabled = false;
        }

        private void btnSetPath_Click(object sender, RoutedEventArgs e)
        {
            //FileDialog Setting
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Multiselect = false;
            openFileDlg.Title = "Select SQLite DB File";
            openFileDlg.InitialDirectory = Environment.CurrentDirectory;
            openFileDlg.Filter = "DB Files (*.db) | *.db";

            //Run Dialog
            var dialogResult = openFileDlg.ShowDialog();
            var dbFileName = openFileDlg.FileName;

            //Save on ViewModel
            if (dialogResult == true)
            {
                //Save on ViewModel
                VM.DBModel.DBPath = dbFileName;
                btnConnectDB.IsEnabled = true;
            }
        }

        private void btnCreateNewDB_Click(object sender, RoutedEventArgs e)
        {
            //SaveFile Dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Create New DB File";
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.Filter = "DB File (*.db) | *.db";

            //Run Dialog
            var dialogResult = saveFileDialog.ShowDialog();
            var dbPath = saveFileDialog.FileName;

            //Save on ViewModel
            if (dialogResult == true)
            {
                //Create new DBFile
                dbControl.CreateDB(dbPath);
                VM.DBModel.DBPath = dbPath;
                btnConnectDB.IsEnabled = true;
            }
        }

        private void btnSendQuery_Click(object sender, RoutedEventArgs e)
        {
            DBControl dbControl = new DBControl();
            var result = dbControl.SendQuery($@"{tbQuery.Text}", VM.DBModel.DBConnection);
            if (result == null)
            {
                WriteOnLog("Null");
            }
            else
            {
                WriteOnLog(result);
            }
            tbQuery.Text = string.Empty;
        }

        private void btnConnectDB_Click(object sender, RoutedEventArgs e)
        {
            var conn = dbControl.ConnectDB(VM.DBModel.DBPath);
            if(conn.State == System.Data.ConnectionState.Open)
            {
                WriteOnLog("Connected");
                btnSendQuery.IsEnabled = true;
                VM.DBModel.DBConnection = conn;
            }
        }

        private void WriteOnLog(string message)
        {
            if(tbLog.Text == string.Empty)
            {
                tbLog.Text += "\r----------------\n";
            }
            else
            {
                tbLog.Text += "----------------\n";
            }
            tbLog.Text += message;
        }

        private bool IsConnected()
        {
            if(VM.DBModel.DBConnection == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
