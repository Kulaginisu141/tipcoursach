using System;

namespace WpfApplication1 {
    [Serializable]
    public class BooleanOperatorNot : IBooleanOperator
    {
        public override string ToString() {
            return "¬";
        }
    }
}