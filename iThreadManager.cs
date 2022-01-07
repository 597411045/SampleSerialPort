using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleSerialPort
{
    class iThreadManager
    {
        private Form _form;
        public List<Thread> _listThreads;
        public delegate void _delegates();


        public iThreadManager(Form form)
        {
            _form = form;
            _listThreads = new List<Thread>();
        }

        public void newThread(_delegates d)
        {
            Thread t = new Thread(new ThreadStart(delegate { autoThreadAction(d); }));
            _listThreads.Add(t);
        }

        private void autoThreadAction(_delegates d)
        {
            while (true)
            {
                Thread.Sleep(1000);
                _form.Invoke(d);
            }
        }
    }
}
