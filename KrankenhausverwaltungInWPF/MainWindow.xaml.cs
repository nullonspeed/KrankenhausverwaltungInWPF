using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KrankenhausverwaltungInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Abteilung> abteilungList;




        List<Abteilung> selectedAbteilungen;
        int ArztLoadIn =0;

        
        public MainWindow()
        {
            InitializeComponent();
            abteilungList = new List<Abteilung>();
            selectedAbteilungen = new List<Abteilung>();
            
            abteilungList.Add(new Abteilung() { ID = 1, Bezeichnung = "Augen"});
            abteilungList.Add(new Abteilung() { ID = 2, Bezeichnung = "Innere" });
            abteilungList.Add(new Abteilung() { ID = 3, Bezeichnung = "HNO" });
           

          

        }

        private void ExitMethod(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (MessageBox.Show("Wollen Sie die App schliessen ?","App beenden",MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void AerzteLaden(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            int aZahl=0;
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach(Abteilung abt in abteilungList){
                        abt.aerzte.Clear();
                    }
                        
                    
                    
                    foreach (string line in lines)
                    {
                        if (Arzt.TryParse(line, out Arzt p))
                        {
                            
                           abteilungList.Find(x=> x.ID == p.AbteilID).aerzte.Add(p);
                           aZahl++;
                            // TreeList.Items.Add(p);

                        }
                        else
                        {
                           
                        }
                    }
                    ArztLoadIn++;
                    StautsArztAnzahl.Content = "Ärzte: " + aZahl;

                    comboSelectionAbt.SelectedIndex = 0;
                    augenToogle.IsChecked = true;
                    hnoToogle.IsChecked = true;
                    innereToogle.IsChecked = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while reading the CSV file: {ex.Message}", "CSV File Reading Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void pushAbteilungenToTreeView()
        {
            TreeV.Items.Clear();
            foreach (Abteilung abt in selectedAbteilungen)
            {

                TreeViewItem tv = new TreeViewItem();
                tv.Header = abt.Bezeichnung;
                //TreeViewItem tv = new TreeViewItem();

                foreach (Arzt a in abt.aerzte)
                {

                    tv.Items.Add(a);
                }

                TreeV.Items.Add(tv);
            }
        }


        private void comboSelectionAbt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (abteilungList.Find(x => x.ID == 1) == null)
            {
            }
           else if (abteilungList.Find(x => x.ID == 2) == null)
            {
            }
           else if (abteilungList.Find(x => x.ID == 3) == null)
            {
            }
            else
            {

            

            if (selectedAbteilungen != null)
            {
                selectedAbteilungen.Clear();
            }
           
            switch (comboSelectionAbt.SelectedIndex)
            {
                case 0:
                    
                     foreach(Abteilung a in abteilungList)
                        {
                            selectedAbteilungen.Add(a);
                        }
                   
                    augenToogle.IsChecked = true;
                    innereToogle.IsChecked = true;
                    hnoToogle.IsChecked = true;
                    pushAbteilungenToTreeView(); 
                    break;
                case 1:
                   
                        selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 1));
                        augenToogle.IsChecked = true;
                        innereToogle.IsChecked = false;
                        hnoToogle.IsChecked = false;

                        pushAbteilungenToTreeView();
                    
                   

                    break;
                case 2:
                    
                    selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 2));
                    augenToogle.IsChecked = false;
                    innereToogle.IsChecked = true;
                    hnoToogle.IsChecked = false;
                    pushAbteilungenToTreeView();
                    break;
                case 3:
                  
                    selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 3));
                    augenToogle.IsChecked = false;
                    innereToogle.IsChecked = false;
                    hnoToogle.IsChecked = true;
                    pushAbteilungenToTreeView();
                    break;
                case 4:
                   
                    selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 1));
                    selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 2));
                    augenToogle.IsChecked = true;
                    innereToogle.IsChecked = true;
                    hnoToogle.IsChecked = false;
                    pushAbteilungenToTreeView();
                    break;
                case 5:
                   
                    selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 1));
                    selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 3));
                    augenToogle.IsChecked = true;
                    innereToogle.IsChecked = false;
                    hnoToogle.IsChecked = true;
                    pushAbteilungenToTreeView();
                    break;
                case 6:
                  
                    selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 3));
                    selectedAbteilungen.Add(abteilungList.Find(x => x.ID == 2));
                    augenToogle.IsChecked = false;
                    innereToogle.IsChecked = true;
                    hnoToogle.IsChecked = true;
                    pushAbteilungenToTreeView();
                    break;
                case 7:
                    
                   
                    augenToogle.IsChecked = false;
                    innereToogle.IsChecked = false;
                    hnoToogle.IsChecked = false;
                    pushAbteilungenToTreeView();
                    break;


            }
            }
        }

        private void toogleClick(object sender, RoutedEventArgs e)
        {
            if (augenToogle.IsChecked == true)
            {
                if (innereToogle.IsChecked == true)
                {
                    if (hnoToogle.IsChecked==true)
                    {
                        comboSelectionAbt.SelectedIndex = 0;
                    }
                    else
                    {
                        comboSelectionAbt.SelectedIndex = 4;
                    }
                    
                }
                else if (hnoToogle.IsChecked == true)
                {
                    comboSelectionAbt.SelectedIndex = 4;
                }
                else
                {
                    comboSelectionAbt.SelectedIndex = 1;
                }
                
            }
            else if (innereToogle.IsChecked == true)
            {
                if (hnoToogle.IsChecked == true)
                {
                    comboSelectionAbt.SelectedIndex = 6;
                }
                else
                {
                    comboSelectionAbt.SelectedIndex = 2;
                }

            }
            else if (hnoToogle.IsChecked == true)
            {
                comboSelectionAbt.SelectedIndex = 3;
            }
            else
            {
                comboSelectionAbt.SelectedIndex = 7;
            }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ArztLoadIn!=0)
            {

            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (Abteilung abt in abteilungList)
                    {
                            foreach (Arzt ar in abt.aerzte)
                            {
                                ar.Patienten.Clear();
                            }
                        
                    }



                    foreach (string line in lines)
                    {
                        if (Patient.TryParse(line, out Patient p))
                        {

                            abteilungList.Find(x => x.aerzte.Find(x => x.ID == p.ArztID) != null).aerzte.Find(x => x.ID == p.ArztID).Patienten.Add(p);




                        }
                        else
                        {

                        }
                    }
                    
                    foreach(var arzt in abteilungList.Find(x=>x.ID==1).aerzte) {

                            foreach(var Patient in arzt.Patienten)
                            {
                                ListBoxAuge.Items.Add(Patient);
                            }
                            
                       
                      }
                        foreach (var arzt in abteilungList.Find(x => x.ID == 2).aerzte)
                        {

                            foreach (var Patient in arzt.Patienten)
                            {
                                ListViewInnere.Items.Add(Patient);
                            }


                        }
                        int row = 0;
                        foreach (var arzt in abteilungList.Find(x => x.ID == 3).aerzte)
                        {
                            
                            foreach (var Patient in arzt.Patienten)
                            {
                                row++;
                                RowDefinition rd = new RowDefinition() ;
                                GridLength gr = new GridLength(70);
                                rd.Height = gr;
                                GridHNO.RowDefinitions.Add(rd);
                                Label lb = new Label();
                                lb.Content = Patient.SVN;
                                Grid.SetColumn(lb, 0);
                                Grid.SetRow(lb,row);
                                GridHNO.Children.Add(lb);
                                 lb = new Label();
                                lb.Content = Patient.FirstName;
                                Grid.SetColumn(lb, 1);
                                Grid.SetRow(lb, row);
                                GridHNO.Children.Add(lb);
                                lb = new Label();
                                lb.Content = Patient.FirstName;
                                Grid.SetColumn(lb, 2);
                                Grid.SetRow(lb, row);
                                GridHNO.Children.Add(lb);
                                ComboBox cb = new ComboBox();
                                foreach(var kh in Patient.Krankheiten)
                                {
                                    cb.Items.Add(kh);
                                }
                                Grid.SetColumn(cb, 3);
                                Grid.SetRow(cb, row);
                                GridHNO.Children.Add(cb);
                            }


                        }

                    }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while reading the CSV file: {ex.Message}", "CSV File Reading Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            }
        }
    }
    }

