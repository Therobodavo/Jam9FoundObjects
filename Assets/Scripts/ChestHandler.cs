using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestHandler : MonoBehaviour
{

    public List<Sprite> gemImages = new List<Sprite>();
    public float basicGemValue;
    public Transform money;

    GameObject closedChest, openedChest, gemimage, gemname, gemvalue, button;

    bool isRevealed = false;
    float gemValue;

    // Start is called before the first frame update
    void Start()
    {
         closedChest = transform.GetChild(0).gameObject;
         openedChest = transform.GetChild(1).gameObject;
         gemimage = transform.GetChild(2).gameObject;
         gemname = transform.GetChild(3).gameObject;
         gemvalue = transform.GetChild(4).gameObject;
         button = transform.GetChild(5).gameObject;

         openedChest.SetActive(false);
         gemimage.SetActive(false);
         gemname.SetActive(false);
         gemvalue.SetActive(false);
    }

    public void buttonClicked() {
      if(!isRevealed) {
        isRevealed = true;
        button.GetComponentInChildren<Text>().text = "Back to game";

        int gemType = Random.Range(0,3);
        gemimage.GetComponent<Image>().sprite = gemImages[gemType];
        gemname.GetComponent<Text>().text = "Gem " + (gemType+1).ToString();
        gemValue = basicGemValue*(gemType+1);
        gemvalue.GetComponent<Text>().text = "$" + gemValue.ToString();

        closedChest.SetActive(false);
        openedChest.SetActive(true);
        gemimage.SetActive(true);
        gemname.SetActive(true);
        gemvalue.SetActive(true);
      }
      else {
        money.gameObject.GetComponent<MoneyCounter>().addMoney(gemValue);
        Destroy(gameObject,0.01f);
      }
    }
}
