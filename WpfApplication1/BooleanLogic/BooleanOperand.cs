using System;
using System.Windows;
using System.Windows.Data;

namespace WpfApplication1 {
    [Serializable]
    public class BooleanOperand : IBooleanElement {
        public override string ToString() {
            return "x";
        }
        
    }
}