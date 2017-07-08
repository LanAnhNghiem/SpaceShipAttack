using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour {

    public Text textUI;
    public string highScorefileName = "highscore.txt";
    List<long> highScore = new List<long>();
    public int maxHighScoreItem = 3;

    // Use this for initialization
    void Start()
    {
        LoadHighScore();
    }

    void LoadHighScore()
    {
        if (File.Exists(highScorefileName))
        {
            var file = File.OpenText(highScorefileName);
            var line = file.ReadLine();
            int count = 0;
            while (line != null && count < maxHighScoreItem)
            {
                long temp = 0;
                long.TryParse(line, out temp);
                highScore.Add(temp);
                count++;
                line = file.ReadLine();
            }
        }
        else
        {
            for (int i = 0; i < maxHighScoreItem; i++)
                highScore.Add(0);
        }
    }

    public void ScoreDisplay()
    {
        textUI.text = "<b>Highscore</b>\n";
        for (int i = 0; i < highScore.Count; i++)
        {
            textUI.text += highScore[i] + "\n";
        }
    }

    public void SaveHighScore(long score)
    {
        highScore.Add(score);
        highScore.Sort();

        var file = File.CreateText(highScorefileName);

        for (int i = 0; i < 5; i++)
            file.WriteLine(highScore[highScore.Count - 1 - i]);

        file.Close();
    }

    public void StoryDisplay()
    {
        textUI.text = "<b>Story</b>\n";
    }

    public void InstructionDisplay()
    {
        textUI.text = "<b>Instruction</b>\n";
    }

    public void OtherDisplay()
    {
        textUI.text = "That 's it. You are done.\n";
        textUI.text += "Enjoy the show\b";
    }
}
