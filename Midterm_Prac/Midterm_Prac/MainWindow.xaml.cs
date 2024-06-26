using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Midterm_Prac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employees;
        public MainWindow()
        {
            InitializeComponent();

            employees = new List<Employee>();

            HourlyEmployee he1 = new HourlyEmployee("Jaini", 40, 20.5m);
            HourlyEmployee he2 = new HourlyEmployee("Nisarg", 50, 10.5m);
            CommissionEmployee ce1 = new CommissionEmployee("Shivani", 10, 25.5m);
            CommissionEmployee ce2 = new CommissionEmployee("Khushi", 60, 40.5m);


            employees.Add(he1);
            employees.Add(he2);
            employees.Add(ce1);
            employees.Add(ce2);

            RefreshEmployeeList();
        }

        private void lstbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstbox.SelectedItem != null)
            {
                string selectedName = lstbox.SelectedItem as string;
                Employee selectedEmployee = employees.FirstOrDefault(emp => emp.EmployeeName == selectedName);

                if (selectedEmployee != null)
                {
                    txtname.Text = selectedEmployee.EmployeeName;

                    if (selectedEmployee is HourlyEmployee hourlyEmp)
                    {
                        txthoursworked.Text = hourlyEmp.Hours.ToString();
                        txtwagerate.Text = hourlyEmp.Wage.ToString();
                    }
                    else if (selectedEmployee is CommissionEmployee commissionEmp)
                    {
                        txthoursworked.Text = commissionEmp.Sales.ToString();
                        txtwagerate.Text = commissionEmp.Rate.ToString(); 
                    }
                }
            }

        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (lstbox.SelectedItem != null)
            {
                string selectedName = lstbox.SelectedItem as string;
                Employee selectedEmployee = employees.FirstOrDefault(emp => emp.EmployeeName == selectedName);

                if (selectedEmployee != null)
                {
                    txtearning.Text = selectedEmployee.GrossEarnings.ToString("C2"); // Format as currency
                }
            }
        }

        private void RefreshEmployeeList()
        {
            lstbox.ItemsSource = employees.Select(emp => emp.EmployeeName).ToList();
        }
    }
}