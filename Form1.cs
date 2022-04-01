using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace PokeDexWithJSON
{
    public partial class Form1 : Form
    {
        private ArrayList Pokes = new ArrayList();
        int current;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inFile = File.OpenText("Pokemon.JSON");

            while (inFile.Peek() != -1)
            {
                string pString = inFile.ReadLine();
                Pokemon p = JsonSerializer.Deserialize<Pokemon>(pString);
                Pokes.Add(p);
            }
            inFile.Close();
            show();
        }

        public void show()
        {
            Pokemon p = (Pokemon)Pokes[current];
            nameTextBox.Text = p.name;
            categoryTextBox.Text = p.category;
            heightTextBox.Text = p.height;
            weightTextBox.Text = p.weight;
            moveTextBox.Text = p.move;
            weaknessesTextBox.Text = p.weaknesses;
            genderTextBox.Text = p.gender;
            hpTextBox.Text = p.hp;
            descTextBox.Text = p.desc;

            if (File.Exists(p.picture))
            { pokemonPictureBox.Load(p.picture); }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            save();
        }

        public void save()
        {
            var p = new Pokemon
            {
                name = nameTextBox.Text,
                category = categoryTextBox.Text,
                height = heightTextBox.Text,
                weight = weightTextBox.Text,
                move = moveTextBox.Text,
                weaknesses = weaknessesTextBox.Text,
                gender = genderTextBox.Text,
                hp = hpTextBox.Text,
                desc = descTextBox.Text,
                picture = pokemonPictureBox.ImageLocation
            };

            Pokes.Add(p);

            StreamWriter outFile = File.CreateText("Pokemon.JSON");
            foreach (var item in Pokes)
            {
                outFile.WriteLine(JsonSerializer.Serialize(item));
            }

            outFile.Close();
        }

        public void clear()
        {
            nameTextBox.Clear();
            categoryTextBox.Clear();
            heightTextBox.Clear();
            weightTextBox.Clear();
            moveTextBox.Clear();
            weaknessesTextBox.Clear();
            genderTextBox.Clear();
            hpTextBox.Clear();
            descTextBox.Clear();
            pokemonPictureBox.Image = null;
        }

        private void pokemonPictureBox_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            if (File.Exists(openFileDialog1.FileName))
            {
                pokemonPictureBox.Load(openFileDialog1.FileName);
            }
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            current = 0;
            show();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (current == 0)
            {
                current = Pokes.Count - 1;
            }
            else if (current > 0)
            {
                current--;
            }
            show();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (Pokes.Count == current + 1)
            {
                current = 0;
            }
            else if (current < Pokes.Count)
            {
                current++;
            }
            show();
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            current = Pokes.Count - 1;
            show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            save();
            clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Pokes.Remove(Pokes[current]);
            show();
            save();
        }
    }
}
