using System;

namespace WpfApplication1 {
    [Serializable]
    public class BooleanOperatorAnd : IBooleanOperator
    {
        public override string ToString() {
            return "&";
        }
    }
}