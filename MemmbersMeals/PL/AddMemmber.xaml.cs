using MemmbersMeals.DAL;
using System;
using System.Windows;

namespace MemmbersMeals
{
    /// <summary>
    /// Interaction logic for AddMemmber.xaml
    /// </summary>
    public partial class AddMemmber : Window
    {
        UnitOFWork unitOFWork = new UnitOFWork(new MealsModel());
        public AddMemmber()
        {
            InitializeComponent();
            txtName.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            unitOFWork.Memmbers.Add(new Memmber
            {
                Name = txtName.Text,
                Credit = Decimal.Parse(txtCredit.Text)
            });

            unitOFWork.Complete();
            txtName.Clear();
            txtCredit.Clear();
            MessageBox.Show("Done..");
            unitOFWork.Dispose();
        }
    }
}
