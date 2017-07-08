using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetection : MonoBehaviour {

    public int bonusScoreMode = 0;

    void OnTriggerEnter(Collider otherCollider)
    {
        if (true)
        {
            ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
            scoreKeeper.IncrementScore(bonusScoreMode);
        }
    }
}
