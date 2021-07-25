using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryCalculator.Helpers
{
    /// <summary>
    /// Common value setting functionality
    /// </summary>
    public class RangeSetter
    {
        static public int SetLower(int val, int min = 0) => val < min ? min : val;
        static public int SetUpper(int val, int max = 50) => val > max ? max : val;
        static public int Set(int val, int min = 0, int max = 50)
        {
            val = SetLower(val, min);
            val = SetUpper(val, max);
            return val;
        }
    }
}
