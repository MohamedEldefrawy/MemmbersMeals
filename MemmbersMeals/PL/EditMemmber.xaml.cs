using MemmbersMeals.DAL;
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

namespace MemmbersMeals.PL
{
    /// <summary>
    /// Interaction logic for EditMemmber.xaml
    /// </summary>
    public partial class EditMemmber : Window
    {
        UnitOFWork unitOfWork = new UnitOFWork(new MealsModel());
        private Memmber selectedMemmber;

        public EditMemmber(int MemmberID)
        {
            InitializeComponent();
            selectedMemmber = unitOfWork.Memmbers.Get(MemmberID);
            txtName.Text = selectedMemmber.Name;
            txtCredit.Text = selectedMemmber.Credit.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Do somthing
        }
    }
}
