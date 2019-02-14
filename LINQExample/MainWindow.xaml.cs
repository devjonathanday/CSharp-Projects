using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINQExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<HighScoreEntry> scoreTable = new List<HighScoreEntry>();

        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            ErrorMessage.Text = "";
            scoreTable = GetHighScores(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\hscores.txt");
            UpdateList();
        }

        public class HighScoreEntry
        {
            private string name;
            private int rank;
            private int score;

            public string Name { get => name; set => name = value; }
            public int Rank { get => rank; set => rank = value; }
            public int Score { get => score; set => score = value; }

            public HighScoreEntry(string newName, int newRank, int newScore)
            {
                name = newName;
                rank = newRank;
                score = newScore;
            }
        }

        public List<HighScoreEntry> GetHighScores(string filePath)
        {
            List<HighScoreEntry> newList = new List<HighScoreEntry>();
            string[] lines = File.ReadAllLines(filePath);
            foreach(string line in lines)
            {
                string[] fields = line.Split(',');
                int.TryParse(fields[1], out int newRank);
                int.TryParse(fields[2], out int newScore);
                newList.Add(new HighScoreEntry(fields[0], newRank, newScore));
            }
            return newList;
        }

        private void SubmitNewScoreEntry(object sender, RoutedEventArgs e)
        {
            int parsedScore = 0;
            if (UsernameInput.Text == string.Empty || ScoreInput.Text == string.Empty || !int.TryParse(ScoreInput.Text, out parsedScore))
                ErrorMessage.Text = "Error: Invalid entry.";
            else
            {
                scoreTable.Add(new HighScoreEntry(UsernameInput.Text, 1, parsedScore));
                var newTable = scoreTable.OrderBy(HighScoreEntry => HighScoreEntry.Score);
                for (int i = 0; i < scoreTable.Count; i++)
                    scoreTable[i] = new HighScoreEntry(scoreTable[i].Name, i + 1, scoreTable[i].Score);
                UpdateList();
                ErrorMessage.Text = "High score submitted successfully.";
            }
            
        }
        private void UpdateList()
        {
            var top10 = from entry in scoreTable where entry.Rank <= 10 select entry;
            top10 = top10.OrderBy(HighScoreEntry => HighScoreEntry.Score);
            ScoreList.Text = "High Scores: \n";
            foreach (HighScoreEntry entry in top10)
                ScoreList.Text += entry.Rank + ".) " + entry.Name + ": " + entry.Score + "\n";
        }
    }
}