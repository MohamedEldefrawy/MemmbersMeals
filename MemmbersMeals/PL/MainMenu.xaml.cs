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
        private Memmber SelectedMemmber;

        public MainWindow()
        {
            InitializeComponent();
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetAll().Where(m => m.IsDeleted == false).ToList();
        }

        private void MnitmAddMemmber_Click(object sender, RoutedEventArgs e)
        {
            AddMemmber addMemmber = new AddMemmber();
            addMemmber.Show();
        }

        private void BtnViewAllMemmbers_Click(object sender, RoutedEventArgs e)
        {
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetAll()
                .Where(m => m.IsDeleted == false).ToList();
        }

        private void MnitmAddMeal_Click(object sender, RoutedEventArgs e)
        {
            AddMeal addMeal = new AddMeal();
            addMeal.Show();
        }

        private void BtnViewAllDebtMemmbers_Click(object sender, RoutedEventArgs e)
        {
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetDebitMemmbers()
                .Where(m => m.IsDeleted == false).ToList();
        }

        private void BtnViewAllInDebtMemmbers_Click(object sender, RoutedEventArgs e)
        {
            dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetInDebitMemmbers()
                .Where(m => m.IsDeleted == false).ToList();
        }

        private void TxtSearch_SearchBoxTextChanged(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Search")

                dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetAll()
                    .Where(m => m.IsDeleted == false).ToList();
            else
                dgMemmbers.ItemsSource = unitOFWork.Memmbers.GetMemmberbyName(txtSearch.Text)
                    .Where(m => m.IsDeleted == false).ToList();
        }
        private void btnEditMemmber_Click(object sender, RoutedEventArgs e)
        {
            SelectedMemmber = (Memmber)dgMemmbers.SelectedItem;
            EditMemmber editMemmber = new EditMemmber(SelectedMemmber.ID);
            editMemmber.Show();
        }

        private void btnDeleteMemmber_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            SelectedMemmber = (Memmber)dgMemmbers.SelectedItem;
            switch (result)
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                    unitOFWork.Memmbers.Remove(SelectedMemmber);
                    unitOFWork.Complete();
                    unitOFWork.Dispose();
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    break;
            }
        }
    }
}
