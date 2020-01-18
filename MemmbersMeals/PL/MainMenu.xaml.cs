using MemmbersMeals.DAL;
using MemmbersMeals.PL;
using System.Linq;
using System.Windows;

namespace MemmbersMeals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly UnitOFWork unitOFWork = new UnitOFWork(new MealsModel());
        public MainWindow()
        {
            InitializeComponent();
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetAll().ToList();
        }

        private void MnitmAddMemmber_Click(object sender, RoutedEventArgs e)
        {
            AddMemmber addMemmber = new AddMemmber();
            addMemmber.Show();
        }

        private void BtnViewAllMemmbers_Click(object sender, RoutedEventArgs e)
        {
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetAll().ToList();
        }

        private void MnitmAddMeal_Click(object sender, RoutedEventArgs e)
        {
            AddMeal addMeal = new AddMeal();
            addMeal.Show();
        }

        private void BtnViewAllDebtMemmbers_Click(object sender, RoutedEventArgs e)
        {
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetDebitMemmbers().ToList();
        }

        private void BtnViewAllInDebtMemmbers_Click(object sender, RoutedEventArgs e)
        {
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetInDebitMemmbers().ToList();
        }

        private void TxtSearch_SearchBoxTextChanged(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Search")

                dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetAll().ToList();
            else
                dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetMemmberbyName(txtSearch.Text);
        }

        private void btnEditMemmber_Click(object sender, RoutedEventArgs e)
        {
            Memmber selectedMemmber = (Memmber)dgMemmbers.SelectedItem;
            EditMemmber editMemmber = new EditMemmber(selectedMemmber.ID);
            editMemmber.Show();
        }

        private void btnDeleteMemmber_Click(object sender, RoutedEventArgs e)
        {
            //Do somthing
        }
    }
}
