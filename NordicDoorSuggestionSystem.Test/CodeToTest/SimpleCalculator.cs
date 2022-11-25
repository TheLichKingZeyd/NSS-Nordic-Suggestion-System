using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordicDoorSuggestionSystem.Test.CodeToTest
{
    public class SimpleCalculator
    {
        public int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }

        public int SubtractTwoNumbers(int a, int b)
        {
            return a - b;
        }

        public float DivideAByB(float a, float b)
        {
            if (b == 0)
            {
                return 0;
            } 
            else
            {
                return a / b;
            }
            
        }

        public float MultiplyTwoNumbers(float a, float b)
        {
            return a * b;
        }

    }
}
