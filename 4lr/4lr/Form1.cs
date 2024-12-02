using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4lr
{
    public partial class Form1 : Form
    {
        private ComboBox comboBox;
        private CheckBox checkBox;
        private TextBox textBox;
        private Label resultLabel;
        private Label lengthLabel;

        public Form1()
        {
            InitializeComponent();

            // Настройка элементов управления
            comboBox = new ComboBox() { Location = new System.Drawing.Point(20, 60) };
            comboBox.Items.AddRange(new object[] { "США", "Россия", "Люксембург", "Великобритания", "Чехия" });
            comboBox.Enabled = false;
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            checkBox = new CheckBox() { Text = "Разрешено", Location = new System.Drawing.Point(20, 20) };
            checkBox.CheckedChanged += CheckBox_CheckedChanged;

            textBox = new TextBox() { Location = new System.Drawing.Point(20, 100), Width = 200 };
            textBox.Enabled = false;
            textBox.KeyUp += TextBox_KeyUp;

            resultLabel = new Label() { Location = new System.Drawing.Point(20, 140), Width = 200 };

            lengthLabel = new Label() { Location = new System.Drawing.Point(230, 140), Width = 130 };

            // Добавление элементов управления на форму
            Controls.Add(comboBox);
            Controls.Add(checkBox);
            Controls.Add(textBox);
            Controls.Add(resultLabel);
            Controls.Add(lengthLabel);

            // Настройка формы
            this.Text = "ComboBox, CheckBox и TextBox";
            this.Size = new System.Drawing.Size(400, 250);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked && comboBox.SelectedItem != null)
            {
                // Заполняем текстовое поле выбранным значением из комбобокса
                textBox.Text = comboBox.SelectedItem.ToString();
                textBox.Enabled = true; // Включаем текстовое поле
                EvaluateTextLength();
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Включаем или отключаем комбобокс в зависимости от состояния чекбокса
            comboBox.Enabled = checkBox.Checked;

            if (!checkBox.Checked)
            {
                // Очищаем текстовое поле и результат, если чекбокс не отмечен
                textBox.Clear();
                textBox.Enabled = false; // Отключаем текстовое поле
                resultLabel.Text = "";
                lengthLabel.Text = "";
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            EvaluateTextLength();
        }

        private void EvaluateTextLength()
        {
            string text = textBox.Text;
            lengthLabel.Text = $"Длина строки: {text.Length}";

            if (string.IsNullOrEmpty(text))
            {
                resultLabel.Text = "";
                lengthLabel.Text = "";
                return;
            }
            if (text.Length <= 5)
            {
                resultLabel.Text = "Короткая строка";
                resultLabel.BackColor = Color.LightGreen;
                lengthLabel.BackColor = Color.LightGreen;
                lengthLabel.Text = $"Длина строки: {text.Length}";
            }
            else if (text.Length <= 10)
            {
                resultLabel.Text = "Нормальная строка";
                resultLabel.BackColor = Color.LightYellow;
                lengthLabel.BackColor = Color.LightYellow;
                lengthLabel.Text = $"Длина строки: {text.Length}";
            }
            else
            {
                resultLabel.Text = "Длинная строка";
                resultLabel.BackColor = Color.LightCoral;
                lengthLabel.BackColor = Color.LightCoral;
                lengthLabel.Text = $"Длина строки: {text.Length}";
            }
        }
    }
}

