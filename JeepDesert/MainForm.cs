using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JeepDesert
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double N, M, V;

            listBox.Items.Clear();

            if (double.TryParse(textBoxN.Text, out N) &&
                double.TryParse(textBoxM.Text, out M) &&
                double.TryParse(textBoxV.Text, out V))
            {
                if (N > M && M > V)
                {
                    LockUI();

                    var model = new Model(M + 2 * V, N);

                    foreach (var message in model.GetMoves())
                    {
                        listBox.Items.Add(message);
                        listBox.SelectedIndex = listBox.Items.Count - 1;
                    }

                    UnlockUI();
                }
                else MessageBox.Show("N долно быть больше M и M должно быть больше V.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Не удалось считать числа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LockUI()
        {
            textBoxN.Enabled = false;
            textBoxM.Enabled = false;
            textBoxV.Enabled = false;
            button1.Enabled = false;
        }

        private void UnlockUI()
        {
            textBoxN.Enabled = true;
            textBoxM.Enabled = true;
            textBoxV.Enabled = true;
            button1.Enabled = true;
        }
    }
}