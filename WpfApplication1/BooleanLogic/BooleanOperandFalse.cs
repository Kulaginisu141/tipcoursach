using System;

namespace WpfApplication1 {
    [Serializable]
    public class BooleanOperandFalse : BooleanOperand
    {
        public override string ToString() {
            return "False";
        }
    }
}