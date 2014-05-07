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
            Stack<Token> pPrefijo = PilaInfijoPrefijo(infijo);
            while (pPrefijo.Count > 0)
                prefijo += pPrefijo.Pop()+" ";
            return prefijo;
        }

       Stack<Token> PilaInfijoPrefijo(string infijo)
        {
            List<Token> tokens = Tokenizer.Tokenize("(" + infijo);           
            int tam = tokens.Count;
            Stack<Token> pInfija = new Stack<Token>();
            Stack<Token> PilaTemp = new Stack<Token>();
            PilaTemp.Push(new Token() { Value=")", TokenType =  TokenType.CloseDelim }); // Agregamos a la pila temporal un '('
            for (int i = tam - 1; i > -1; i--)
            {
                Token caracter = tokens[i];
                switch (caracter.TokenType)
                {
                    case TokenType.CloseDelim:
                        PilaTemp.Push(caracter);
                        break;
                    case TokenType.Operator:
                        while (caracter.Hierarchy > PilaTemp.Peek().Hierarchy)
                            pInfija.Push(PilaTemp.Pop());
                        PilaTemp.Push(caracter);
                        break;
                    case TokenType.OpenDelim:
                        while (PilaTemp.Peek().TokenType != TokenType.CloseDelim)
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
       
    }
}
