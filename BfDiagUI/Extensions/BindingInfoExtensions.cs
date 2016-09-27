using BindingFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BfDiagUI
{
    public static class BindingInfoExtensions
    {
        public static string BindingFileEnvironment(string bindingFileName)
        {
            string bindingFileEnvironment = "";

            if (bindingFileName != null)
            {
                string fileNameOnly = Path.GetFileNameWithoutExtension(bindingFileName);
                int pos = fileNameOnly.LastIndexOf(".");

                if (pos > 0 && fileNameOnly.Length > pos)
                {
                    bindingFileEnvironment = fileNameOnly.Substring(pos + 1);
                }
            }

            return bindingFileEnvironment;

        }
    }
}
