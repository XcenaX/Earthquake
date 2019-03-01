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


namespace EarthquakeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void CloseLoginPanel(object sender, RoutedEventArgs e)
        {
            LoginForm.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Visible;
        }

        private void OpenLoginPanel(object sender, RoutedEventArgs e)
        {            
            RegistrateForm.Visibility = Visibility.Collapsed;            
            LoginForm.Visibility = Visibility.Visible;
            if (RegistrateForm.Visibility == Visibility.Visible) RegistrateForm.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Collapsed;
        }

        private void CloseRegistratePanel(object sender, RoutedEventArgs e)
        {
            RegistrateForm.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Visible;
        }

        private void OpenRegistratePanel(object sender, RoutedEventArgs e)
        {            
            LoginForm.Visibility = Visibility.Collapsed;
            RegistrateForm.Visibility = Visibility.Visible;
            if (LoginForm.Visibility == Visibility.Visible) LoginForm.Visibility = Visibility.Collapsed;
            Main.Visibility = Visibility.Collapsed;
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            using (var context = new UsersContext())
            {
                var users = context.Clients.Where(client => client.Login == UserLogin.Text.ToString() && client.Password == UserPassword.Password.ToString()).ToList();
                if (!users.Any())
                {
                    MessageBox.Show("Направильно введен логин или пароль");
                }
                else
                {                    
                    LoginIfLogged.Text = users[0].Name;

                    CloseLoginPanel(sender, e);

                    UserLogin.Text = "";
                    UserPassword.Password = "";
                    EarthquakePanel.Visibility = Visibility.Visible;
                    Main.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void LogOutUser(object sender, RoutedEventArgs e)
        {

            Main.Visibility = Visibility.Visible;
            LoginForm.Visibility = Visibility.Visible;
            RegistrateForm.Visibility = Visibility.Visible;

            LoginIfLogged.Text = "";
            UserLogin.Text = "";
            UserPassword.Password = "";

        }
        private void RegistrateUser(object sender, RoutedEventArgs e)
        {
            using (var context = new UsersContext())
            {
                var users = context.Clients.Where(client => client.Login == ClientLoginRegistrate.Text.ToString());
                var test = context.Clients.ToList();
                if (users.Count() > 0)
                {
                    MessageBox.Show("Пользователь с такими логином уже зарегестрирован!");
                    return;
                }
                else if (ClientFullNameRegistrate.Text.ToString() == "")
                {
                    MessageBox.Show("Не заполнено поле ФИО");
                    return;
                }
                else if (ClientLoginRegistrate.Text.ToString() == "")
                {
                    MessageBox.Show("Не заполнено поле Логин");
                    return;
                }
                else if ((ClientPasswordRegistrate.Password.ToString() != ClientPasswordConfirm.Password.ToString()) || (ClientPasswordRegistrate.Password.ToString() == ""))
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }
                else
                {
                    CloseRegistratePanel(sender, e);
                    Main.Visibility = Visibility.Visible;                    
                    MessageBox.Show("Поздравляем! Вы успешно зарегистрировались!");
                    context.Clients.Add(new Client() {
                        Login = ClientLoginRegistrate.Text,
                        Name = ClientFullNameRegistrate.Text,
                        Password = ClientPasswordRegistrate.Password
                    });
                    ClientFullNameRegistrate.Text = "";
                    ClientLoginRegistrate.Text = "";
                    ClientPasswordRegistrate.Clear();
                    ClientPasswordConfirm.Clear();
                    context.SaveChanges();
                }
            }
        }
    }
}
