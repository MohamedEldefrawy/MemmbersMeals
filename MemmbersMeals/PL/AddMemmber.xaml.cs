using FluentValidation.Results;
using MemmbersMeals.DAL;
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
            ErrorLabelsConfig(txtCreditErrorMessage, txtNameErrorMessage);
        }
        #endregion

        #region Controls Configurations
        private void ErrorLabelsConfig(params TextBlock[] errorsMessages)
        {
            foreach (var errorMessage in errorsMessages)
            {
                errorMessage.Text = "";
                errorMessage.TextWrapping = TextWrapping.Wrap;
                errorMessage.Visibility = Visibility.Collapsed;
                errorMessage.Foreground = Brushes.IndianRed;
                errorMessage.FontSize = 10;
                errorMessage.FontWeight = FontWeights.Bold;
            }
        }

        private void TextBlocksRefresh(params TextBlock[] textBlocks)
        {
            foreach (var textBlock in textBlocks)
            {
                textBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void TextBoxsRefresh(params TextBox[] textBoxs)
        {
            foreach (var textBox in textBoxs)
            {
                textBox.BorderBrush = Brushes.Black;

            }
        }

        private void TextBlockErrorEffect(TextBlock textBlocks, string error)
        {
            textBlocks.Visibility = Visibility.Visible;
            textBlocks.Text = error;
        }

        private void TextBoxErrorEffect(params TextBox[] textBoxes)
        {
            foreach (var textbox in textBoxes)
            {
                textbox.BorderBrush = Brushes.IndianRed;
            }
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
                TextBlocksRefresh(txtCreditErrorMessage, txtNameErrorMessage);
                TextBoxsRefresh(txtCredit, txtName);
                unitOFWork.Memmbers.Add(CreatedMemmber);
                unitOFWork.Complete();
                txtName.Clear();
                txtCredit.Clear();
                MessageBox.Show("Done..");
                unitOFWork.Dispose();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    switch (error.PropertyName)
                    {
                        case "Name":
                            TextBlockErrorEffect(txtNameErrorMessage, error.ErrorMessage);
                            TextBoxErrorEffect(txtName);

                            break;
                        case "Credit":
                            TextBlockErrorEffect(txtCreditErrorMessage, error.ErrorMessage);
                            TextBoxErrorEffect(txtCredit);
                            break;
                    }
                }
            }
        }

        #endregion
    }
}
