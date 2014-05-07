using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfijoAPrefijo.Core
{
    public class Transition
    {
        public Transition(int initial, UnicodeCategory cat, int result)
        {
            InitalState = initial;
            Input = cat;
            ResultState = result;
        }
        public int InitalState { get; set; }
        public UnicodeCategory Input { get; set; }
        public int ResultState { get; set; }
    }
    public static class Tokenizer
    {
        static Tokenizer() {
            TransitionList = new List<Transition>();
            TransitionList.Add(new Transition(0,UnicodeCategory.DecimalDigitNumber,1));
            TransitionList.Add(new Transition(0, UnicodeCategory.MathSymbol, 2));
            TransitionList.Add(new Transition(0, UnicodeCategory.OpenPunctuation, 3));
            TransitionList.Add(new Transition(0, UnicodeCategory.ClosePunctuation, 4));
            TransitionList.Add(new Transition(1, UnicodeCategory.DecimalDigitNumber, 2));
            TransitionList.Add(new Transition(1, UnicodeCategory.OtherPunctuation, 5));
            TransitionList.Add(new Transition(5, UnicodeCategory.DecimalDigitNumber, 6));
            TransitionList.Add(new Transition(6, UnicodeCategory.DecimalDigitNumber, 6));
        }
        public static List<Token> Tokenize(string inputString)
        {


            var list = new List<Token>();
            Queue<char> inputQ = new Queue<char>(inputString.AsEnumerable());
            while (inputQ.Count > 0)
            {
                string cad = "";
                int state = 0;
                do
                {
                    char c;
                    do
                    {
                        c = inputQ.Dequeue();
                       
                    } while (!IsValid(c) && inputQ.Count > 0);
                    if (!IsValid(c))
                        continue;
                    cad += c;
                    state = NextState(state, c);
                } while (inputQ.Count > 0 &&(!IsFinal(state) || NextState(state, inputQ.Peek()) != -1 ));
                if (state != -1)
                    list.Add(new Token() { Value = cad, TokenType = ResolveTokenType(state)  });

            }
            return list;
        }
        static bool IsValid(char c)
        {
            var cat = char.GetUnicodeCategory(c);
            return (cat == UnicodeCategory.ClosePunctuation
                || cat == UnicodeCategory.OpenPunctuation
                || cat == UnicodeCategory.MathSymbol
                || cat == UnicodeCategory.DecimalDigitNumber
                || c == '.'
                || c == '*'
                || c == '/'
                || c == '-');
        }

        static bool IsFinal(int state)
        {
            return (state == 1//Num
                || state == 2//op
                || state == 3//close
                || state == 4 // open
                || state == 6// real
                || state == -1);//error
        }

        static int NextState(int state, char c)
        {
            var cat =char.GetUnicodeCategory(c);
            if(c == '*' || c == '/' || c=='-')
                cat = UnicodeCategory.MathSymbol;

            if(!IsValid(c))
                return -1;
            Transition t = TransitionList.Where(tr => tr.InitalState == state && tr.Input == cat ).FirstOrDefault();
            if (t == null)
                return -1;
            return t.ResultState;
        }

        static TokenType ResolveTokenType(int state) {
            switch (state) {
                case 1: case 6: return TokenType.Number;
                case 2: return TokenType.Operator;
                case 3: return TokenType.OpenDelim;
                case 4: return TokenType.CloseDelim;
            }
            return TokenType.Invalid;
        }

        static List<Transition> TransitionList { get; set; }

    }
}
