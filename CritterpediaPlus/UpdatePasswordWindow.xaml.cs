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
using System.Windows.Shapes;
using DataObjects;
using DataAccessInterfaces;
using LogicLayer;
using DataAccessFakes;

namespace CritterpediaPlus
{
    /// <summary>
    /// Interaction logic for UpdatePasswordWindow.xaml
    /// </summary>
    public partial class UpdatePasswordWindow : Window
    {
        UserManager _userManager = null;
        User _user = null;

        public UpdatePasswordWindow(UserManager userManager, User user, String instructions, string loginName, bool newUser = false)
        {
            _userManager = userManager;
            _user = user;

            InitializeComponent();
            StaMessage.Content = instructions;
            txtLoginName.Text = loginName;
            pwdOldPassword.Focus();
            if (newUser)
            {
                newUserUpdate();
            }
        }

        private void newUserUpdate()
        {
            txtLoginName.IsEnabled = false;
            pwdOldPassword.Password = "newuser";
            pwdOldPassword.IsEnabled = false;
            pwdNewPassword.Focus();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _user = _userManager.LoginUser(txtLoginName.Text, pwdOldPassword.Password);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            if (_user != null)
            {
                if (pwdNewPassword.Password != pwdConfirmPassword.Password)
                {
                    MessageBox.Show("New password and Retype password must match.");
                    pwdNewPassword.Password = "";
                    pwdConfirmPassword.Password = "";
                    pwdNewPassword.Focus();
                    return;
                }
                try
                {
                    string oldPassword = pwdOldPassword.Password;
                    string newPassword = pwdNewPassword.Password;

                    if (_userManager.ResetPassword(_user.LoginName, oldPassword, newPassword))
                    {
                        MessageBox.Show("Password successfully updated.");
                        this.DialogResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed.\n\n" + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
