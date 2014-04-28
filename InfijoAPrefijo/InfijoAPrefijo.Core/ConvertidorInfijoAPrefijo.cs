using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfijoAPrefijo.Core
{
    public class ConvertidorInfijoAPrefijo
    {
       public string Convertir(string infijo) {
            string prefijo = "";
            Stack<char> pPrefijo = PilaInfijoPrefijo(infijo);
            while (pPrefijo.Count > 0)
                prefijo += pPrefijo.Pop()+" ";
            return prefijo;
        }

        Stack<char> PilaInfijoPrefijo(string infijo)
        {
            infijo = "(" + infijo;
            int tam = infijo.Length;
            Stack<char> pInfija = new Stack<char>();
            Stack<char> PilaTemp = new Stack<char>();
            PilaTemp.Push(')'); // Agregamos a la pila temporal un '('
            for (int i = tam - 1; i > -1; i--)
            {
                char caracter = infijo[i];
                switch (caracter)
                {
                    case ')':
                        PilaTemp.Push(caracter);
                        break;
                    case '+':
                    case '-':
                    case '^':
                    case '*':
                    case '/':
                        while (Jerarquia(caracter) > Jerarquia(PilaTemp.Peek()))
                            pInfija.Push(PilaTemp.Pop());
                        PilaTemp.Push(caracter);
                        break;
                    case '(':
                        while (PilaTemp.Peek() != ')')
                            pInfija.Push(PilaTemp.Pop());
                        PilaTemp.Pop();
                        break;
                    default:
                        pInfija.Push(caracter);
                        break;
                }
            }
            return pInfija;

        }

        int Jerarquia(char elemento)
        {
            int res = 0;
            switch (elemento)
            {
                case ')':
                    res = 5; break;
                case '^':
                    res = 2; break;
                case '*':
                case '/':
                    res = 3; break;
                case '+':
                case '-':
                    res = 4; break;

            }
            return res;
        }
       
    }
}
