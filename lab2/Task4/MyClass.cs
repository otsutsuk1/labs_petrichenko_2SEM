using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class MyClass<T> where T : new()
    {
        public static T FacrotyMethod()
        {
            return new T();
        }
    }
}
