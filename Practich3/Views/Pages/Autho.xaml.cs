using HashPassword;
using Practich3.Models;
using Practich3.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
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
        //Количество ошабок входа
        private int countUnsuccessfull = 0;
        //Создание переменныой которая будет хранить код для сообщения на Email
        private int Cod = 0;
        //Авторизация, каптча, двухфакторная аутентификация
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            hashPassword hasher = new hashPassword();
            Users users = new Users();
            Employeey employeey = new Employeey();
            DateTime DateNow = DateTime.Now;
            string login = txtbLogin.Text.Trim();
            string password = pswbPassword.Password.Trim();
            //Проверка времени рабочего дня
            if (DateNow.Hour >= 10 && DateNow.Hour < 19)
            {
                if (login.Length > 0 && password.Length > 0)
                {
                    if (countUnsuccessfull < 1)
                    {
                        string hashingpasword = hasher.HashingPassword(password);
                        var user = Helper.GetContext().Users.Where(u => u.Login == login && u.Password == hashingpasword).FirstOrDefault();
                        //Проверка пользователя базы данных по логину и паролю
                        if (user != null)
                        {
                            var employee = Helper.GetContext().Employeey.FirstOrDefault(emp => emp.IdEmp == user.IdEmp);
                            //Генерация кода двухфакторной аутентификации
                             if(Cod==0)
                            {
                                Random random = new Random();
                                Cod = random.Next(10000, 99999);
                                SendEmail(Cod, employee.Email);
                                waitCod();
                                tbCod.Visibility = Visibility.Visible;
                                txtBlockCod.Visibility = Visibility.Visible;
                                txtBAnotherCod.Visibility = Visibility.Visible;
                            }
                              else
                            {
                                MessageBox.Show("Код двухфакторной аутентификации неверный, попробуйте ещё раз");
                            }
                             //Првоерка корректности введённых данных и переход на страницк пользователя
                            if (employee != null && employee.IdPost != 0 && tbCod.Text==Convert.ToString(Cod))
                            {
                                tbCod.Visibility = Visibility.Hidden;
                                txtBlockCod.Visibility = Visibility.Hidden;
                                txtBAnotherCod.Visibility = Visibility.Hidden;
                                switch (employee.IdPost)
                                {
                                    case 1:
                                        NavigationService.Navigate(new Views.Pages.TechnicalSpec(employee.IdEmp));
                                        break;

                                    case 2:
                                        NavigationService.Navigate(new Views.Pages.Manager(employee.IdEmp));
                                        break;
                                    case 3:
                                        NavigationService.Navigate(new Views.Pages.Admin(employee.IdEmp));
                                        break;

                                    case 4:
                                        NavigationService.Navigate(new Views.Pages.WarehouseWorker(employee.IdEmp));
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
                    //генерация каптчи
                    else 
                    {
                        string hashingpasword = hasher.HashingPassword(password);
                        var user = Helper.GetContext().Users.Where(u => u.Login == login && u.Password == hashingpasword).FirstOrDefault();
                        string captcha = txtboxCaptcha.Text.Trim();
                        if (user != null && captcha == txtBlockCaptcha.Text)
                        {
                            countUnsuccessfull = 0;
                            txtboxCaptcha.Visibility = Visibility.Hidden;
                            txtBlockCaptcha.Visibility = Visibility.Hidden;
                            txtboxCaptcha.Text = "";
                            txtBlockCaptcha.Text = "";
                           
                        }
                        //Проверка на количество ошибок ввода, блокировка ввода если ошибок 2 или больше
                        else
                        {
                            if (countUnsuccessfull < 2)
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
                                //Метод для блокировки кнопок ввода на 1 минуту
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
            else
            {
                MessageBox.Show("Вход в приложение возможен только с 10:00 до 19:00!", "Внимание", MessageBoxButton.OK);
            }         
        }
        //Метод генерации каптчи
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
        //Метод для блокировки кнопок ввода на 1 минуту
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
                remainingTime--;
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
        //Метод для ожидания повторной отправки кода на почту 
        private async void waitCod()
        {
            int remainingTime = 60;
            txtBAnotherCod.IsEnabled = false;
            while (remainingTime > 0)
            {
                txtBAnotherCod.Text = $"Отправить код повторно можно через {remainingTime} сек";
                await Task.Delay(1000);
                remainingTime--;
            }
            txtBAnotherCod.IsEnabled = true;
            txtBAnotherCod.Text = "Отправить код повторно";
        }

        //Метод отправляющий код двухфакторной атуентификации на почту пользователя 
        private async void SendEmail(int Cod, string email)
        {
            await Task.Run(() =>
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "yulya_feduseva@mail.ru";
            string smtpPassword = "b1cGrafcE5dMcHUqN5Ra";
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(smtpUsername);
            mailMessage.To.Add(email);
            mailMessage.Subject = "Код двухфакторной аутентификации";
            mailMessage.Body = $"Код двухфакторной вутентификации {Cod}";
                    try
                    {
                        smtpClient.Send(mailMessage);
                        MessageBox.Show("Сообщение отправлено на почту");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошмбка отправки сообщения: {ex.Message}");
                    }
        });
        }
        //Переход на страницу с восстановлением пароля
        private void txtBlockForgotPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Views.Pages.ForgotPassword());
        }
        //Когда мышка находится вне текста, он видоизменяется, делая видимость интерактивности
        private void txtBlockForgotPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            txtBlockForgotPassword.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x32, 0x42, 0xC8));
            txtBlockForgotPassword.FontSize = 10;
        }
        //При наведении на текст он видоизменяется, делая видимость интерактивности
        private void txtBlockForgotPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            txtBlockForgotPassword.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF001BFF"));
            txtBlockForgotPassword.FontSize = 11;
        }
        //Метод повторной генерации кода двухфакторной аутентификации
        private void txtBAnotherCod_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Employeey employeey = new Employeey();
            Users users = new Users();
            hashPassword hasher = new hashPassword();
            string login = txtbLogin.Text.Trim();
            string password = pswbPassword.Password.Trim();
            string hashingpasword = hasher.HashingPassword(password);
            var user = Helper.GetContext().Users.Where(u => u.Login == login && u.Password == hashingpasword).FirstOrDefault();
            var employee = Helper.GetContext().Employeey.FirstOrDefault(emp => emp.IdEmp == user.IdEmp);

            Random random = new Random();
            Cod = random.Next(10000, 99999);
            SendEmail(Cod, employee.Email);
            waitCod();
        }
    }
}
