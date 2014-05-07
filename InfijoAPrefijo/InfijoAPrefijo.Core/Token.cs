using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfijoAPrefijo.Core
{
    public enum TokenType { Operator, Number, OpenDelim, CloseDelim, Invalid}
    
    public class Token :IEquatable<Token>
    {
        public Token() { Value = string.Empty; }
        public TokenType TokenType{get;set;}
        public string Value{get;set;}

        public int Hierarchy {
            get {
                switch (TokenType)
                {
                    case TokenType.CloseDelim:
                        return 5;
                    case TokenType.Operator:
                        switch (Value)
                        {
                            case "+":
                            case "-":
                                return 4;
                            case "*":
                            case "/":
                                return 3;
                            case "^":
                                return 2;
                        }
                        return 0;
                }
                return 0;
            }
        }

        public override string ToString()
        {
            return Value;
        }

        public bool Equals(Token other)
        {
            return this.Value == other.Value;
        }

       
    }

   
}
