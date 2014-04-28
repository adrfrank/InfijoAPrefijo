using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdrfrankLibrary.Core;
using InfijoAPrefijo.Core;
using System.Diagnostics;

namespace InfijoAPrefijo.Form.ViewModels
{
    public class InfixConverterViewModel : NotifyPropetryAdapter
    {
        ConvertidorInfijoAPrefijo convertidor = new ConvertidorInfijoAPrefijo();
        ActionCommand convertir;
        public ActionCommand Convertir
        {
            get
            {
                if (convertir == null)
                {
                    convertir = new ActionCommand(() => {
                        OnPropertyChanged("Prefix");
                    });
                }
                return convertir;
            }

        }

        string infix;

        public string Infix
        {
            get { return infix; }
            set
            {
                infix = value;
                OnPropertyChanged("Infix");
                
            }
        }

        public string Prefix
        {
            get
            {
                string prefix = "";
                try
                {
                    prefix = convertidor.Convertir(infix);

                }
                catch (Exception ex)
                {
                    prefix = "Expresión no válida";
                    Trace.Write("Ocurrió un problema con la conversión: ");
                    Trace.WriteLine(ex.Message);
                    Trace.Write(ex.StackTrace);
                }
                return prefix;
            }

        }
    }
}
