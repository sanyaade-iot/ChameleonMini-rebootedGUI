﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChameleonMiniGUI
{
    public partial class UcLegend : UserControl
    {
        public string Title
        {
            get { return gpLegend.Text; }
            set { gpLegend.Text = value; }
        }

        private IEnumerable<IlegendItem> _items;
        public IEnumerable<IlegendItem> Items {
            get { return _items; }
            set {
                _items = value;
                if (value != null)
                {
                    Updatelegend();
                }
            }
        }

        public bool Expanded { get; set; }


        public UcLegend()
        {
            InitializeComponent();

            Items = new List<IlegendItem>();
            this.Title = "Legend";
            this.Expanded = false;
            flpLegend.Visible = false;
        }

        private void Updatelegend()
        {
            flpLegend.Controls.Clear();

            foreach (var item in Items)
            {
                var o = new Label
                {
                    BackColor = Color.FromName(item.BackGroundColor),
                    ForeColor = Color.FromName(item.ForeGroundColor),
                    Text = item.Description,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = new Padding(0,1,1,0)
                };
                flpLegend.Controls.Add(o);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Expanded)
            {
                flpLegend.Visible = false;
                btnToggle.Text = "+";
            }
            else
            {
                flpLegend.Visible = true;
                btnToggle.Text = "-";
            }
            Expanded = !Expanded;
        }
    }
}
