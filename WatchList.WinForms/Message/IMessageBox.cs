using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.WinForms.Message
{
    public interface IMessageBox
    {
        public bool ShowQuestion(string message);
    }
}
