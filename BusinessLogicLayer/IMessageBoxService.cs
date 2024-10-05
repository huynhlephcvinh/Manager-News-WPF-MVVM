using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IMessageBoxService
    {
        void Show(string message);
        void ShowError(Exception ex);
        int ShowMessageBoxYesNo();
    }
}
