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

namespace Final_JainiTopiwala
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntities db = new NorthwindEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btngetEmp_Click(object sender, RoutedEventArgs e)
        {
            var employees = db.Employees.Select(emp => new
            {
                emp.EmployeeID, emp.FirstName, emp.LastName, emp.Title, BirthDate = emp.BirthDate
            }).ToList();

            grdEmployees.ItemsSource = employees;
        }

        private void btnEmpbyfname_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstname.Text; 
            var employees = db.Employees.Where(emp => emp.FirstName.Contains(firstName)).Select(emp => new
            {
                emp.EmployeeID, emp.FirstName, emp.LastName, emp.Title, BirthDate = emp.BirthDate
            }).ToList();

            grdEmployees.ItemsSource = employees;
        }

        private void btnEmpbyage_Click(object sender, RoutedEventArgs e)
        {
            var employees = db.Employees.Select(emp => new
            {
                emp.EmployeeID, emp.FirstName, emp.LastName, emp.Title,
                BirthDate = emp.BirthDate, Age = DateTime.Now.Year - emp.BirthDate.Value.Year
            }).OrderByDescending(emp => emp.Age).ToList();

            grdEmployees.ItemsSource = employees;
        }

        private void btngetOrders_Click(object sender, RoutedEventArgs e)
        {
            var employees = db.Employees.Select(emp => new
            {
                emp.EmployeeID, emp.FirstName, emp.LastName, emp.Title,
                BirthDate = emp.BirthDate, Age = DateTime.Now.Year - emp.BirthDate.Value.Year
            }).OrderByDescending(emp => emp.Age).ToList();

            grdEmployees.ItemsSource = employees;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
