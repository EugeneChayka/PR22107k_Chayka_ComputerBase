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
using System.Data.Entity;
using Practich3.Models;

namespace Practich3.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        
        public Admin(int id)
        {
            InitializeComponent();

            DateNow(id);
            var Emp = Helper.GetContext().Employeey.ToList();
            cbPost.ItemsSource = Helper.GetContext().Post.Select(p => p.Name).ToList();
            var additionalItems = "Все работники"; // Замените на ваши дополнительные элементы
            var currentItems = cbPost.ItemsSource as List<string>;
            currentItems.Insert(0,additionalItems);
            cbPost.ItemsSource = currentItems;
            cbPost.SelectedIndex = 0;
            LViemEmp.ItemsSource = Emp;

        }
        //Метод который при инициализации првиетствует пользователя
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

        //Фильтр пользователей по ФИО и должности
        private void btnFiltr_Click(object sender, RoutedEventArgs e)
        {
   
            var context = Helper.GetContext();

            var filteredData = context.Employeey;

            if (!string.IsNullOrEmpty(tbSurname.Text) || !string.IsNullOrEmpty(tbName.Text) || !string.IsNullOrEmpty(tbPatronymic.Text) || cbPost.SelectedIndex >= 1)
            {
                var filtered = filteredData.Where(item =>
                    (string.IsNullOrEmpty(tbSurname.Text) || item.Surname.ToLower().Contains(tbSurname.Text.ToLower())) &&
                    (string.IsNullOrEmpty(tbName.Text) || item.Name.ToLower().Contains(tbName.Text.ToLower())) &&
                    (string.IsNullOrEmpty(tbPatronymic.Text) || item.Patronymic.ToLower().Contains(tbPatronymic.Text.ToLower()))&&
                    (string.IsNullOrEmpty(cbPost.Text) || item.Post.Name.Contains(cbPost.Text))

                ).ToList();
                LViemEmp.ItemsSource = filtered;
            }
            if(cbPost.SelectedIndex==0)
                 
            {
                LViemEmp.ItemsSource = filteredData.ToList();
                if ((!string.IsNullOrEmpty(tbSurname.Text) || !string.IsNullOrEmpty(tbName.Text) || !string.IsNullOrEmpty(tbPatronymic.Text)))
                    {
                    var filtered = filteredData.Where(item =>
                    (string.IsNullOrEmpty(tbSurname.Text) || item.Surname.ToLower().Contains(tbSurname.Text.ToLower())) &&
                    (string.IsNullOrEmpty(tbName.Text) || item.Name.ToLower().Contains(tbName.Text.ToLower())) &&
                    (string.IsNullOrEmpty(tbPatronymic.Text) || item.Patronymic.ToLower().Contains(tbPatronymic.Text.ToLower()))).ToList();
                    LViemEmp.ItemsSource = filtered;
                }
                
            }
        }
        //Переход на страницу редактирования данных пользователя
        private void LViemEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var u = LViemEmp.SelectedItem as Employeey;
            NavigationService.Navigate(new Editing(u));
        }
        //Прееход на страницу с добавлением нового пользовтеля
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Employeey u= new Employeey();
            u = null;
            NavigationService.Navigate(new Editing(u));
        }
        //Проверка на вводимымы значения, должны быть только буквы
        private void tbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        //Проверка на вводимымы значения, должны быть только буквы
        private void tbSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        //Проверка на вводимымы значения, должны быть только буквы
        private void tbPatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
    }

