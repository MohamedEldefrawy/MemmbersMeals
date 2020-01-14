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
using MemmbersMeals.DAL;

namespace MemmbersMeals.PL
{
    /// <summary>
    /// Interaction logic for AddMeal.xaml
    /// </summary>
    public partial class AddMeal : Window, IDisposable
    {
        UnitOFWork unitOfWork = new UnitOFWork(new MealsModel());
        public AddMeal()
        {
            InitializeComponent();
            cmbMealType.ItemsSource = Enum.GetValues(typeof(MealsType));
            cmbMealType.SelectedItem = MealsType.Dinner;
            cmbMemmber.ItemsSource = unitOfWork.Memmbers.GetAll().ToList().Select(m => m.Name);
            datpicMeal.SelectedDate = DateTime.Now;
            txtPrice.Focus();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.Meals.Add(new Meal
            {
                MealsDate = datpicMeal.SelectedDate,
                MealType = cmbMealType.SelectedIndex,
                Price = decimal.Parse(txtPrice.Text),
                MemmberID = unitOfWork.Memmbers.Find(m => m.Name == cmbMemmber.SelectedItem.ToString())
                .FirstOrDefault().ID
            });

            unitOfWork.Complete();
            txtPrice.Clear();
            MessageBox.Show("Done");
        }
    }
}
