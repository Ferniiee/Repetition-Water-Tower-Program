using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS111_Lab_10_Repetition_Water_Tower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //global (i.e., modular) variables
        int xOrigin = 75;
        int yOrigin = 614;
        int h1x;
        int h1y;
        int h2x;
        int h2y;
        int h3x;
        int h3y;
        int minTowerX;
        int minTowerY;
        int delta = 40; //the distance from one grid line to the next

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //set combo boxes to blank
            cmbH1X.SelectedIndex = 0;
            cmbH1Y.SelectedIndex = 0;
            cmbH2X.SelectedIndex = 0;
            cmbH2Y.SelectedIndex = 0;
            cmbH3X.SelectedIndex = 0;
            cmbH3Y.SelectedIndex = 0;

            //make house and tower labels not visible
            lblH1.Visible = false;
            lblH2.Visible = false;
            lblH3.Visible = false;
            lblTower.Visible = false;

            //diable "Show Tower" button
            btnShowTower.Enabled = false;
        }

        private void btnShowHouses_Click(object sender, EventArgs e)
        {
            //assign combo box values to variables
            h1x = Convert.ToInt32(cmbH1X.Text);
            h1y = Convert.ToInt32(cmbH1Y.Text);
            h2x = Convert.ToInt32(cmbH2X.Text);
            h2y = Convert.ToInt32(cmbH2Y.Text);
            h3x = Convert.ToInt32(cmbH3X.Text);
            h3y = Convert.ToInt32(cmbH3Y.Text);

            //position each label based on the user entry 

            lblH1.Left = xOrigin + h1x * delta;
            lblH1.Top = yOrigin - h1y * delta;
            lblH2.Left = xOrigin + h2x * delta;
            lblH2.Top = yOrigin - h2y * delta;
            lblH3.Left = xOrigin + h3x * delta;
            lblH3.Top = yOrigin - h3y * delta;

            //reveal house marker labels (i.e., make them visible)
            lblH1.Visible = true;
            lblH2.Visible = true;
            lblH3.Visible = true;

            //enable tower button
            btnShowTower.Enabled = true;
        }

        private void btnShowTower_Click(object sender, EventArgs e)
        {
            //declaration
            const int MAX_XAXIS = 15;
            const int MAX_YAXIS = 15;
            int tx;
            int ty;
            double totalDistance;
            double minDistance = 100000;

            //calculate the centroid of the triangle formed by the 3 houses
            for (tx = 0; tx <= MAX_XAXIS; tx++)
            {
                for (ty = 0; ty <= MAX_YAXIS; ty++)
                {
                    totalDistance = 
                        Math.Sqrt(Math.Pow(h1x - tx,2.0) + Math.Pow(h1y - ty,2.0))
                    + Math.Sqrt(Math.Pow(h2x - tx, 2.0) + Math.Pow(h2y - ty, 2.0))
                    + Math.Sqrt(Math.Pow(h3x - tx, 2.0) + Math.Pow(h3y - ty, 2.0));

                    if (totalDistance < minDistance)
                    {
                        minDistance = totalDistance;
                        minTowerX = tx;
                        minTowerY = ty;
                    }
                }
            }

            //make the tower visible and assign its position on the grid
            lblTower.Visible = true;
            lblTower.Top = yOrigin - minTowerY * delta;
            lblTower.Left = xOrigin + minTowerX * delta;
        }
    }
}
