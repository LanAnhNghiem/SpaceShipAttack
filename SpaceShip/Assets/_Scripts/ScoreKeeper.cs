using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    int score = 0;
    public int[] ScoreModes;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncrementScore(int bonusScoreMode)
    {
        print("Detect Score");
        if (bonusScoreMode < 0 && bonusScoreMode > ScoreModes.Length - 1)
        {
            return;
        }
        score += ScoreModes[bonusScoreMode];
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();
    }
}
