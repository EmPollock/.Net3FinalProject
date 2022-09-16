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
using DataAccessFakes;
using LogicLayer;

namespace CritterpediaPlus
{
    /// <summary>
    /// Interaction logic for AddEditDetail.xaml
    /// </summary>
    public partial class AddEditDetail : Window
    {
        CritterVM _critterVM = null;
        CritterManager _critterManager = null;
        FishManager _fishManager = null;
        BugManager _bugManager = null;
        SeaCreatureManager _seaCreatureManager = null;
        User _user = null;
        // list of locations, spots, shadow sizes, etc
        List<string> _locations = null;
        List<string> _spots = null;
        List<string> _shadowSizes = null;
        List<string> _movements = null;
        List<string> _critterType = null;
        FishVM _fish = null;
        BugVM _bug = null;
        SeaCreature _seaCreature = null;

        bool _add = false;

        public AddEditDetail()
        {
            _add = true;            
            InitializeComponent();
            hideTypeSpecific();
        }

        public AddEditDetail(CritterVM critter, User user, bool readOnly = true) // this constructor is for edit bicycle and view bicycle details
        {
            _critterVM = critter;
            _user = user;
            InitializeComponent();
            if (!_user.Roles.Contains("Island Owner"))
            {
                btnEditSave.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
            }
            hideTypeSpecific();
            showTypeSpecific(_critterVM.CritterTypeId);
            //setDetailMode();
        }

        public void hideTypeSpecific()
        {
            lblLocation.Visibility = Visibility.Hidden;
            cboLocation.Visibility = Visibility.Hidden;
            lblMovement.Visibility = Visibility.Hidden;
            cboMovement.Visibility = Visibility.Hidden;
            lblShadowSize.Visibility = Visibility.Hidden;
            cboShadowSize.Visibility = Visibility.Hidden;
            lblSpot.Visibility = Visibility.Hidden;
            cboSpot.Visibility = Visibility.Hidden;
        }

        public void showTypeSpecific(string type)
        {
            if (type == "fish" || type == "Fish")
            {
                lblLocation.Visibility = Visibility.Visible;
                cboLocation.Visibility = Visibility.Visible;
                lblShadowSize.Visibility = Visibility.Visible;
                cboShadowSize.Visibility = Visibility.Visible;
            }
            else if (type == "bug" || type == "Bug")
            {
                lblSpot.Visibility = Visibility.Visible;
                cboSpot.Visibility = Visibility.Visible;
            }
            else if (type == "sea creature" || type == "Sea Creature")
            {
                lblMovement.Visibility = Visibility.Visible;
                cboMovement.Visibility = Visibility.Visible;
                lblShadowSize.Visibility = Visibility.Visible;
                cboShadowSize.Visibility = Visibility.Visible;
            }
        }
        private void setDetailMode()
        {
            populateCritterControls();
            if (_critterVM.CritterTypeId == "fish" || _critterVM.CritterTypeId == "Fish")
            {
                populateFishControls();
                cboLocation.IsEnabled = false;
                cboLocation.IsReadOnly = true;
                cboShadowSize.IsEnabled = false;
                cboShadowSize.IsReadOnly = true;
            }
            else if (_critterVM.CritterTypeId == "bug" || _critterVM.CritterTypeId == "Bug")
            {
                populateBugControls();
                cboSpot.IsReadOnly = true;
                cboSpot.IsEnabled = false;
            }
            else if (_critterVM.CritterTypeId == "sea creature" || _critterVM.CritterTypeId == "Sea Creature")
            {
                populateSeaCreatureControls();
                cboMovement.IsEnabled = false;
                cboMovement.IsReadOnly = true;
                cboShadowSize.IsEnabled = false;
                cboShadowSize.IsReadOnly = true;
            }
            txtCritterName.IsReadOnly = true;
            cboCritterType.IsReadOnly = true;
            cboCritterType.IsEnabled = false;
            txtPrice.IsReadOnly = true;
            if (chkInMuseum.IsChecked == true && !_user.Roles.Contains("Museum Admin"))
            {
                chkInMuseum.IsEnabled = false;
            }
            else
            {
                chkInMuseum.IsEnabled = true;
            }

            chkRainNeeded.IsEnabled = false;
            txtCatchDescription.IsReadOnly = true;
            chkCaughtByCurrentUser.IsEnabled = true;

            btnCancel.Content = "Close";
            if (_user.Roles.Contains("Island Owner"))
            {
                btnEditSave.Content = "Edit";
            }
            else
            {
                btnEditSave.Content = "Save";
            }
        }

        private void setEditMode()
        {
            populateCritterControls();
            if (_critterVM.CritterTypeId == "fish" || _critterVM.CritterTypeId == "Fish")
            {
                populateFishControls();
                cboLocation.IsEnabled = true;
                cboLocation.IsReadOnly = false;
                cboShadowSize.IsEnabled = true;
                cboShadowSize.IsReadOnly = false;
            }
            else if (_critterVM.CritterTypeId == "bug" || _critterVM.CritterTypeId == "Bug")
            {
                populateBugControls();
                cboSpot.IsReadOnly = false;
                cboSpot.IsEnabled = true;
            }
            else if (_critterVM.CritterTypeId == "sea creature" || _critterVM.CritterTypeId == "Sea Creature")
            {
                populateSeaCreatureControls();
                cboMovement.IsEnabled = true;
                cboMovement.IsReadOnly = false;
                cboShadowSize.IsEnabled = true;
                cboShadowSize.IsReadOnly = false;
            }
            txtCritterName.IsReadOnly = false;
            cboCritterType.IsEnabled = false;
            cboCritterType.IsReadOnly = false;
            txtPrice.IsReadOnly = false;
            if (chkInMuseum.IsChecked == true && !_user.Roles.Contains("Museum Admin"))
            {
                chkInMuseum.IsEnabled = false;
            }
            else
            {
                chkInMuseum.IsEnabled = true;
            }
            chkRainNeeded.IsEnabled = true;
            txtCatchDescription.IsReadOnly = true;
            chkCaughtByCurrentUser.IsEnabled = true;
            chkJan.IsEnabled = false;
            chkFeb.IsEnabled = false;
            chkMar.IsEnabled = false;
            chkApr.IsEnabled = false;
            chkMay.IsEnabled = false;
            chkJune.IsEnabled = false;
            chkJuly.IsEnabled = false;
            chkAug.IsEnabled = false;
            chkSep.IsEnabled = false;
            chkOct.IsEnabled = false;
            chkNov.IsEnabled = false;
            chkDec.IsEnabled = false;

            chk1AM.IsEnabled = false;
            chk2AM.IsEnabled = false;
            chk3AM.IsEnabled = false;
            chk4AM.IsEnabled = false;
            chk5AM.IsEnabled = false;
            chk6AM.IsEnabled = false;
            chk7AM.IsEnabled = false;
            chk8AM.IsEnabled = false;
            chk9AM.IsEnabled = false;
            chk10AM.IsEnabled = false;
            chk11AM.IsEnabled = false;
            chk12PM.IsEnabled = false;
            chk1PM.IsEnabled = false;
            chk2PM.IsEnabled = false;
            chk3PM.IsEnabled = false;
            chk4PM.IsEnabled = false;
            chk5PM.IsEnabled = false;
            chk6PM.IsEnabled = false;
            chk7PM.IsEnabled = false;
            chk8PM.IsEnabled = false;
            chk9PM.IsEnabled = false;
            chk10PM.IsEnabled = false;
            chk11PM.IsEnabled = false;
            chk12AM.IsEnabled = false;

            btnCancel.Content = "Cancel";
            btnEditSave.Content = "Save";
            _add = false;
        }

        private void setAddMode()
        {
            txtCritterName.IsReadOnly = false; ;
            cboCritterType.IsEnabled = true;
            cboCritterType.IsReadOnly = false;
            txtPrice.IsReadOnly = false;
            chkInMuseum.IsEnabled = false;
            chkRainNeeded.IsEnabled = true;
            txtCatchDescription.IsReadOnly = true;
            chkCaughtByCurrentUser.IsEnabled = false;
            chkJan.IsEnabled = true;
            chkFeb.IsEnabled = true;
            chkMar.IsEnabled = true;
            chkApr.IsEnabled = true;
            chkMay.IsEnabled = true;
            chkJune.IsEnabled = true;
            chkJuly.IsEnabled = true;
            chkAug.IsEnabled = true;
            chkSep.IsEnabled = true;
            chkOct.IsEnabled = true;
            chkNov.IsEnabled = true;
            chkDec.IsEnabled = true;

            chk1AM.IsEnabled = true;
            chk2AM.IsEnabled = true;
            chk3AM.IsEnabled = true;
            chk4AM.IsEnabled = true;
            chk5AM.IsEnabled = true;
            chk6AM.IsEnabled = true;
            chk7AM.IsEnabled = true;
            chk8AM.IsEnabled = true;
            chk9AM.IsEnabled = true;
            chk10AM.IsEnabled = true;
            chk11AM.IsEnabled = true;
            chk12PM.IsEnabled = true;
            chk1PM.IsEnabled = true;
            chk2PM.IsEnabled = true;
            chk3PM.IsEnabled = true;
            chk4PM.IsEnabled = true;
            chk5PM.IsEnabled = true;
            chk6PM.IsEnabled = true;
            chk7PM.IsEnabled = true;
            chk8PM.IsEnabled = true;
            chk9PM.IsEnabled = true;
            chk10PM.IsEnabled = true;
            chk11PM.IsEnabled = true;
            chk12AM.IsEnabled = true;

            btnEditSave.Content = "Save";
            btnCancel.Content = "Close";
        }

        private void populateCritterControls()
        {
            txtCritterName.Text = _critterVM.CritterId;

            if(_critterVM.CritterTypeId == "fish" || _critterVM.CritterTypeId == "Fish")
            {
                cboCritterType.SelectedItem = "Fish";
            } else if (_critterVM.CritterTypeId == "bug" || _critterVM.CritterTypeId == "Bug")
            {
                cboCritterType.SelectedItem = "Bug";
            } else if (_critterVM.CritterTypeId == "sea creature" || _critterVM.CritterTypeId == "Sea Creature")
            {
                cboCritterType.SelectedItem = "Sea Creature";
            }

            txtPrice.Text = _critterVM.Price.ToString();
            chkInMuseum.IsChecked = _critterVM.InMuseum;
            chkRainNeeded.IsChecked = _critterVM.RainNeeded;
            txtCatchDescription.Text = _critterVM.CatchDescription;
            chkCaughtByCurrentUser.IsChecked = _critterVM.CaughtByCurrentUser;
            populateMonths();
            populateHours();
        }

        private void populateMonths()
        {
            if (_critterVM.CatchableMonths.Contains("jan") || _critterVM.CatchableMonths.Contains("Jan"))
            {
                chkJan.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("feb") || _critterVM.CatchableMonths.Contains("Feb"))
            {
                chkFeb.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("mar") || _critterVM.CatchableMonths.Contains("Mar"))
            {
                chkMar.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("apr") || _critterVM.CatchableMonths.Contains("Apr"))
            {
                chkApr.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("may") || _critterVM.CatchableMonths.Contains("May"))
            {
                chkMay.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("june") || _critterVM.CatchableMonths.Contains("June"))
            {
                chkJune.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("july") || _critterVM.CatchableMonths.Contains("July"))
            {
                chkJuly.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("aug") || _critterVM.CatchableMonths.Contains("Aug"))
            {
                chkAug.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("sep") || _critterVM.CatchableMonths.Contains("Sep"))
            {
                chkSep.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("oct") || _critterVM.CatchableMonths.Contains("Oct"))
            {
                chkOct.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("nov") || _critterVM.CatchableMonths.Contains("Nov"))
            {
                chkNov.IsChecked = true;
            }
            if (_critterVM.CatchableMonths.Contains("dec") || _critterVM.CatchableMonths.Contains("Dec"))
            {
                chkJan.IsChecked = true;
            }
        }
        private void populateHours()
        {
            if (_critterVM.CatchableHours.Contains(1))
            {
                chk1AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(2))
            {
                chk2AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(3))
            {
                chk3AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(4))
            {
                chk4AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(5))
            {
                chk5AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(6))
            {
                chk6AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(7))
            {
                chk7AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(8))
            {
                chk8AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(9))
            {
                chk9AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(10))
            {
                chk10AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(11))
            {
                chk11AM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(12))
            {
                chk12PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(13))
            {
                chk1PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(14))
            {
                chk2PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(15))
            {
                chk3PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(16))
            {
                chk4PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(17))
            {
                chk5PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(18))
            {
                chk6PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(19))
            {
                chk7PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(20))
            {
                chk8PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(21))
            {
                chk9PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(22))
            {
                chk10PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(23))
            {
                chk11PM.IsChecked = true;
            }
            if (_critterVM.CatchableHours.Contains(24))
            {
                chk12AM.IsChecked = true;
            }
        }

        private void populateFishControls()
        {
            cboLocation.SelectedItem = _fish.LocationId;
            cboShadowSize.SelectedItem = _fish.ShadowSizeId;
        }

        private void populateBugControls()
        {
            cboSpot.SelectedItem = _bug.SpotId;
        }

        private void populateSeaCreatureControls()
        {
            cboShadowSize.SelectedItem = _seaCreature.ShadowSizeId;
            cboMovement.SelectedItem = _seaCreature.movementId;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (btnCancel.Content.ToString() == "Cancel")
            {
                var results = MessageBox.Show("Are you sure?", "Discard Changes", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (results == MessageBoxResult.Yes)
                {
                    setDetailMode();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _critterManager = new CritterManager();
            _fishManager = new FishManager();
            _bugManager = new BugManager();
            _seaCreatureManager = new SeaCreatureManager();

            try
            {
                // set lists for combo boxes
                this.cboCritterType.ItemsSource = new List<string>() { "Fish", "Bug", "Sea Creature" };

                _locations = _fishManager.RetrieveAllLocations();
                this.cboLocation.ItemsSource = _locations;

               _shadowSizes = _fishManager.RetrieveAllShadowSizes();
                this.cboShadowSize.ItemsSource = _shadowSizes;

                _spots = _bugManager.RetrieveAllBugFindingSpots();
                this.cboSpot.ItemsSource = _spots;

                _movements = _seaCreatureManager.RetrieveAllMovements();
                this.cboMovement.ItemsSource = _movements;

                if (!(_critterVM == null)){
                    if (_critterVM.CritterTypeId == "Fish" || _critterVM.CritterTypeId == "fish")
                    {
                        _fish = _fishManager.RetrieveFishByCritterID(_critterVM.CritterId);
                    } else if (_critterVM.CritterTypeId == "Bug" || _critterVM.CritterTypeId == "bug")
                    {
                        _bug = _bugManager.RetrieveBugByCritterID(_critterVM.CritterId);
                    }
                    else
                    {
                        _seaCreature = _seaCreatureManager.RetrieveSeaCreatureByCritterID(_critterVM.CritterId);
                    }
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (_add)
            {
                setAddMode();
            }
            else
            {
                setDetailMode();
            }
        }

        private void btnEditSave_Click(object sender, RoutedEventArgs e)
        {
            if (btnEditSave.Content.ToString() == "Edit")
            {
                setEditMode();
            }
            else // save record
            {
                // save the record if add, or update if edit mode
                if (_add) // insert a new record
                {
                    if (txtCritterName.Text.ToString() == "")
                     {
                         MessageBox.Show("You must enter a Critter Name.");
                         txtCritterName.Focus();
                         return;
                     }
                    if (cboCritterType.SelectedItem == null)
                    {
                        MessageBox.Show("You must choose a Critter Type.");
                        cboCritterType.Focus();
                        return;
                    }

                    int price;
                    try
                    {
                        price = int.Parse(txtPrice.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("You must enter a valid price.");
                        txtPrice.SelectAll();
                        txtPrice.Focus();
                        return;
                    }

                    if (cboCritterType.SelectedItem.ToString() == "Fish")
                    {
                        if(cboLocation.SelectedItem == null)
                        {
                            MessageBox.Show("You must choose a Location.");
                            cboCritterType.Focus();
                            return;
                        }
                        if (cboShadowSize.SelectedItem == null)
                        {
                            MessageBox.Show("You must choose a Shadow Size.");
                            cboCritterType.Focus();
                            return;
                        }
                    }
                    else if(cboCritterType.SelectedItem.ToString() == "Bug")
                    {
                        if (cboSpot.SelectedItem == null)
                        {
                            MessageBox.Show("You must choose a Spot.");
                            cboCritterType.Focus();
                            return;
                        }
                    }
                    else if(cboCritterType.SelectedItem.ToString() == "Sea Creature")
                    {
                        if (cboMovement.SelectedItem == null)
                        {
                            MessageBox.Show("You must choose a Movement Type.");
                            cboCritterType.Focus();
                            return;
                        }
                        if (cboShadowSize.SelectedItem == null)
                        {
                            MessageBox.Show("You must choose a Shadow Size.");
                            cboCritterType.Focus();
                            return;
                        }
                    }

                    // build a critter object
                    var critterVM = new CritterVM()
                    {
                        CritterId = txtCritterName.Text,
                        CritterTypeId = cboCritterType.SelectedItem.ToString(),
                        InMuseum = false,
                        RainNeeded = chkRainNeeded.IsChecked == true,
                        Price = price,
                        CatchableMonths = getMonthList(),
                        CatchableHours = getHourList()
                     };


                     try
                     {
         
                         if (_critterManager.AddCritter(critterVM))
                         {
                            if(_critterManager.AddCatchableMonth(critterVM) && _critterManager.AddCatchableHour(critterVM))
                            {
                                if(critterVM.CritterTypeId == "fish" || critterVM.CritterTypeId == "Fish")
                                {
                                    Fish fish = new Fish()
                                    {
                                        CritterId = txtCritterName.Text,
                                        LocationId = cboLocation.SelectedItem.ToString(),
                                        ShadowSizeId = cboShadowSize.SelectedItem.ToString()
                                    };
                                    if (_fishManager.AddFish(fish))
                                    {
                                        this.DialogResult = true;
                                    }
                                } else if (critterVM.CritterTypeId == "bug" || critterVM.CritterTypeId == "Bug")
                                {
                                    Bug bug = new Bug()
                                    {
                                        CritterId = txtCritterName.Text,
                                        SpotId = cboSpot.SelectedItem.ToString()
                                    };
                                    if (_bugManager.AddBug(bug))
                                    {
                                        this.DialogResult = true;
                                    }

                                }
                                else if (critterVM.CritterTypeId == "sea creature" || critterVM.CritterTypeId == "Sea Creature")
                                {
                                    SeaCreature seaCreature = new SeaCreature()
                                    {
                                        CritterId = txtCritterName.Text,
                                        movementId = cboMovement.SelectedItem.ToString(),
                                        ShadowSizeId = cboShadowSize.SelectedItem.ToString()
                                    };
                                    if (_seaCreatureManager.AddSeaCreature(seaCreature))
                                    {
                                        this.DialogResult = true;
                                    }

                                }
                            }
                             
                         }
                         
                     }
                     catch (Exception ex)
                     {

                         MessageBox.Show(ex.Message);
                     }                 
                    
                }
                else // update the current record
                {
                }
            }
        }

        private List<int> getHourList()
        {
            List<int> hours = new List<int>();
            if (chk1AM.IsChecked == true)
            {
                hours.Add(1);
            }
            if (chk2AM.IsChecked == true)
            {
                hours.Add(2);
            }
            if (chk3AM.IsChecked == true)
            {
                hours.Add(3);
            }
            if (chk4AM.IsChecked == true)
            {
                hours.Add(4);
            }
            if (chk5AM.IsChecked == true)
            {
                hours.Add(5);
            }
            if (chk6AM.IsChecked == true)
            {
                hours.Add(6);
            }
            if (chk7AM.IsChecked == true)
            {
                hours.Add(7);
            }
            if (chk8AM.IsChecked == true)
            {
                hours.Add(8);
            }
            if (chk9AM.IsChecked == true)
            {
                hours.Add(9);
            }
            if (chk10AM.IsChecked == true)
            {
                hours.Add(10);
            }
            if (chk11AM.IsChecked == true)
            {
                hours.Add(11);
            }
            if (chk12PM.IsChecked == true)
            {
                hours.Add(12);
            }
            if (chk1PM.IsChecked == true)
            {
                hours.Add(13);
            }
            if (chk2PM.IsChecked == true)
            {
                hours.Add(14);
            }
            if (chk3PM.IsChecked == true)
            {
                hours.Add(15);
            }
            if (chk4PM.IsChecked == true)
            {
                hours.Add(16);
            }
            if (chk5PM.IsChecked == true)
            {
                hours.Add(17);
            }
            if (chk6PM.IsChecked == true)
            {
                hours.Add(18);
            }
            if (chk7PM.IsChecked == true)
            {
                hours.Add(19);
            }
            if (chk8PM.IsChecked == true)
            {
                hours.Add(20);
            }
            if (chk9PM.IsChecked == true)
            {
                hours.Add(21);
            }
            if (chk10PM.IsChecked == true)
            {
                hours.Add(22);
            }
            if (chk11PM.IsChecked == true)
            {
                hours.Add(23);
            }
            if (chk12AM.IsChecked == true)
            {
                hours.Add(24);
            }

            return hours;
        }

        private List<string> getMonthList()
        {
            List<string> months = new List<string>();
            if (chkJan.IsChecked == true)
            {
                months.Add("Jan");
            }
            if (chkFeb.IsChecked == true)
            {
                months.Add("Feb");
            }
            if (chkMar.IsChecked == true)
            {
                months.Add("Mar");
            }
            if (chkApr.IsChecked == true)
            {
                months.Add("Apr");
            }
            if (chkMay.IsChecked == true)
            {
                months.Add("May");
            }
            if (chkJune.IsChecked == true)
            {
                months.Add("June");
            }
            if (chkJuly.IsChecked == true)
            {
                months.Add("July");
            }
            if (chkAug.IsChecked == true)
            {
                months.Add("Aug");
            }
            if (chkSep.IsChecked == true)
            {
                months.Add("Sep");
            }
            if (chkOct.IsChecked == true)
            {
                months.Add("Oct");
            }
            if (chkNov.IsChecked == true)
            {
                months.Add("Nov");
            }
            if (chkDec.IsChecked == true)
            {
                months.Add("Dec");
            }
            return months;
        }
        private void cboCritterType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hideTypeSpecific();
            showTypeSpecific(cboCritterType.SelectedItem.ToString());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_add)
            {
                this.Close();
            }
            else {
                var results = MessageBox.Show("Are you sure?", "Delete Critter", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (results == MessageBoxResult.Yes)
                {
                    try
                    {
                        bool result = false;
                        if (_critterManager.RemoveCaughtByByCritterID(_critterVM.CritterId))
                        {
                            if (_critterManager.RemoveHoursByCritterID(_critterVM.CritterId))
                            {
                                if (_critterManager.RemoveMonthsByCritterID(_critterVM.CritterId))
                                {
                                    if (_critterVM.CritterTypeId == "fish" || _critterVM.CritterTypeId == "Fish")
                                    {
                                        // delete Fish
                                        result = _fishManager.RemoveFish(_fish);
                                    }
                                    else if (_critterVM.CritterTypeId == "bug" || _critterVM.CritterTypeId == "Bug")
                                    {
                                        // delete Bug
                                        result = _bugManager.RemoveBug(_bug);
                                    }
                                    else
                                    {
                                        // delete Sea Creature
                                        result = _seaCreatureManager.RemoveSeaCreature(_seaCreature);
                                    }
                                    if (result)
                                    {
                                        // delete Critter
                                        _critterManager.RemoveCritter(_critterVM);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
        }
    }
}
