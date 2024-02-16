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
using System.Windows.Controls.Primitives;
using System.Xml.Linq;
using HashPassword;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;


namespace Practich3.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Editing.xaml
    /// </summary>
    public partial class Editing : Page
    {
       
        //Переменная хранящая пользовтаеля
        private Employeey emp;
        public Editing(Employeey user)
        {

            InitializeComponent();
            //Если пользовтаель равен Null, очищаем поля и скрываем кнопку редактирования, это для добавление нового пользователя
            if (user == null)
            {
                btnEdit.Visibility = Visibility.Hidden;
                cbPost.Items.Clear();
                cbPost.ItemsSource = Helper.GetContext().Post.Select(p => p.Name).ToList();
                cbPost.SelectedIndex = 0;
            }
            //Если пользовтаель равен Null, заполняем поля его данными и скрываем кнопку добавления и очистки, это для редактировани существующего пользователя
            else
            {   
                //Сохраняем пользователя и используем его в редактировании 
                emp = Helper.GetContext().Employeey.Find(user.IdEmp);
                cbPost.Items.Clear();
                cbPost.ItemsSource = Helper.GetContext().Post.Select(p => p.Name).ToList();

                cbPost.SelectedIndex = cbPost.Items.IndexOf(user.Post.Name);
                tbName.Text = user.Name;
                tbSurname.Text = user.Surname;
                tbPatronymic.Text = user.Patronymic;
                tbPhone.Text = user.PhoneNumber;
                tbEmail.Text = user.Email;
                tbLogin.Text = user.Users.Login;

                btnAdd.Visibility = Visibility.Hidden;
                btnClear.Visibility = Visibility.Hidden;
            }

        }
        //редактирование пользователя
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hashPassword hasher = new hashPassword();
                string hashPass = hasher.HashingPassword(tbPassword.Text);

                string post = cbPost.Text;
                var info = Helper.GetContext().Post.Where(u => u.Name == post).FirstOrDefault();


                emp.IdPost = info.IdPost;
                emp.Name = tbName.Text;
                emp.Surname = tbSurname.Text;
                emp.Patronymic = tbPatronymic.Text;
                emp.PhoneNumber = tbPhone.Text;
                emp.Email = tbEmail.Text;

                emp.Users.Login = tbLogin.Text;
                if (tbPassword.Text != null)
                {
                    emp.Users.Password = hashPass;
                }
                //Валидация данных
                var context = new ValidationContext(emp);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                if (!Validator.TryValidateObject(emp, context, results, true))
                {
                    string errores ="";

                    foreach (var error in results)
                    {
                        errores += error.ErrorMessage +"\n";
                    }
                    MessageBox.Show($"Не удалось отредактировать по причине:\n {errores}");
                }
                else
                    MessageBox.Show($"Данные о сотруднике успешно отредактированы");
                //Меняем соостояние для редактирования данных
                Helper.GetContext().Entry(emp).State = EntityState.Modified;
                Helper.GetContext().SaveChanges();
            }catch (Exception ex) { }
        }
        //Добавление нового пользователя
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CompBaseEntities CompEntities = new CompBaseEntities();
                hashPassword hasher = new hashPassword();
                string hashPass = hasher.HashingPassword(tbPassword.Text);


                string post = cbPost.Text;
                var info = Helper.GetContext().Post.Where(u => u.Name == post).FirstOrDefault();

                var emp = new Models.Employeey
                {
                    IdPost = info.IdPost,
                    Name = tbName.Text,
                    Surname = tbSurname.Text,
                    Patronymic = tbPatronymic.Text,
                    PhoneNumber = tbPhone.Text,
                    Email = tbEmail.Text
                };
                //Валидация данных
                var context = new ValidationContext(emp);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                if (!Validator.TryValidateObject(emp, context, results, true))
                {
                    string errores = "";
                    foreach (var error in results)
                    {
                        errores += error.ErrorMessage + "\n ";
                    }
                    MessageBox.Show($"Не удалось добавить пользователя по причине:\n {errores}");
                }
                CompEntities.Employeey.Add(emp);
                CompEntities.SaveChanges();

                var user = new Models.Users
                {
                    IdEmp = emp.IdEmp,
                    Login = tbLogin.Text,
                    Password = hashPass
                };
                //Валидация данных
                if (!Validator.TryValidateObject(user, context, results, true))
                {
                    string errores = "";
                    foreach (var error in results)
                    {
                        errores += error.ErrorMessage + "\n";
                    }
                    MessageBox.Show($"Не удалось добавить пользователя по причине:\n {errores}");
                }
                else
                    MessageBox.Show($"Сотрудник успешно добавлен");
                CompEntities.Users.Add(user);
                CompEntities.SaveChanges();
                

               
               
            }
            catch (Exception ex) { }
        }
        //Очистка текстовых полей
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cbPost.SelectedIndex = 0;
            tbName.Text = "";
            tbSurname.Text = "";
            tbPatronymic.Text = "";
            tbPhone.Text = "";
            tbEmail.Text = "";
            tbLogin.Text = "";
            tbPassword.Text = "";
   
        }
        //Проверка на вводимымы значения, должны быть только цифры
        private void tbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
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
