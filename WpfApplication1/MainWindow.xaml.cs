using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        string falsevich = "False",
                trushka = "True",
                error = "Error";

        private Model m = new Model();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Doexpression()
        {
            stq.Text = m.ModeltoString();
            ManyTextboxes.Children.Clear();
            for (int i = 1; i <= m.Numberofoperands; ++i)
            {
                TextBlock box = new TextBlock();
                box.Text = "x" + i.ToString();
                box.MaxWidth = 20;
                box.Height = 22.5;
                ManyTextboxes.Children.Add(box);
            }
            ManyXprops.Children.Clear();
            List<int> sor = m.getinfo();
            for (int i = 1; i <= m.Numberofoperands; ++i)
            {
                ComboBox box = new ComboBox();
                box.Items.Add(falsevich);
                box.Items.Add(trushka);
                box.MaxWidth = 60;
                if (sor[i - 1] == 1)
                {
                    box.SelectedItem = trushka;
                }
                else
                {
                    if (sor[i - 1] == 0)
                    {
                        box.SelectedItem = falsevich;
                    }
                }
                box.SelectionChanged += new SelectionChangedEventHandler(SomethingChanged);

                ManyXprops.Children.Add(box);
            }
        }

        private void add_x_Click(object sender, RoutedEventArgs e)
        {
            if (m.Numberofoperands <= 20)
                if (m.ifcanaddoperand())
                {
                    m.Add(new BooleanOperand());
                    Doexpression();
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (m == null)
                return;
            string a = operator1.Text;
            if (a == "")
            {
                return;
            }
            if (a == "Add no")
            {
                if (m.ifcanaddno())
                {
                    m.Add(new BooleanOperatorNot());
                }
            }
            else
            {
                if (m.ifcanaddoperator())
                {
                    if (a == "Add or")
                    {
                        m.Add(new BooleanOperatorOr());
                    }
                    if (a == "Add and")
                    {
                        m.Add(new BooleanOperatorAnd());
                    }
                    if (a == "Add xor")
                    {
                        m.Add(new BooleanOperatorXor());
                    }
                }
            }
            Doexpression();
        }

        private void rev_Click(object sender, RoutedEventArgs e)
        {
            m.erase();
            Doexpression();
        }

        private void doans_Click(object sender, RoutedEventArgs e)
        {
            int a = m.eval();
            switch (a) {
                case 2: result.Text = error; break;
                case 1: result.Text = trushka; break;
                case 0: result.Text = falsevich; break;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                Adapter.WriteModel(m, saveFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                m = Adapter.ReadModel(openFileDialog.FileName);
            }
            Doexpression();
        }

        private void SomethingChanged(object sender, SelectionChangedEventArgs e)
        {
            List<int> sor=new List<int>();
            for (int i = 0; i < ManyXprops.Children.Count; i++)
            {
                ComboBox cb = (ComboBox)ManyXprops.Children[i];
                string str = (string)cb.SelectedItem;
                if (str == trushka)
                {
                    sor.Add(1) ;
                }
                else if (str == falsevich)
                {
                    sor.Add(0);
                }
                else
                {
                    sor.Add(2);
                }
            }
            m.domodel(sor);
            Doexpression();
        }


    }
}
