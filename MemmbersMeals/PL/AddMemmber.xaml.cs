using FluentValidation.Results;
using MemmbersMeals.DAL;
using MemmbersMeals.PL.Helpers;
using MemmbersMeals.PL.Validators;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MemmbersMeals
{
    /// <summary>
    /// Interaction logic for AddMemmber.xaml
    /// </summary>
    public partial class AddMemmber : Window
    {
        #region Instance variables
        private UnitOFWork unitOFWork = new UnitOFWork(new MealsModel());
        private Memmber CreatedMemmber;
        private MemmberValidators ValidationRules = new MemmberValidators();
        #endregion

        #region Constructors
        public AddMemmber()
        {
            InitializeComponent();
            txtName.Focus();
            UIUtilities.ErrorLabelsConfig(txtCreditErrorMessage, txtNameErrorMessage);
        }
        #endregion


        #region Event listners
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            decimal CreditResult;
            decimal.TryParse(txtCredit.Text, out CreditResult);
            CreatedMemmber = new Memmber
            {
                Name = txtName.Text,
                Credit = CreditResult
            };

            var result = ValidationRules.Validate(CreatedMemmber);

            if (result.IsValid)
            {
                UIUtilities.TextBlocksRefresh(txtCreditErrorMessage, txtNameErrorMessage);
                UIUtilities.TextBoxsErrorRefresh(txtCredit, txtName);
                unitOFWork.Memmbers.Add(CreatedMemmber);
                unitOFWork.Complete();
                txtName.Clear();
                txtCredit.Clear();
                MessageBox.Show("Done..");
                unitOFWork.Dispose();
            }
            else
            {
                GenerateErrorMessages(result);
            }
        }
        #endregion

        private void GenerateErrorMessages(FluentValidation.Results.ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                switch (error.PropertyName)
                {
                    case "Name":
                        UIUtilities.TextBlockErrorEffect(txtNameErrorMessage, error.ErrorMessage);
                        UIUtilities.TextBoxErrorEffect(txtName);
                        if (result.Errors.Count == 1)
                        {
                            UIUtilities.TextBlocksRefresh(txtCreditErrorMessage);
                            UIUtilities.TextBoxsErrorRefresh(txtCredit);
                        }

                        break;
                    case "Credit":
                        UIUtilities.TextBlockErrorEffect(txtCreditErrorMessage, error.ErrorMessage);
                        UIUtilities.TextBoxErrorEffect(txtCredit);
                        if (result.Errors.Count == 1)
                        {
                            UIUtilities.TextBlocksRefresh(txtNameErrorMessage);
                            UIUtilities.TextBoxsErrorRefresh(txtName);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
