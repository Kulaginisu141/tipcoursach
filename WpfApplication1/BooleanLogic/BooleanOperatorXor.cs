using System;

namespace WpfApplication1 {
    [Serializable]
    public class BooleanOperatorXor : IBooleanOperator
    {
        public override string ToString()
        {
            return "^";
        }
    }
}