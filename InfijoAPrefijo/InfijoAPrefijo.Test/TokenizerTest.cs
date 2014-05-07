using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfijoAPrefijo.Core;

namespace InfijoAPrefijo.Test
{
    [TestClass]
    public class TokenizerTest
    {
        [TestMethod]
        public void CountTokenList()
        {
            Assert.AreEqual(3, Tokenizer.Tokenize("3+3").Count);
            Assert.AreEqual(1, Tokenizer.Tokenize("3").Count);
        }

        [TestMethod]
        public void TokenTest() {
            var t1 = new Token() { TokenType = TokenType.Number, Value = "8" };
            var t2 = new Token() { TokenType = TokenType.Number, Value = "8" };
            Assert.AreEqual(t1.Value,t2.Value );
        }

        [TestMethod]
        public void TokenList() {
            var t = Tokenizer.Tokenize("3+3");
            CollectionAssert.AllItemsAreInstancesOfType(t, typeof(Token));
            CollectionAssert.AllItemsAreNotNull(t);
            Assert.AreEqual(new Token() { TokenType = TokenType.Operator, Value = "+" }.Value, t[1].Value);
            var t2 = Tokenizer.Tokenize("+-*/");
            Assert.AreEqual(4, t2.Count);
            
        }
    }
}
