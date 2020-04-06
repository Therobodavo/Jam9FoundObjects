using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{

    float money = 0;

    public void addMoney(float byAmount){   // could be negative
      money+= byAmount;
      displayMoney();
    }

    void displayMoney() {
      gameObject.GetComponent<Text>().text = money.ToString();
    }

    public float getCurrentMoney() {
      return money;
    }

    public void resetMoney() {
      money =0;
    }

    void Update() {
      //addMoney(1f);     for test
    }
}
