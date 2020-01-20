using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MemmbersMeals.PL.Helpers
{
    public static class UIUtilities
    {
        public static void ErrorLabelsConfig(params TextBlock[] errorsMessages)
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

        public static void TextBlocksRefresh(params TextBlock[] textBlocks)
        {
            foreach (var textBlock in textBlocks)
            {
                textBlock.Visibility = Visibility.Collapsed;
            }
        }

        public static void TextBoxsErrorRefresh(params TextBox[] textBoxs)
        {
            foreach (var textBox in textBoxs)
            {
                textBox.BorderBrush = Brushes.LightGray;
            }
        }

        public static void TextBlockErrorEffect(TextBlock textBlocks, string error)
        {
            textBlocks.Visibility = Visibility.Visible;
            textBlocks.Text = error;
        }

        public static void TextBoxErrorEffect(params TextBox[] textBoxes)
        {
            foreach (var textbox in textBoxes)
            {
                textbox.BorderBrush = Brushes.IndianRed;
            }
        }
    }
}
