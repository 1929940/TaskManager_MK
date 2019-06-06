using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskManager.Windows
{
    public static class DescriptionHelpers
    {
        public static void ValidateTextbox(TextBox textBox, Label label)
        {
            int counter = 0;

            counter = 1000 - textBox.Text.Length;

            if (counter == 0)
            {
                label.Opacity = 1;
                label.Foreground = System.Windows.Media.Brushes.Red;

                System.Media.SystemSounds.Beep.Play();
            }
            else
            {
                label.Opacity = 0.3;
                label.Foreground = System.Windows.Media.Brushes.Black;
            }
            label.Content = counter;
        }


    }
}
