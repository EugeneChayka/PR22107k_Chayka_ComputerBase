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

namespace Practich3.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для WarehouseWorker.xaml
    /// </summary>
    public partial class WarehouseWorker : Page
    {
        public WarehouseWorker(int id)
        {
            InitializeComponent();
            
        }
        public void DateNow(int id)
        {
            var info = Helper.GetContext().Employeey.Where(u => u.IdEmp == id).FirstOrDefault();
            DateTime currentTime = DateTime.Now;


            if (currentTime.Hour >= 10 && currentTime.Hour < 12)
            {
                lblHiEmp.Content = $"Доброе утро {info.Name} {info.Surname} {info.Patronymic}";

            }
            else if (currentTime.Hour >= 12 && currentTime.Hour <= 17)
            {
                lblHiEmp.Content = $"Добрый день {info.Name} {info.Surname} {info.Patronymic}";

            }
            else if (currentTime.Hour > 17 && currentTime.Hour <= 19)
            {
                lblHiEmp.Content = $"Добрый вечер {info.Name} {info.Surname} {info.Patronymic}";

            }
        }
    }
}
