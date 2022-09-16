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
using LogicLayer;
using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;

namespace CritterpediaPlus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserManager _userManager = null;
        User _user = null;
        CritterManager _critterManager = null;
        List<CritterVM> critters = new List<CritterVM>();
        public MainWindow()
        {
            // uses default user accessor
            _userManager = new UserManager();
            _critterManager = new CritterManager();

            // uses the fake user accessor
            //_userManager = new UserManager(new DataAccessFakes.UserAccessorFake());
            //_critterManager = new CritterManager(new DataAccessFakes.CritterAccessorFake());
            InitializeComponent();
        }
        private void hideAllUserTabs()
        {
            foreach (var tab in tabsetMain.Items)
            {
                ((TabItem)tab).Visibility = Visibility.Collapsed;
            }

            ((TabItem)tabLogIn).Visibility = Visibility.Visible;
            ((TabItem)tabHome).Visibility = Visibility.Visible;
            btnAddCritter.Visibility = Visibility.Hidden;
        }

        private void updateUIForUser()
        {
            tabHome.Focus();

            string rolesList = "";
            for (int i = 0; i < _user.Roles.Count; i++)
            {
                rolesList += " " + _user.Roles[i];
                if (i == _user.Roles.Count - 2)
                {
                    if (_user.Roles.Count > 2)
                    {
                        rolesList += ", and";
                    }
                    else
                    {
                        rolesList += " and";
                    }
                }
                else if (i < _user.Roles.Count - 2)
                {
                    rolesList += ", ";
                }
            }

            txtLoginName.Text = "";
            pwdPassword.Password = "";

            lblWelcome.Content = "Welcome " + _user.CharacterName + "!";

            if(_user.Roles.Count == 1)
            {
                lblSubWelcome.Content = "Your role is: " + rolesList;
            }
            else
            {
                lblSubWelcome.Content = "Your roles are: " + rolesList;
            }

            showTabsForUser();
            tabLogIn.Header = "Log Out";
            staMessage.Content = "";
        }

        private void showTabsForUser()
        {
            tabMyCritterpedia.Visibility = Visibility.Visible;
            tabAllCritters.Visibility = Visibility.Visible;
            if(_user.Roles.Contains("Island Owner"))
            {
                btnAddCritter.Visibility = Visibility.Visible;
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginName = this.txtLoginName.Text;
            var password = this.pwdPassword.Password;
            try
            {
                _user = _userManager.LoginUser(loginName, password);
                if (_user != null && password == "newuser")
                {
                    String instructions = "On first login, all new users must choose a password to continue.";
                    // force change password
                    var updateWindow = new UpdatePasswordWindow(
                        _userManager, _user, instructions, loginName, true);

                    bool? result = updateWindow.ShowDialog();
                    if (result == true)
                    {
                        updateUIForUser();
                    }
                    else
                    {
                        _user = null;
                        updateUIForLogOut();
                        MessageBox.Show("You did not update your password. You will be logged out.");
                    }

                }
                else if (_user != null)
                {
                    updateUIForUser();
                    
                }
                else
                {
                    MessageBox.Show("Bad Username or Password.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tabAllCritters_GotFocus(object sender, RoutedEventArgs e)
        {
            staMessage.Content = "Double Click a Critter to see more information";
            try{
                if (_user.Roles.Contains("Island Owner"))
                {
                    //add Active Column if doesn't exist
                    bool hasActive = false;
                    foreach (DataGridColumn column in datAllCritters.Columns)
                    {
                        if (column.Header.Equals("Active"))
                        {
                            hasActive = true;
                            break;
                        }
                    }
                    if (!hasActive)
                    {
                        DataGridCheckBoxColumn activeColumn = new DataGridCheckBoxColumn();
                        activeColumn.Header = "Active";
                        activeColumn.Binding = new Binding("Active");
                        datAllCritters.Columns.Add(activeColumn);
                    }

                    //show everything
                    critters = _critterManager.RetrieveAll();
                    _critterManager.setCritterCaughtByCurrentUser(critters, _user.VillagerID);
                    datAllCritters.ItemsSource = critters;
                }
                else
                {
                    //remove Active Column if exists
                    foreach(DataGridColumn column in datAllCritters.Columns)
                    {
                        if (column.Header.Equals("Active"))
                        {
                            datAllCritters.Columns.Remove(column);
                        }
                    }

                    // shows only active
                    critters = _critterManager.RetrieveActive();
                    _critterManager.setCritterCaughtByCurrentUser(critters, _user.VillagerID);
                    datAllCritters.ItemsSource = null;
                    datAllCritters.ItemsSource = critters;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            String instructions = "";

            var updateWindow = new UpdatePasswordWindow(
                _userManager, _user, instructions, this.txtLoginName.Text, false);

            bool? result = updateWindow.ShowDialog();
        }

        private void frmMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            hideAllUserTabs();
        }

        private void updateUIForLogOut()
        {
            _user = null;
            critters = null;
            hideAllUserTabs();
            lblWelcome.Content = "Welcome to Critterpedia Plus!";
            lblSubWelcome.Content = "Please log in to continue.";
            staMessage.Content = "Welcome! Please login to continue.";
            tabLogIn.Header = "Log In";
            btnAddCritter.Visibility = Visibility.Hidden;
        }

        private void tabLogIn_GotFocus(object sender, RoutedEventArgs e)
        {
            if(_user != null)
            {
                _user = null;
                critters = new List<CritterVM>();
                updateUIForLogOut();
            }
        }

        private void tabHome_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_user != null)
            {
                staMessage.Content = "";
            }
            else
            {
                staMessage.Content = "Welcome! Please login to continue.";
            }
        }

        private void tabMyCritterpedia_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                critters = _critterManager.RetrieveCaughtByUser(_user.VillagerID);
                _critterManager.setCritterCaughtByCurrentUser(critters, _user.VillagerID);
                datMyCritters.ItemsSource = critters;
            }
            catch (Exception ex)
            {

                MessageBox.Show("No critters to show\n\n"+ex.Message);
            }
        }

        private void datAllCritters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {            
            if (datAllCritters.SelectedItems.Count > 0)
            {
                var critter = (CritterVM)datAllCritters.SelectedItem;
                var detailWindow = new AddEditDetail(critter, _user);
                var result = (bool)detailWindow.ShowDialog();
                if (result)
                {
                    //updateBicycleInventory();
                }
            }
        }

        private void datMyCritters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (datMyCritters.SelectedItems.Count > 0)
            {
                var critter = (CritterVM)datMyCritters.SelectedItem;
                var detailWindow = new AddEditDetail(critter, _user);
                var result = (bool)detailWindow.ShowDialog();
                if (result)
                {
                    //updateBicycleInventory();
                }
            }
        }

        private void btnAddCritter_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new AddEditDetail();
            var result = (bool)detailWindow.ShowDialog();
            if (result)
            {
                //updateBicycleInventory();
            }
        }
    }
}
