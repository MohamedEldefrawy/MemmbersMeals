using MemmbersMeals.DAL;
using MemmbersMeals.PL;
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

namespace MemmbersMeals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitOFWork unitOFWork = new UnitOFWork(new MealsModel());
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnitmAddMemmber_Click(object sender, RoutedEventArgs e)
        {
            AddMemmber addMemmber = new AddMemmber();
            addMemmber.Show();
        }

        private void btnViewMemmbers_Click(object sender, RoutedEventArgs e)
        {
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetAll();
        }

        private void mnitmAddMeal_Click(object sender, RoutedEventArgs e)
        {
            AddMeal addMeal = new AddMeal();
            addMeal.Show();
        }
    }
}
