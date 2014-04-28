using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfijoAPrefijo.Form.ViewModels
{
    public class InfixConverterViewModel
    {
        string infix;

        public string Infix
        {
            get { return infix; }
            set { infix = value; }
        }
        string prefix;

        public string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }
    }
}
