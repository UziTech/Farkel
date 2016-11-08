using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farkel
{
    public partial class Farkel : Form
    {
        #region Global Variables
        int[] _diceArray = new int[6];//[D1 #,...,D6 #]
        int[] _selectedArray = new int[6];//[# of 1's selected,...,# of 6's selected]
        int _diceSelected, _roundScore, _rollScore, _count, _playerOver10000, _highestScore;
        int[] _s = new int[6];
        bool _rolled, _tooLow, _compPlayer;
        Random _rand = new Random((int)DateTime.Now.Ticks);
        Image[] _dPics = new Image[6];
        Font playerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        Font nonPlayerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        #endregion
        public Farkel()
        {
            InitializeComponent();
            _dPics[0] = Properties.Resources._1die;
            _dPics[1] = Properties.Resources._2die;
            _dPics[2] = Properties.Resources._3die;
            _dPics[3] = Properties.Resources._4die;
            _dPics[4] = Properties.Resources._5die;
            _dPics[5] = Properties.Resources._6die;
            Reset(Properties.Settings.Default.players);
        }
        private void L_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (L[i] == sender)
                {
                    CheckChangeName();
                    //L[i].Visible = false;
                    TB[i].Text = L[i].Text;
                    if (i == Player())
                        TB[i].Font = playerFont;
                    else
                        TB[i].Font = nonPlayerFont;
                    TB[i].Visible = true;
                    TB[i].BringToFront();
                    TB[i].Focus();
                    break;
                }
            }
        }
        private void H_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (H[i] == sender)
                {
                    CheckChangeName();
                    if (H[i].Text == "H")
                    {
                        H[i].Text = "C";
                        if (Player() == i)
                        {
                            _compPlayer = true;
                            compWait.Enabled = true;
                        }
                        switch (i)
                        {
                            case 0:
                                Properties.Settings.Default.Comp1 = true;
                                break;
                            case 1:
                                Properties.Settings.Default.Comp2 = true;
                                break;
                            case 2:
                                Properties.Settings.Default.Comp3 = true;
                                break;
                            case 3:
                                Properties.Settings.Default.Comp4 = true;
                                break;
                            case 4:
                                Properties.Settings.Default.Comp5 = true;
                                break;
                            case 5:
                                Properties.Settings.Default.Comp6 = true;
                                break;
                            default:
                                MessageBox.Show("Error");
                                break;
                        }
                    }
                    else
                    {
                        H[i].Text = "H";
                        if (Player() == i)
                        {
                            _compPlayer = false;
                            compWait.Enabled = false;
                        } 
                        switch (i)
                        {
                            case 0:
                                Properties.Settings.Default.Comp1 = false;
                                break;
                            case 1:
                                Properties.Settings.Default.Comp2 = false;
                                break;
                            case 2:
                                Properties.Settings.Default.Comp3 = false;
                                break;
                            case 3:
                                Properties.Settings.Default.Comp4 = false;
                                break;
                            case 4:
                                Properties.Settings.Default.Comp5 = false;
                                break;
                            case 5:
                                Properties.Settings.Default.Comp6 = false;
                                break;
                            default:
                                MessageBox.Show("Error");
                                break;
                        }
                    }
                    break;
                }
            }
            Properties.Settings.Default.Save();
        }
        private void D_Click(object sender, EventArgs e)
        {
            CheckChangeName();
            if (!_compPlayer)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (D[i] == sender)
                    {
                        if ((string)D[i].BackgroundImage.Tag != "Blue" && _rolled)
                        {
                            if ((string)D[i].BackgroundImage.Tag == "White")
                            {
                                _selectedArray[_diceArray[i] - 1]++;
                                D[i].BackgroundImage = Properties.Resources.Gdie;
                                D[i].BackgroundImage.Tag = "Green";
                                _diceSelected++;
                                ScoreSelected(false, false);
                            }
                            else if ((string)D[i].BackgroundImage.Tag == "Green")
                            {
                                _selectedArray[_diceArray[i] - 1]--;
                                D[i].BackgroundImage = Properties.Resources.Wdie;
                                D[i].BackgroundImage.Tag = "White";
                                _diceSelected--;
                                ScoreSelected(false, false);
                            }
                        }
                        break;
                    }
                }
            }
        }
        private void Roll_Click(object sender, EventArgs e)
        {
            if (sender == Roll && CheckChangeName())
                return;
            if (!_compPlayer || sender != Roll)
            {
                Roll.Text = "Roll!";
                if ((_rolled && _diceSelected != 0) || !_rolled || _tooLow)
                {
                    if (_rolled && (_diceSelected != 0 || _tooLow))
                    {
                        ScoreSelected(true, true);
                        if (_rollScore == 0 && !_tooLow)
                            return;
                        _roundScore += _rollScore;
                        _rollScore = 0;
                        RoundScore.Text = "Round Score: " + _roundScore;
                        RollScore.Text = "Roll Score: " + _rollScore;
                    }
                    else
                    {
                        if (!HighStakes.Checked)
                        {
                            _roundScore = 0;
                            RoundScore.Text = "Round Score: " + _roundScore;
                            for (int i = 0; i < 6; i++)
                            {
                                D[i].BackgroundImage = Properties.Resources.Wdie;
                                D[i].BackgroundImage.Tag = "White";
                            }
                        }
                        else
                        {
                            HighStakes.Checked = false;
                        }
                        _rolled = true;
                        HighStakes.Visible = false;
                    }
                    _diceSelected = 0;
                    bool blue = true;
                    for (int i = 0; i < 6; i++)
                    {
                        if ((string)D[i].BackgroundImage.Tag != "Blue")
                        {
                            blue = false;
                            break;
                        }
                    }
                    if (blue)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            D[i].BackgroundImage = Properties.Resources.Wdie;
                            D[i].BackgroundImage.Tag = "White";
                        }
                    }
                    diceRoll.Enabled = true;
                }
            }
        }
        private void Done_Click(object sender, EventArgs e)
        {
            if (sender == Done && CheckChangeName())
                return;
            if ((!_compPlayer || sender != Done) && !diceRoll.Enabled)
            {
                if (_rolled)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if ((string)D[i].BackgroundImage.Tag == "White")
                        {
                            D[i].BackgroundImage = Properties.Resources.Gdie;
                            D[i].BackgroundImage.Tag = "Green";
                            _selectedArray[_diceArray[i] - 1]++;
                        }
                    }
                    ScoreSelected(false, true);
                    for (int i = 0; i < 6; i++)
                    {
                        if ((string)D[i].BackgroundImage.Tag == "Green")
                            _selectedArray[_diceArray[i] - 1]++;
                    }
                    if (AllScored() && MessageBox.Show("All six dice scored.\nYou may roll all six dice again!\n\nAre you sure you want to end your turn?", "End Turn?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                    if (_diceSelected == 0 && !_tooLow)
                        return;
                    int player = Player();
                    if (_roundScore + _rollScore < 500 && _s[player] == 0)
                    {
                        MessageBox.Show("You must score over 500 in order to get on the board!", "Score Too Low");
                        _tooLow = true;
                        return;
                    }
                    if (_roundScore + _rollScore + _s[player] < _highestScore && MessageBox.Show("Your score is not higher than the highest score.\n\nAre you sure you want to end your turn?", "Keep Going!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        _tooLow = true;
                        return;
                    }
                    ScoreSelected(true, true);
                    _roundScore += _rollScore;
                    _rollScore = 0;
                    RoundScore.Text = "Round Score: " + _roundScore;
                    RollScore.Text = "Roll Score: " + _rollScore;

                    if (L[player].ForeColor == Color.Green)
                    {
                        _s[player] += _roundScore;
                        S[player].Text = _s[player].ToString();
                        if (_s[player] >= 10000 && _playerOver10000 == 0)
                        {
                            _playerOver10000 = player + 1;
                            MessageBox.Show(L[player].Text + " is over 10,000 points\n\nEvery other player gets one more turn");
                            _highestScore = _s[player];
                        }
                        else if (_playerOver10000 != 0 && _s[player] > _highestScore)
                        {
                            _highestScore = _s[player];
                        }
                    }
                    _rolled = false;
                    _compPlayer = false;
                    HighStakes.Visible = true;
                    NextPlayer();
                }
            }
        }
        private void Farkel_Click(object sender, EventArgs e)
        {
            CheckChangeName();
        }
        private void NGplayers_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                if (NGplayers[i] == sender)
                {
                    Properties.Settings.Default.players = i + 2;
                    Properties.Settings.Default.Save();
                    diceRoll.Enabled = false;
                    compWait.Enabled = false;
                    Reset(i + 2);
                    break;
                }
            }
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckChangeName();
            Help H = new Help();
            H.ShowDialog();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckChangeName();
            AboutBox a = new AboutBox();
            a.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void diceRoll_Tick(object sender, EventArgs e)
        {
            int speed = 5, t = speed;
            int[] ts = new int[6];
            for (int i = 0; i < 6; i++)
            {
                if ((string)D[i].BackgroundImage.Tag == "White")
                {
                    t += speed;
                    ts[i] = t;
                }
            }
            _count++;
            for (int i = 0; i < 6; i++)
            {
                if ((string)D[i].BackgroundImage.Tag == "White" && _count < ts[i])
                {
                    int temp;
                    do
                    {
                        temp = _rand.Next(1, 7);
                    } while (temp == _diceArray[i]);
                    _diceArray[i] = temp;
                    D[i].Image = _dPics[_diceArray[i] - 1];
                }
            }

            if (_count >= t)
            {
                _count = 0;
                diceRoll.Enabled = false;
                for (int i = 0; i < 6; i++)
                {
                    if ((string)D[i].BackgroundImage.Tag != "Blue")
                    {
                        D[i].BackgroundImage = Properties.Resources.Gdie;
                        D[i].BackgroundImage.Tag = "Green";
                        _selectedArray[_diceArray[i] - 1]++;
                    }
                }
                ScoreSelected(false, true);
                for (int i = 0; i < 6; i++)
                {
                    if ((string)D[i].BackgroundImage.Tag == "Green")
                        _selectedArray[_diceArray[i] - 1]++;
                }
                if (_rollScore == 0)
                {
                    _roundScore = 0;
                    RoundScore.Text = "Round Score: " + _roundScore.ToString();
                    _compPlayer = false;
                    _rolled = false;
                    Roll.Text = "Farkel";
                    NextPlayer();
                }
                else if (_compPlayer)
                {
                    compWait.Enabled = true;
                }
            }
        }
        private void compWait_Tick(object sender, EventArgs e)
        {
            compWait.Enabled = false;
            ComputerPlayer(Player());
        }
        private bool AllScored()
        {
            for (int i = 0; i < 6; i++)
            {
                if ((string)D[i].BackgroundImage.Tag == "White")
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckChangeName()
        {
            for (int i = 0; i < 6; i++)
            {
                if (TB[i].Visible)
                {
                    if (TB[i].Text.Trim() != "")
                        L[i].Text = TB[i].Text.Trim();
                    TB[i].Visible = false;
                    L[i].Visible = true;
                    switch (i)
                    {
                        case 0:
                            Properties.Settings.Default.player1 = L[i].Text;
                            break;
                        case 1:
                            Properties.Settings.Default.player2 = L[i].Text;
                            break;
                        case 2:
                            Properties.Settings.Default.player3 = L[i].Text;
                            break;
                        case 3:
                            Properties.Settings.Default.player4 = L[i].Text;
                            break;
                        case 4:
                            Properties.Settings.Default.player5 = L[i].Text;
                            break;
                        case 5:
                            Properties.Settings.Default.player6 = L[i].Text;
                            break;
                        default:
                            MessageBox.Show("Error");
                            break;
                    }
                    Properties.Settings.Default.Save();
                    return true;
                }
            }
            return false;
        }
        private void ComputerPlayer(int player)
        {
            int unscoredDice = 0;
            EventArgs e = null;
            for (int i = 0; i < 6; i++)
            {
                if ((string)D[i].BackgroundImage.Tag == "White")
                    unscoredDice++;
            }
            if (!_rolled && HighStakes.Visible && !HighStakes.Checked)
            {
                int r = _rand.Next(10);
                if (unscoredDice > 3 || _roundScore >= 1000 || (unscoredDice == 3 && r < 6) || (unscoredDice == 2 && r < 3) || r == 0)
                {
                    HighStakes.Checked = true;
                    compWait.Enabled = true;
                }
                else
                {
                    Roll_Click(_compPlayer, e);
                }
            }
            else
            {
                //Unselect single 5's
                if (_selectedArray[4] > 0 && _selectedArray[4] < 3 && unscoredDice != 0)
                {
                    if (_diceSelected == _selectedArray[4] && _diceSelected != 1)
                    {
                        //unselect all but 1 5
                        for (int i = 0; i < 6; i++)
                        {
                            if (_diceArray[i] == 5 && (string)D[i].BackgroundImage.Tag == "Green")
                            {
                                D[i].BackgroundImage = Properties.Resources.Wdie;
                                D[i].BackgroundImage.Tag = "White";
                                _selectedArray[4]--;
                                _diceSelected--;
                                unscoredDice++;
                            }
                            if (_diceSelected == 1)
                                break;
                        }
                    }
                    else if (_diceSelected != _selectedArray[4])
                    {
                        //unselect all 5's
                        for (int i = 0; i < 6; i++)
                        {
                            if (_diceArray[i] == 5 && (string)D[i].BackgroundImage.Tag == "Green")
                            {
                                D[i].BackgroundImage = Properties.Resources.Wdie;
                                D[i].BackgroundImage.Tag = "White";
                                _selectedArray[4]--;
                                _diceSelected--;
                                unscoredDice++;
                            }
                        }
                    }
                }
                if ((_playerOver10000 == 0 && (unscoredDice > 2 || unscoredDice == 0 || (_roundScore + _rollScore < 500 && _s[player] == 0))) || (_playerOver10000 != 0 && _s[player] + _rollScore + _roundScore < _highestScore) || HighStakes.Checked || !_rolled || unscoredDice == 0)
                {
                    Roll_Click(L[player], e);
                }
                else
                {
                    Done_Click(L[player], e);
                }
            }
        }
        private int Player()
        {
            for (int i = 0; i < 6; i++)
            {
                if (L[i].ForeColor == Color.Green)
                    return i;
            }
            MessageBox.Show("Error No Player Green");
            return 0;
        }
        private void NextPlayer()
        {
            int player = Player();
            L[player].ForeColor = Color.Red;
            L[player].Font = nonPlayerFont;
            TB[player].Font = nonPlayerFont;
            S[player].ForeColor = Color.Red;
            S[player].Font = nonPlayerFont;
            if (player != 5 && L[player + 1].Visible)
            {
                L[player + 1].ForeColor = Color.Green;
                L[player + 1].Font = playerFont;
                TB[player + 1].Font = playerFont;
                S[player + 1].ForeColor = Color.Green;
                S[player + 1].Font = playerFont;
                if (_playerOver10000 == player + 2)
                {
                    Winner();
                    if (H[0].Text == "C")
                    {
                        _compPlayer = true;
                    }
                }
                else if (H[player + 1].Text == "C")
                {
                    _compPlayer = true;
                }
            }
            else
            {
                L[0].ForeColor = Color.Green;
                L[0].Font = playerFont;
                TB[0].Font = playerFont;
                S[0].ForeColor = Color.Green;
                S[0].Font = playerFont;
                if (_playerOver10000 == 1)
                {
                    Winner();
                }
                if (H[0].Text == "C")
                {
                    _compPlayer = true;
                }
            }
            if (_compPlayer)
            {
                compWait.Enabled = true;
            }
        }
        private void Reset(int players)
        {

            for (int i = 0; i < 6; i++)
            {
                _diceArray[i] = 0;
                _selectedArray[i] = 0;
            }
            _count = 0;
            _diceSelected = 0;
            _rollScore = 0;
            _roundScore = 0;
            _playerOver10000 = 0;
            _highestScore = 0;
            for (int i = 0; i < 6; i++)
            {
                _s[i] = 0;
                D[i].BackgroundImage = Properties.Resources.Wdie;
                D[i].BackgroundImage.Tag = "White";
                TB[i].Visible = false;
                S[i].Text = _s[i].ToString();
                L[i].ForeColor = Color.Red;
                L[i].Font = nonPlayerFont;
                L[i].Visible = true;
                H[i].Visible = true;
                S[i].ForeColor = Color.Red;
                S[i].Font = nonPlayerFont;
                S[i].Visible = true;
            }
            _rolled = false;
            _tooLow = false;
            _compPlayer = false;
            HighStakes.Visible = false;
            D[0].Image = Properties.Resources.Fdie;
            D[1].Image = Properties.Resources.Adie;
            D[2].Image = Properties.Resources.Rdie;
            D[3].Image = Properties.Resources.Kdie;
            D[4].Image = Properties.Resources.Edie;
            D[5].Image = Properties.Resources.Ldie;
            RoundScore.Text = "Round Score: 0";
            RollScore.Text = "Roll Score: 0";
            L[0].ForeColor = Color.Green;
            L[0].Font = playerFont;
            S[0].ForeColor = Color.Green;
            S[0].Font = playerFont;
            for (int i = players; i < 6; i++)
            {
                L[i].Visible = false;
                H[i].Visible = false;
                S[i].Visible = false;
            }
            if (H[0].Text == "C")
            {
                _compPlayer = true;
                compWait.Enabled = true;
            }
        }
        private void ScoreSelected(bool turnDiceBlue, bool unselect)
        {
            bool doubTrip = false;
            bool scoreOnes = true;
            bool scoreFives = true;
            _rollScore = 0;
            int doubles = 0, singles = 0;
            for (int i = 0; i < 6; i++)
            {
                if (_selectedArray[i] == 6)
                {
                    _rollScore += 3000;
                    if (i == 0)
                        scoreOnes = false;
                    else if (i == 4)
                        scoreFives = false;
                    if (unselect)
                        _selectedArray[i] = 0;
                }
                if (_selectedArray[i] == 5)
                {
                    _rollScore += 2000;
                    if (i == 0)
                        scoreOnes = false;
                    else if (i == 4)
                        scoreFives = false;
                    if (unselect)
                        _selectedArray[i] = 0;
                }
                if (_selectedArray[i] == 4)
                {
                    _rollScore += 1000;
                    if (i == 0)
                        scoreOnes = false;
                    else if (i == 4)
                        scoreFives = false;
                    if (unselect)
                        _selectedArray[i] = 0;
                }
                if (_selectedArray[i] == 3)
                {
                    for (int j = i + 1; j < 6; j++)
                    {
                        if (_selectedArray[j] == 3)
                        {
                            scoreOnes = false;
                            scoreFives = false;
                            doubTrip = true;
                            _rollScore += 2500;
                            if (unselect)
                            {
                                _selectedArray[i] = 0;
                                _selectedArray[j] = 0;
                            }
                        }
                    }
                    if (i != 0 && !doubTrip)
                    {
                        _rollScore += (i + 1) * 100;
                        if (i == 0)
                            scoreOnes = false;
                        else if (i == 4)
                            scoreFives = false;
                        if (unselect)
                            _selectedArray[i] = 0;
                    }
                }
                if (_selectedArray[i] == 2)
                {
                    doubles++;
                }
                if (_selectedArray[i] == 1)
                {
                    singles++;
                }
            }
            if (doubles == 3 || singles == 6)
            {
                _rollScore += 1500;
                if (unselect)
                {
                    for (int i = 0; i < 6; i++)
                        _selectedArray[i] = 0;
                }
            }
            else
            {
                if (scoreOnes)
                    _rollScore += _selectedArray[0] * 100;
                if (scoreFives)
                    _rollScore += _selectedArray[4] * 50;
                if (unselect)
                {
                    _selectedArray[0] = 0;
                    _selectedArray[4] = 0;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                while (_selectedArray[i] > 0 && unselect)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (_diceArray[j] == i + 1 && (string)D[j].BackgroundImage.Tag == "Green")
                        {
                            D[j].BackgroundImage = Properties.Resources.Wdie;
                            D[j].BackgroundImage.Tag = "White";
                            _selectedArray[i]--;
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if ((string)D[i].BackgroundImage.Tag == "Green")
                {
                    if (turnDiceBlue)
                    {
                        D[i].BackgroundImage = Properties.Resources.Bdie;
                        D[i].BackgroundImage.Tag = "Blue";
                    }
                    else
                        _diceSelected++;
                }
            }
            RollScore.Text = "Roll Score: " + _rollScore;
        }
        private int Winner()
        {
            int winner = 0, winningScore = 0;
            string winnerString;
            for (int i = 0; i < 6; i++)
            {
                if (winningScore < _s[i])
                {
                    winner = i + 1;
                    winningScore = _s[i];
                }
                else if (winningScore == _s[i])
                    winner = winner * 10 + i + 1;
            }
            if (winner < 10)
            {
                winnerString = L[winner - 1].Text + " wins!!!";
            }
            else
            {
                winnerString = "Tie between " + L[winner % 10 - 1].Text;
                while (winner > 99)
                {
                    winner /= 10;
                    winnerString += ", " + L[winner % 10 - 1].Text;
                }
                while (winner > 9)
                {
                    winner /= 10;
                    winnerString += " and " + L[winner % 10 - 1].Text;
                }
            }
            MessageBox.Show(winnerString, "Game Over");
            for (int i = 5; i > 0; i--)
            {
                if (L[i].Visible)
                {
                    Reset(i + 1);
                    break;
                }
            }
            return winner;            
        }
    }
}
