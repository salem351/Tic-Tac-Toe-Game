using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO_Mine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;
        enplayer PlayerTurn = enplayer.player1;

        enum enplayer
        {
            player1,
            player2
        }
        enum enWinner
        {
            player1,
            player2,
            Draw,
            GameInProgress
        }
        struct stGameStatus
        {
            public enWinner Winer;
            public bool GameOver;
            public short PlayCount;
        }

        private void FormPaint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255, 255);
            Pen whitePen = new Pen(white);
            whitePen.Width = 15;
            //whitePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //draw Horizental lines
            e.Graphics.DrawLine(whitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(whitePen, 400, 460, 1050, 460);

            //draw Vertical lines
            e.Graphics.DrawLine(whitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(whitePen, 840, 140, 840, 620);

        }

        public void EndGame()
        {
            labTurn.Text = "Game Over";

            switch (GameStatus.Winer)
            {
                case enWinner.player1:

                    labWinner.Text = "Player 1";
                    break;


                case enWinner.player2:

                    labWinner.Text = "Player 2";
                    break;

                default:

                    labWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public bool CkeckValues(Button btn1, Button btn2, Button btn3)
        {
            if(btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn2.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.YellowGreen;
                btn2.BackColor = Color.YellowGreen;
                btn3.BackColor = Color.YellowGreen;

                if(btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winer = enWinner.player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winer = enWinner.player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }

        public void checkWinner()
        {
            //Check Row
            if(CkeckValues(button1, button2, button3))
              return;
            if (CkeckValues(button4, button5, button6))
                return;
            if (CkeckValues(button7, button8, button9))
                return;

            //Check Colums
            if (CkeckValues(button1, button4, button7))
                return;
            if (CkeckValues(button2, button5, button8))
                return;
            if (CkeckValues(button3, button6, button9))
                return;

            //Check Diagonals
            if (CkeckValues(button1, button5, button9))
                return;
            if (CkeckValues(button3, button5, button7))
                return;

        }

        public void ChangeImage(Button btn)
        {
            if(btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enplayer.player1:
                        btn.Image = Properties.Resources.X;
                        PlayerTurn = enplayer.player2;
                        labTurn.Text = "Player1";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        checkWinner();
                        break;

                    case enplayer.player2:
                        btn.Image = Properties.Resources.O;
                        PlayerTurn = enplayer.player1;
                        labTurn.Text = "Player2";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";      
                        checkWinner();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if(GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winer = enWinner.Draw;
                EndGame();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);
        }


        public void ButtonReStart(Button btn)
        {
            btn.Image = Properties.Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;


        }
        private void btnRest_Click(object sender, EventArgs e)
        {
            ButtonReStart(button1);
            ButtonReStart(button2);
            ButtonReStart(button3);
            ButtonReStart(button4);
            ButtonReStart(button5);
            ButtonReStart(button6);
            ButtonReStart(button7);
            ButtonReStart(button8);
            ButtonReStart(button9);

            PlayerTurn = enplayer.player1;
            labTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.Winer = enWinner.GameInProgress;
            GameStatus.GameOver = false;
            labWinner.Text = "In Progress";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/salemameen/");

        }
    }
}
