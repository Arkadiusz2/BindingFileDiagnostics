using BfDiagUI.API;
using BindingFile;
using BindingFile.Diagnostics.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BfDiagUI
{
    public abstract class BaseViewController<T, U> where T : Control
    {
        protected BaseViewController(T control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            this.Control = control;
        }

        public T Control
        {
            get;
            private set;
        }

        /// <summary>
        /// The data source
        /// </summary>
        public U DataSource
        {
            get;
            set;
        }

        public abstract void Bind();
    }
}
