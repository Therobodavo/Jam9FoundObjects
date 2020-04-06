using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestHandler : MonoBehaviour
{

    public List<Sprite> gemImages = new List<Sprite>();
    public float basicGemValue;
    public Transform money;
    public int chestIniCount;

    GameObject closedChest, openedChest, gemimage, gemname, gemvalue, button, chestcount;

    bool isRevealed = false;
    bool isOpeningChest = false;
    float gemValue;
    int currentChest;

    // Start is called before the first frame update
    void Start()
    {
       closedChest = transform.GetChild(0).gameObject;
       openedChest = transform.GetChild(1).gameObject;
       gemimage = transform.GetChild(2).gameObject;
       gemname = transform.GetChild(3).gameObject;
       gemvalue = transform.GetChild(4).gameObject;
       button = transform.GetChild(5).gameObject;
       chestcount = transform.GetChild(6).gameObject;

       closedChest.SetActive(false);
       openedChest.SetActive(false);
       gemimage.SetActive(false);
       gemname.SetActive(false);
       gemvalue.SetActive(false);
       button.SetActive(false);

       currentChest = chestIniCount;
       chestcount.GetComponent<Text>().text = currentChest.ToString();
    }

    void reset() {
      button.GetComponentInChildren<Text>().text = "Open chest";
      button.SetActive(false);
      openedChest.SetActive(false);
      gemimage.SetActive(false);
      gemname.SetActive(false);
      gemvalue.SetActive(false);
      isRevealed = false;
      isOpeningChest = false;
    }

    public void openChest(){
       if (currentChest==0) return;
       if (isOpeningChest) return;
       button.SetActive(true);
       closedChest.SetActive(true);
       currentChest--;
       chestcount.GetComponent<Text>().text = currentChest.ToString();
       isOpeningChest = true;
    }

    public void addChest(int byAmount) {
      currentChest += byAmount;
      chestcount.GetComponent<Text>().text = currentChest.ToString();
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
        reset();
      }
    }
}
