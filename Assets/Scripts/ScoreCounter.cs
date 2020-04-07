using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    float score = 0;

    void addScore(float byAmount){   // could be negative
      score+= byAmount;
      displayScore();
    }

    void displayScore() {
      gameObject.GetComponent<Text>().text = score.ToString();
    }

    public float getCurrentScore() {
      return score;
    }

    public void resetScore() {
      score =0;
    }

    void Update() {
      //addMoney(1f);     for test
    }
}
