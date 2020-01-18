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
        public int ID { get; set; }
        private Memmber SelectedMemmber;

        public EditMemmber(int MemmberID)
        {
            InitializeComponent();
            this.ID = MemmberID;
            SelectedMemmber = unitOfWork.Memmbers.Get(MemmberID);
            txtName.Text = SelectedMemmber.Name;
            txtCredit.Text = SelectedMemmber.Credit.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SelectedMemmber.Name = txtName.Text;
            SelectedMemmber.Credit = decimal.Parse(txtCredit.Text);

            unitOfWork.Memmbers.UpdateMemmber(SelectedMemmber);
            MessageBoxResult result = MessageBox.Show("Are you sure ?",
                "Alert message", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    unitOfWork.Complete();
                    unitOfWork.Dispose();
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }

        }
    }
}
