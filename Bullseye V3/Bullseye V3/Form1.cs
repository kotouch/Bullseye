﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bullseye_V3
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static void UpdateBoxOne(string message)
        {
            
            Form1 frm1 = new Form1();
            frm1.textBox1.Text = message.ToString();

        }

        public static void UpdateBoxTwo(string message)
        {
            Form1 frm1 = new Form1();
            frm1.textBox2.Text = message.ToString();
        }
    }
}
