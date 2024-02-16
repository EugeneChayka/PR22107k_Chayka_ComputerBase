using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using Practich3.Models;
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
using HashPassword;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Xml.Linq;

namespace Practich3.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Page
    {
       
        public ForgotPassword()
        {
            InitializeComponent();
            Employeey employeey = new Employeey();
            Users user= new Users();
            lbSend.Content = "Введите E-mail";      
        }
        //Переменная для запоминания введённого Email и дальнейшего поиска пользовталея с помощью него 
        public string emailbox = "";
        //Метод отправляющий код для восстановления пароля на почту пользователя 
        private async void SendEmail(int Cod, string email)
        {
            
            await Task.Run(() =>
            {
                try {
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
                    mailMessage.Subject = "Код для смены пароля";
                    mailMessage.Body = $"Код для смены пароля {Cod}";
                    try
                    {
                        smtpClient.Send(mailMessage);
                        MessageBox.Show("Сообщение отправлено");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошмбка отправки сообщения: {ex.Message}");
                    }

                } catch (Exception ex) { MessageBox.Show($"Ошмбка отправки сообщения: {ex.Message}"); }
                
            });
            
           
        }
        //Создание переменныой которая будет хранить код для сообщения на Email
        public int Cod = 0;
        //Отпарвка кода на почту 
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var emp = Helper.GetContext().Employeey.Where(u => u.Email == tbEmail.Text).FirstOrDefault();
            if (emp != null)
            {
                emailbox = tbEmail.Text;
                emp = Helper.GetContext().Employeey.Find(emp.IdEmp);
                Random random = new Random();
                Cod = random.Next(10000, 99999);
                SendEmail(Cod, tbEmail.Text);
                lbSend.Content = "Введите код из сообщения";
                tbEmail.Text = "";
                btnSend.Visibility = Visibility.Hidden;
                btnCod.Visibility = Visibility.Visible;
                tblAnotherCod.Visibility = Visibility.Visible;
                waitCod();
            }
            else
            { MessageBox.Show("Такого пользователя нет"); }
        }
        //Проверка кода из сообщения
        private void btnCod_Click(object sender, RoutedEventArgs e)
        {
           if(tbEmail.Text==Convert.ToString(Cod))
            {
                lbSend.Content="Введите новый пароль";
                btnCod.Visibility=Visibility.Hidden;
                btnEditPass.Visibility = Visibility.Visible;
                tblAnotherCod.Visibility = Visibility.Hidden;
                tbEmail.Text = "";
                lblAnother.Visibility = Visibility.Visible;
                tbAnotherPass.Visibility = Visibility.Visible;
            }
            else {
                tbEmail.Text = "";
                MessageBox.Show("Код введён неправильно, попробуйте ещё раз"); 
            }
        }
        //Редактирование пароля пользователя
        private void btnEditPass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var emp = Helper.GetContext().Employeey.Where(u => u.Email == emailbox).FirstOrDefault();
                var user = Helper.GetContext().Users.Where(u => u.IdEmp == emp.IdEmp).FirstOrDefault();
                hashPassword hasher = new hashPassword();
                string hashPass = hasher.HashingPassword(tbEmail.Text);
               if(hashPass == user.Password)
                {
                    MessageBox.Show("Новый пароль не должен совпадать с текущим");
                }
               else {
                    if (tbEmail.Text != "")
                    {
                        if (tbAnotherPass.Text == tbEmail.Text)
                        {
                            emp.Users.Password = hashPass;
                            Helper.GetContext().Entry(emp).State = EntityState.Modified;
                            Helper.GetContext().SaveChanges();
                            MessageBox.Show($"Пароль успешно изменён!");
                            NavigationService.Navigate(new Views.Pages.Autho());
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поле пароль не должно быть пустым!");
                    }
                }
                
            }
            catch (Exception ex) { }
        }
        //Метод для ожидания повторной отправки кода на почту 
        private async void waitCod()
        {
            int remainingTime = 60;
            tblAnotherCod.IsEnabled = false;
            while (remainingTime > 0)
            {
                tblAnotherCod.Text = $"Отправить код повторно можно через {remainingTime} сек";
                await Task.Delay(1000);
                remainingTime--;
            }
            tblAnotherCod.IsEnabled = true;
            tblAnotherCod.Text = "Отправить код повторно";
        }
        //Метод повторной отправки кода на почту 
        private void tblAnotherCod_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Employeey employeey = new Employeey();  
            var employee = Helper.GetContext().Employeey.FirstOrDefault(emp => emp.Email == emailbox);
            Random random = new Random();
            Cod = random.Next(10000, 99999);
            SendEmail(Cod, employee.Email);
            waitCod();
        }
    }
}
