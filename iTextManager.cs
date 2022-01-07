using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleSerialPort
{
    class iTextManager
    {
        private Form _form;
        public StringBuilder _stringBuilder;

        public iTextManager(Form form)
        {
            _form = form;
            _stringBuilder = new StringBuilder();
        }
    }
}
