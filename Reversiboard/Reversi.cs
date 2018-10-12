using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversiboard
{
    public partial class Reversi : Form
    {
        //test
        public Reversi()
        {
            InitializeComponent();
            reversiboard rb = new reversiboard(pnlReversi);
            pnlReversi.Paint += rb.rbRender;
            pnlReversi.MouseClick += rb.playTurn;
        }
    }
    public class reversiboard
    {
        disk[,] diskarray;
        Panel Display;
        int totalturn;
        int currentturn;
        public reversiboard(Panel pnlDisp)
        {
            Display = pnlDisp;
            diskarray = new disk[8,8];
            startgame();
        }
        private void startgame()
        {
            for (int i = 0; i < diskarray.GetLength(0); i++)
            {
                for (int j = 0; j < diskarray.GetLength(1); j++)
                {
                    diskarray[i, j] = new disk();
                }
            }
            diskarray[diskarray.GetLength(0) / 2, diskarray.GetLength(1) / 2].state=0;
            diskarray[diskarray.GetLength(0) / 2 - 1, diskarray.GetLength(1) / 2 - 1].state = 0;
            diskarray[diskarray.GetLength(0) / 2-1, diskarray.GetLength(1) / 2].state = 1;
            diskarray[diskarray.GetLength(0) / 2, diskarray.GetLength(1) / 2 - 1].state = 1;
            totalturn = diskarray.GetLength(0) * diskarray.GetLength(1);
            currentturn = 0;
        }
        private void SetState(int x,int y,int state)
        {
            diskarray[x,y].state = state;
        }

        public void rbRender (object sender, PaintEventArgs e)
        {
            for (int i = 0; i < diskarray.GetLength(0); i++)
            {
                for (int j = 0; j < diskarray.GetLength(1); j++)
                {
                    if (diskarray[i, j].state == -2)
                    {
                        diskarray[i, j].state = -1;
                    }
                }
            }
            for (int i = 0; i < diskarray.GetLength(0); i++)
            {
                for (int j = 0; j < diskarray.GetLength(1); j++)
                {
                    if (diskarray[i, j].state == currentturn%2)
                    {
                        GameCheck(i, j, currentturn%2,true);
                    }
                }
            }
            Color diskcolor = Color.Green;
            int panelWidth = Display.Width / diskarray.GetLength(0);
            int panelHeight = Display.Height / diskarray.GetLength(1);

            for (int i = 0; i < diskarray.GetLength(0); i++){
                for(int j = 0; j < diskarray.GetLength(1); j++)
                {
                    switch (diskarray[i, j].state)
                    {
                        case -2: diskcolor = Color.Blue; break;
                        case -1: diskcolor = Color.Green; break;
                        case 0: diskcolor = Color.White; break;
                        case 1: diskcolor = Color.Black; break;
                    }
                    e.Graphics.FillRectangle(new SolidBrush(diskcolor), new Rectangle(new Point(i * panelWidth,j * panelHeight), new Size(panelWidth, panelHeight)));
                }
            }
            for (int i = 0; i < diskarray.GetLength(0); i++) { e.Graphics.DrawLine(new Pen(Brushes.Gray, 3), new Point(i * panelWidth, 0), new Point(i * panelWidth, Display.Height)); }
            for (int i = 0; i < diskarray.GetLength(1); i++) { e.Graphics.DrawLine(new Pen(Brushes.Gray, 3), new Point(0, i * panelHeight), new Point(Display.Width, i * panelHeight)); }
        }
        private void GameCheck (int X, int Y, int user,bool spec)
        {
            for(int i = -1; i < 2; i++)
            {
                if (X + i < 0 || X + i >= diskarray.GetLength(0)) { continue; }
                for (int j = -1; j <2; j++)
                {
                    if(Y + j < 0 || Y + j >= diskarray.GetLength(1)) { continue; }
                    else if (i == 0 && j == 0) { continue; }
                    else if (diskarray[X + i, Y + j].state > -1 && diskarray[X + i, Y + j].state != user)
                    {
                        extendedCheck(X, Y, user, i, j, spec);
                    }
                }
            }
        }

        private void extendedCheck(int X, int Y, int User, int dirX, int dirY,bool spec)
        {
            for(int i = 1; i < diskarray.GetLength(1) && i < diskarray.GetLength(0) ; i++)
            {
                int t = diskarray.GetLength(1);
                Debug.WriteLine( (X + i * dirX < 0).ToString() + " - " + (X + i * dirX >= diskarray.GetLength(0)).ToString() + " - " + (Y + i * dirY < 0).ToString() + " - "  + (Y + i * dirY >= diskarray.GetLength(1)).ToString());
                if ((X + i * dirX  < 0 || X + i * dirX >= diskarray.GetLength(0) || Y + i * dirY < 0 || Y + i * dirY >= diskarray.GetLength(1))) { continue; }
                if (diskarray[X + i*dirX, Y + i*dirY].state < 0) { if (spec) { diskarray[X + i * dirX, Y + i * dirY].state = -2; break; } else { break; } }
                else if (diskarray[X + i*dirX, Y + i*dirY].state == User)
                {
                    
                    if (!spec)
                    {
                        for (int j = i; j > 0; j--)
                        {
                            diskarray[X + j * dirX, Y + j * dirY].state = User;

                        }
                        break;
                    } else{
                        break;
                    }
                }

            }
        }      
        public void playTurn(object sender, MouseEventArgs mea)
        {
            Point clickpoint = new Point((int)Math.Floor((float)mea.X / (Display.Width/diskarray.GetLength(0))), (int)Math.Floor((float)mea.Y / (Display.Height/diskarray.GetLength(1))));
            if (diskarray[clickpoint.X,clickpoint.Y].state == -2)
            { 
                diskarray[clickpoint.X, clickpoint.Y].state = currentturn % 2;
                this.GameCheck(clickpoint.X,clickpoint.Y, currentturn %2,false);
                currentturn++;
                Display.Invalidate();
            }
            if (currentturn == totalturn)
            {
                int whitesum = 0;
                int blacksum = 0;
                for (int i = 0; i < diskarray.GetLength(0); i++)
                {
                    for (int j = 0; j < diskarray.GetLength(1); j++)
                    {
                        if (diskarray[i,j].state == 0)
                        {
                            whitesum++;
                        }
                        else
                        {
                            blacksum++;
                        }
                    }
                }
                if (whitesum > blacksum) {
                    MessageBox.Show("White won the game");
                }
                else if(whitesum == blacksum)
                {
                    MessageBox.Show("It's a Draw");
                }
                else
                {
                    MessageBox.Show("Black won the Game");
                }
            }
        }

        private class disk
        {
            public int state;

            // -2 Je kan hier plaatsen
            // -1 Beschikbaar
            // 0  Wit 
            // 1 Zwart
            public disk()
            {
                state = -1;
            }
        }
    }
}

