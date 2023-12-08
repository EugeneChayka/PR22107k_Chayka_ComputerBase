using HashPassword;
using Practich3.Models;
using Practich3.Views.Windows;
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
using System.Threading.Tasks;

namespace Practich3.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
       
        public Autho()
        {
            InitializeComponent();
            txtboxCaptcha.Visibility = Visibility.Hidden;
            txtBlockCaptcha.Visibility = Visibility.Hidden;
          

        }
        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client());
        }

        private int countUnsuccessfull = 0;
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            hashPassword hasher = new hashPassword();
            Users users = new Users();
            Employeey employeey = new Employeey();

            string login=txtbLogin.Text.Trim();
            string password = pswbPassword.Password.Trim();
            if (login.Length > 0 && password.Length > 0)
            {
                if (countUnsuccessfull < 1) {
                    
                        string hashingpasword = hasher.HashingPassword(password);
                        var user = Helper.GetContext().Users.Where(u => u.Login == login && u.Password == hashingpasword).FirstOrDefault();
                   
                    if (user != null)
                        {
                        var employee = Helper.GetContext().Employeey.FirstOrDefault(emp => emp.IdEmp == user.IdEmp);
                        if (employee != null && employee.IdPost != 0)
                        {
                            switch (employee.IdPost)
                            {
                                case 1:
                                    NavigationService.Navigate(new Views.Pages.TechnicalSpec());
                                    break;

                                case 2:
                                    NavigationService.Navigate(new Views.Pages.Manager());
                                    break;
                                case 3:
                                    NavigationService.Navigate(new Views.Pages.Admin());
                                    break;

                                case 4:
                                    NavigationService.Navigate(new Views.Pages.WarehouseWorker());
                                    break;


                            }
                        }
                       
                    }
                        else
                        {
                            MessageBox.Show("Пользователя с таким логином или паролем не существует!", "Внимание", MessageBoxButton.OK);
                            countUnsuccessfull++;
                           
                            GenerateCaptcha();
                        }
                    
                }
                else
                {
                    string hashingpasword = hasher.HashingPassword(password);
                    var user = Helper.GetContext().Users.Where(u => u.Login == login && u.Password == hashingpasword).FirstOrDefault();
                    string captcha= txtboxCaptcha.Text.Trim();
                    if(user!= null&&captcha==txtBlockCaptcha.Text)
                    {
                        countUnsuccessfull = 0;
                        txtboxCaptcha.Visibility = Visibility.Hidden;
                        txtBlockCaptcha.Visibility = Visibility.Hidden;
                        txtboxCaptcha.Text = "";
                        txtBlockCaptcha.Text = "";
                       
                    }
                    else
                    {   if(countUnsuccessfull<2)
                        {
                            MessageBox.Show("Капча введена неправильно, попробуйте ещё раз!", "Внимание", MessageBoxButton.OK);
                            countUnsuccessfull++;
                            GenerateCaptcha();
                        }
                        else
                        {
                            MessageBox.Show("Капча введена неправильно больше двух раз, повторите попытку чуть позже!", "Внимание", MessageBoxButton.OK);
                            countUnsuccessfull++;
                            GenerateCaptcha();
                            wait();
                        }    
                    }
                    
                }
            }
            else 
            {
                MessageBox.Show("Не все поля были заполнены! Заполните логин и пароль, и повторите попытку авторизации!", "Внимание", MessageBoxButton.OK);
            }
        }
        private void GenerateCaptcha()
        {
            txtboxCaptcha.Visibility = Visibility.Visible;
            txtBlockCaptcha.Visibility = Visibility.Visible;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string captcha = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            txtBlockCaptcha.Text = captcha;
            txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
        }
        private async void wait()
        {
            
            int remainingTime = 10;
            btnEnterGuests.IsEnabled = false;
            btnEnter.IsEnabled = false;
            txtbLogin.IsEnabled = false;
            pswbPassword.IsEnabled = false;
            txtboxCaptcha.IsEnabled = false;
            while (remainingTime > 0) 
            {
                lblTime.Content = $"До конца блокировки {remainingTime} сек"; 
                await Task.Delay(1000); 
                remainingTime --; 
            }
            lblTime.Content = "Блокировка завершена!";
            btnEnterGuests.IsEnabled = true;
            btnEnter.IsEnabled = true;
            txtbLogin.IsEnabled = true;
            pswbPassword.IsEnabled = true;
            txtboxCaptcha.IsEnabled = true;
            await Task.Delay(2000);
            lblTime.Content = "";
        }
    }
}
