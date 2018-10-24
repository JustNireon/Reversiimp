using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Reversiboard
{
    public partial class Reversi : Form
    {
        readonly Reversiboard rb;
        public Reversi()
        {
            InitializeComponent();
            
            rb = new Reversiboard(pnlReversi);
            pnlReversi.Paint += rb.RbRender;
            pnlReversi.MouseClick += PlayTurn;
            SizeChanged += ResizeRender;
            btnPas.Click += PassTurn;
            btnNew.Click += NewGame;
            btnHelp.Click += rb.Support_click;
            this.ResizeRender(null,null);
            
            
        }

        public void PlayTurn (object sender, MouseEventArgs mea)
        {
            rb.PlayTurn(mea.X, mea.Y);
            lblStatus.Text = rb.Currentturn % 2 == 0 ? "Wit is aan zet" : "Zwart is aan zet";
            rb.Diskcounter();
            lblWit.Text = $"Wit heeft {rb.Whitetotal} Disk(s)";
            lblZwart.Text = $"Zwart heeft {rb.Blacktotal} Disk(s)";

        } 
        public void PassTurn(object sender, EventArgs e)
        {
            rb.PassTurn();
            lblStatus.Text = rb.Currentturn % 2 == 0 ? "Wit is aan zet" : "Zwart is aan zet";
        }
        public void NewGame(object sender, EventArgs e)
        {
            rb.Startgame();
        }
        public void ResizeRender(object sender, EventArgs e)
        {
            int width = panelcell.Width;
            int height = panelcell.Height;
            if (width == height)
            {
                return;
            }

            float scalesizeW =  (float) rb.DiskSize[0]/rb.DiskSize[1];
            float scalesizeH = (float) rb.DiskSize[1] / rb.DiskSize[0];
            scalesizeH =  scalesizeH > scalesizeW? scalesizeH : 1;
            scalesizeW = scalesizeH < scalesizeW ? scalesizeW : 1;
            
            pnlReversi.Location = new Point((int)(width * .1), (int)(height * .1));
            if (width > height)
            {
                pnlReversi.Height = (int) (height * scalesizeH * 0.8 );
                pnlReversi.Width = (int) (height* scalesizeW * 0.8 );
            }
            else
            {
                pnlReversi.Height = (int) (width * scalesizeH  * 0.8 );
                pnlReversi.Width = (int) (width * scalesizeW * 0.8);
            }
            Debug.WriteLine(pnlReversi.Size);
            pnlReversi.Location = new Point((int)(panelcell.Width/2 - pnlReversi.Width/2),(int)(panelcell.Height/2 - pnlReversi.Height/2));
            pnlReversi.Invalidate();
        }
        public class Reversiboard
        {
            private Disk[,] _diskarray;

            public int[] DiskSize => (new int[2] {_diskarray.GetLength(0), _diskarray.GetLength(1)});
            private PictureBox _display;

            public int Totalturn;
            public int Currentturn;
            public bool Support;
            public int Whitetotal, Blacktotal, Passcounter;

            public Reversiboard(PictureBox pnlDisp)
            {
                _display = pnlDisp;
                _diskarray = new Disk[12, 8];
                Support = false;
                Startgame();

            }

            public void Startgame(int X = 8, int Y =6 )
            {
                _diskarray = new Disk[X, Y];
                for (int i = 0; i < _diskarray.GetLength(0); i++)
                {
                    for (int j = 0; j < _diskarray.GetLength(1); j++)
                    {
                        _diskarray[i, j] = new Disk();
                    }
                }
                _diskarray[_diskarray.GetLength(0) / 2, _diskarray.GetLength(1) / 2].State = 0;
                _diskarray[_diskarray.GetLength(0) / 2 - 1, _diskarray.GetLength(1) / 2 - 1].State = 0;
                _diskarray[_diskarray.GetLength(0) / 2 - 1, _diskarray.GetLength(1) / 2].State = 1;
                _diskarray[_diskarray.GetLength(0) / 2, _diskarray.GetLength(1) / 2 - 1].State = 1;
                Totalturn = _diskarray.GetLength(0) * _diskarray.GetLength(1) - 4;
                Currentturn = 0;
                _display.Invalidate();
            }
            public void RbRender(object sender, PaintEventArgs e)
            {
                Whitetotal = 0;
                Blacktotal = 0;
                for (int i = 0; i < _diskarray.GetLength(0); i++)
                {
                    for (int j = 0; j < _diskarray.GetLength(1); j++)
                    {
                        if (_diskarray[i,j].State == 0) { Whitetotal++; }
                        if (_diskarray[i, j].State == 1) { Blacktotal++; }
                        if (_diskarray[i, j].State == -2)
                        {
                            _diskarray[i, j].State = -1;
                        }
                    }
                }
                for (int i = 0; i < _diskarray.GetLength(0); i++)
                {
                    for (int j = 0; j < _diskarray.GetLength(1); j++)
                    {
                        if (_diskarray[i, j].State == Currentturn % 2)
                        {
                            GameCheck(i, j, Currentturn % 2, true);
                        }
                    }
                }
                int panelWidth = _display.Width / _diskarray.GetLength(0);
                int panelHeight = _display.Height / _diskarray.GetLength(1);

                for (int i = 0; i < _diskarray.GetLength(0); i++)
                {
                    for (int j = 0; j < _diskarray.GetLength(1); j++)
                    {
                        var diskcolor = _diskarray[i, j].DiskColor;
                        if (_diskarray[i, j].State > -1 || (Support))
                        {
                            e.Graphics.FillEllipse(new SolidBrush(diskcolor[0]), new Rectangle(new Point(i * panelWidth+3, j * panelHeight+3), new Size(panelWidth-6, panelHeight-6)));
                            if (_diskarray[i, j].State > -1)
                            {
                                e.Graphics.FillEllipse(new SolidBrush(diskcolor[1]), new Rectangle(new Point(i * panelWidth + 12, j * panelHeight + 12), new Size(panelWidth - 24, panelHeight - 24)));
                            }
                        }
                    }
                }
                for (int i = 0; i <= _diskarray.GetLength(0); i++) { e.Graphics.DrawLine(new Pen(Brushes.DarkGreen, 3), new Point(i * panelWidth, 0), new Point(i * panelWidth, panelHeight * _diskarray.GetLength(1))); }
                for (int i = 0; i <= _diskarray.GetLength(1); i++) { e.Graphics.DrawLine(new Pen(Brushes.DarkGreen, 3), new Point(0, i * panelHeight), new Point(panelWidth * _diskarray.GetLength(0), i * panelHeight)); }
            }
            private void GameCheck(int x, int y, int user, bool spec)
            {
                for (int i = -1; i < 2; i++)
                {
                    if (x + i < 0 || x + i >= _diskarray.GetLength(0)) { continue; }
                    for (int j = -1; j < 2; j++)
                    {
                        if (y + j < 0 || y + j >= _diskarray.GetLength(1)) { continue; }
                        else if (i == 0 && j == 0) { continue; }
                        else if (_diskarray[x + i, y + j].State > -1 && _diskarray[x + i, y + j].State != user)
                        {
                            ExtendedCheck(x, y, user, i, j, spec);
                        }
                    }
                }

            }

            private void ExtendedCheck(int x, int y, int user, int dirX, int dirY, bool spec)
            {
                for (int i = 1; i < _diskarray.GetLength(1) && i < _diskarray.GetLength(0); i++)
                {
                    if ((x + i * dirX < 0 || x + i * dirX >= _diskarray.GetLength(0) || y + i * dirY < 0 || y + i * dirY >= _diskarray.GetLength(1))) { continue; }
                    if (_diskarray[x + i * dirX, y + i * dirY].State < 0) { if (spec) { _diskarray[x + i * dirX, y + i * dirY].State = -2; break; } else { break; } }
                    else if (_diskarray[x + i * dirX, y + i * dirY].State == user)
                    {

                        if (!spec)
                        {
                            for (int j = i; j > 0; j--)
                            {
                                _diskarray[x + j * dirX, y + j * dirY].State = user;

                            }
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }

                }
            }
            public void PlayTurn(int x,int y)
            {
                
                Point clickpoint = new Point((int)Math.Floor((float)x / (_display.Width / _diskarray.GetLength(0))), (int)Math.Floor((float)y / (_display.Height / _diskarray.GetLength(1))));
                if (clickpoint.X == _diskarray.GetLength(0)) { clickpoint.X -= 1; }

                if (clickpoint.Y == _diskarray.GetLength(1)) { clickpoint.Y -= 1; }

                if (_diskarray[clickpoint.X, clickpoint.Y].State == -2)
                {
                    Passcounter = 0;
                    _diskarray[clickpoint.X, clickpoint.Y].State = Currentturn % 2;
                    GameCheck(clickpoint.X, clickpoint.Y, Currentturn % 2, false);
                    Currentturn++;
                    EndCheck();
                    _display.Invalidate();
                }

            }
            public void EndCheck()
            {
                if (Passcounter == 2|| Currentturn == Totalturn)
                {
                    Diskcounter();
                    if (Whitetotal > Blacktotal) { MessageBox.Show("Wit heeft gewonnen", "Gefeliciteerd!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if(Whitetotal == Blacktotal) { MessageBox.Show("Het is een Remise", "Volgende keer beter", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else { MessageBox.Show("Zwart heeft gewonnen", "Gefeliciteerd!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
            public void Diskcounter()
            {
                Whitetotal = 0;
                Blacktotal = 0;
                for (int i = 0; i < _diskarray.GetLength(0); i++)
                {
                    for (int j = 0; j < _diskarray.GetLength(1); j++)
                    {
                        if (_diskarray[i, j].State == 0) { Whitetotal++; }
                        if (_diskarray[i, j].State == 1) { Blacktotal++; }
                    }
                }
            }
            public void PassTurn()
            {
                Passcounter++;
                Currentturn++;
                _display.Invalidate();
                EndCheck();
            }
            public void Support_click(object sender, EventArgs e)
            {
                Support = !Support;
                _display.Invalidate();
            }

            private class Disk
            {
                public int State;

                public Color[] DiskColor
                {
                    get
                    {
                        Color [] ColorSet = new Color[2];
                        switch (State)
                        {
                            
                            case -2: ColorSet[0] = Color.Yellow;
                                return ColorSet;//Color.Yellow;
                            case 0:
                                ColorSet[0] = Color.FromArgb(237, 237, 233);
                                ColorSet[1] = Color.FromArgb(217, 217, 208);
                                return ColorSet;
                            case 1:
                                ColorSet[0] = Color.FromArgb(57, 59, 78);
                                ColorSet[1] = Color.FromArgb(48, 49, 61);
                                return ColorSet;
                            default: 
                                ColorSet[0] = Color.Green;
                                return ColorSet;
                        }
                    }
                }

                // -2 Je kan hier plaatsen
                // -1 Beschikbaar
                // 0  Wit 
                // 1 Zwart
                public Disk()
                {
                    State = -1;
                }
            }
        }

        private void pnlReversi_Click(object sender, EventArgs e)
        {

        }

        private void instellenGrootteBordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
