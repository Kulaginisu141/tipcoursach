using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace WpfApplication1 {
    [Serializable]
    internal class Model {

        private List<IBooleanElement> s;

        public Model(List<IBooleanElement> s1) {
            this.s = s1;
        }

        public Model() {
            s = new List<IBooleanElement>();
        }

        public int Numberofoperands {
            get { return s.Count(e => e is BooleanOperand); }
        }



        public int eval() {
            if (ifcanaddoperand())
            {
                return 2;
            }
            List<IBooleanElement> scop=s;
            bool ans=false;
            IBooleanElement lastoperand = null;
            for (int i=0;i<scop.Count;i++)
            {
                if (scop[i].GetType()==typeof(BooleanOperatorNot))
                {
                    if (scop[i+1].GetType()==typeof(BooleanOperandTrue))
                    {
                        scop[i + 1] = new BooleanOperandFalse();
                    }
                    else
                    {
                        scop[i + 1] = new BooleanOperandTrue();
                    }
                }
                if (scop[i].GetType().IsSubclassOf(typeof(BooleanOperand)) || typeof(BooleanOperand) == scop[i].GetType())
                {
                    if (lastoperand == null)
                    {
                        ans = scop[i].GetType() == typeof(BooleanOperandTrue);
                    }
                    else
                    {
                        if (lastoperand.GetType() == typeof(BooleanOperatorAnd))
                        {
                            ans = ans && scop[i].GetType() == typeof(BooleanOperandTrue);
                        }
                        if (lastoperand.GetType() == typeof(BooleanOperatorOr))
                        {
                            ans = ans || scop[i].GetType() == typeof(BooleanOperandTrue);
                        }
                        if (lastoperand.GetType() == typeof(BooleanOperatorXor))
                        {
                            ans = ans ^ scop[i].GetType() == typeof(BooleanOperandTrue);
                        }
                        lastoperand = null;
                    }
                }
                else
                {
                    lastoperand = scop[i];
                }
            }

            if (ans)
            return 1;
            return 0;
        }

        public List<int> getinfo()
        {
            List<int> sor = new List<int>();
            for (int i=0;i<s.Count;i++)
            {
                if (s[i].GetType() == typeof(BooleanOperandTrue))
                {
                    sor.Add(1);
                }
                if (s[i].GetType() == typeof(BooleanOperandFalse))
                {

                    sor.Add(0);
                }
                if (s[i].GetType() == typeof(BooleanOperand))
                {

                    sor.Add(2);
                }
            }
            return sor;
        }

        public string ModeltoString() {
            string ans = "";
            int q = 1;
            foreach (var t in s) {
                ans += t.ToString();
                if (t.GetType() == typeof (BooleanOperand)) {
                    ans += q++;
                }
            }
            return ans;
        }

        public void domodel(List<int> a)
        {
            int q = 0;
            for (int i=0;i<s.Count;i++)
            {
                if (s[i].GetType().IsSubclassOf(typeof(BooleanOperand)) || typeof(BooleanOperand) == s[i].GetType())
                {
                    if (a[q] == 1)
                        s[i] = new BooleanOperandTrue();
                    else if (a[q] == 0)
                        s[i] = new BooleanOperandFalse();
                    else
                        s[i] = new BooleanOperand();
                    q++;
                }
            }
        }

        public void Add(IBooleanElement x) {
            s.Add(x);
        }

        public void erase() {
            if (s.Count != 0)
                s.Remove(s.Last());
        }

        public bool ifcanaddoperand() {
            if (s.Count == 0) {
                return true;
            }
            if (s.Last().GetType().IsSubclassOf(typeof (BooleanOperand)) || typeof (BooleanOperand) == s.Last().GetType()) {
                return false;
            }
            if (s.Last().GetType() == typeof (BooleanOperatorNot))
            {
                if (s[s.Count-2].GetType()!=typeof(IBooleanOperator))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ifcanaddoperator() {
            if (s.Count == 0) {
                return false;
            }
            if (s.Last() is IBooleanOperator) {
                return false;
            }
            return true;
        }

        public bool ifcanaddno() {
            if (s.Count == 0) {
                return true;
            }
            if (s.Last() is IBooleanOperator && typeof (BooleanOperatorNot) == s.Last().GetType()) {
                return false;
            }
            return true;
        }


      

        
    }
}