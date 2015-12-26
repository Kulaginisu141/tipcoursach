using System;

namespace WpfApplication1 {
    [Serializable]
    public class BooleanOperandTrue : BooleanOperand
    {
        public override string ToString() {
            return "True";
        }
    }
}