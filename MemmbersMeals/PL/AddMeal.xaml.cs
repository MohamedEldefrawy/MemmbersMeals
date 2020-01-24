using MemmbersMeals.DAL;
using MemmbersMeals.PL.Helpers;
using MemmbersMeals.PL.Validators;
using System;
using System.Linq;
using System.Windows;

namespace MemmbersMeals.PL
{
    /// <summary>
    /// Interaction logic for AddMeal.xaml
    /// </summary>
    public partial class AddMeal : Window
    {
        UnitOFWork unitOfWork = new UnitOFWork(new MealsModel());
        MealValidator validationRules = new MealValidator();

        public AddMeal()
        {
            InitializeComponent();
            UIUtilities.ErrorLabelsConfig(txtPriceErrorMessage, txtDateErrorMessage);
            cmbMealType.ItemsSource = Enum.GetValues(typeof(MealsType));
            cmbMealType.SelectedItem = MealsType.Dinner;
            cmbMemmber.ItemsSource = unitOfWork.Memmbers.GetAll()
                .ToList()
                .Where(m => m.IsDeleted == false)
                .Select(m => m.Name).ToList();
            cmbMemmber.SelectedIndex = 0;
            datpicMeal.SelectedDate = DateTime.Now;
            txtPrice.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Meal CreatedMeal = new Meal
            {
                MealsDate = (DateTime)datpicMeal.SelectedDate,
                MealType = cmbMealType.SelectedIndex,
                Price = ParseDecimalString.Parse(txtPrice.Text),
                Memmber = unitOfWork.Memmbers.Find(m => m.Name == cmbMemmber.SelectedItem.ToString())
                .FirstOrDefault()
            };

            var validationResult = validationRules.Validate(CreatedMeal);

            if (validationResult.IsValid)
            {
                unitOfWork.Meals.Add(CreatedMeal);
                unitOfWork.Complete();
                txtPrice.Clear();
                MessageBox.Show("Done");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    switch (error.PropertyName)
                    {
                        case "Price":
                            UIUtilities.TextBlockErrorEffect(txtPriceErrorMessage, error.ErrorMessage);
                            UIUtilities.TextBoxErrorEffect(txtPrice);
                            if (validationResult.Errors.Count == 1)
                            {
                                UIUtilities.DatePickerRefresh(datpicMeal);
                            }
                            break;
                        case "Date":
                            UIUtilities.DateTimeErrorEffect(datpicMeal);
                            UIUtilities.TextBlockErrorEffect(txtDateErrorMessage, error.ErrorMessage);
                            if (validationResult.Errors.Count == 1)
                            {
                                UIUtilities.TextBoxsErrorRefresh(txtPrice);
                                UIUtilities.TextBlocksRefresh(txtPriceErrorMessage);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }

        }
    }
}
