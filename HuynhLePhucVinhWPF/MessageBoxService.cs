using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HuynhLePhucVinhWPF
{
   public class MessageBoxService : IMessageBoxService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowError(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }

        public int ShowMessageBoxYesNo()
        {
            // Display a message box with Yes and No buttons
            MessageBoxResult result = MessageBox.Show(
                "Do you want to delete?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            // Handle the user's response
            switch (result)
            {
                case MessageBoxResult.Yes:
                    return 1;

                case MessageBoxResult.No:

                    return 0;

                default:
                    return 2;

            }
        }

    }
}
