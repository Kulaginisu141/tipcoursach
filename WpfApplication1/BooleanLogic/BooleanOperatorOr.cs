using System;

namespace WpfApplication1 {
    [Serializable]
    public class BooleanOperatorOr : IBooleanOperator
    {
        public override string ToString()
        {
            return "|";
        }
    }
}