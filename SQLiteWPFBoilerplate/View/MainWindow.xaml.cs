using Microsoft.Win32;
using SQLiteWPFBoilerplate.SQLiteControls;
using SQLiteWPFBoilerplate.ViewModel;
using System;
using System.Collections.Generic;
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

namespace SQLiteWPFBoilerplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSetPath_Click(object sender, RoutedEventArgs e)
        {
            //FileDialog Setting
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Multiselect = false;
            openFileDlg.Title = "Select SQLite DB File";
            openFileDlg.InitialDirectory = Environment.CurrentDirectory;
            openFileDlg.Filter = "DB Files (*.db)";

            //Run Dialog
            openFileDlg.ShowDialog();
            var dbFileName = openFileDlg.FileName;

            //Save on ViewModel
            VM.DBModel.DBPath = dbFileName;
        }

        private void btnSendQuery_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCreateNewDB_Click(object sender, RoutedEventArgs e)
        {
            DBControl dbControl = new DBControl();

            //SaveFile Dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Create New DB File";
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.Filter = "DB File (*.db)";

            //Run Dialog
            saveFileDialog.ShowDialog();
            var dbPath = saveFileDialog.FileName;

            //Create new DBFile
            dbControl.CreateDB(dbPath);
        }
    }
}
