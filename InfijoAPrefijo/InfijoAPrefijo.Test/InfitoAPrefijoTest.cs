using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfijoAPrefijo.Core;

namespace InfijoAPrefijo.Test
{
    [TestClass]
    public class InfitoAPrefijoTest
    {
        [TestMethod]
        public void PruebasConversion()
        {
            ConvertidorInfijoAPrefijo c = new ConvertidorInfijoAPrefijo();
            StringAssert.Equals("+ 3 3", c.Convertir("3+3"));
            StringAssert.Equals("+ 3 / 3 4", c.Convertir("3+3/4"));
<<<<<<< HEAD
=======
            StringAssert.Equals("+ 3.7 / 3 4.8", c.Convertir("3.7+3/4.8"));
>>>>>>> 066bc30769c28cf29a04f2ab41611e042dbf6ef3
        }
    }
}
