using System;
using System.Windows.Forms;

namespace Lab_1._2_Horbach_633p
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int varCount = int.Parse(textBox_count.Text.Trim());
                string objective = textBox_z.Text.Trim();

                string[] constraints = textBox_obmejenya.Text
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if (radioButton_min.Checked)
                {
                    var solver = new Optimal_min(objective, constraints, true);
                    var result = solver.Solve();

                    textBox_x.Text = result.variables;
                    textBoxZ.Text = Math.Round(result.objectiveValue, 3).ToString();
                }
                else if (radioButton_max.Checked)
                {
                    var solver = new Optimal_max(objective, constraints);
                    var result = solver.Solve();

                    textBox_x.Text = result.variables;
                    textBoxZ.Text = Math.Round(result.objectiveValue, 3).ToString();
                }
                else
                {
                    MessageBox.Show("Виберіть мінімізацію або максимізацію.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void button_protokol_Click(object sender, EventArgs e)
        {

        }
    }
}
