using System;
using System.Windows.Controls;

namespace TaskManager.Windows
{
    public static class DescriptionHelpers
    {
        // Method used by both Add and Edit Window
        // Contains the logic for the word counter located on gui under the textboxes

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
