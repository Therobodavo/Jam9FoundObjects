using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chesterface : MonoBehaviour
{
    Dictionary<GemTypes, int> gemValues = new Dictionary<GemTypes, int>()
    {
        { GemTypes.Blue, 25 },
        { GemTypes.Green, 35 },
        { GemTypes.Orange, 65 }
    };


    Dictionary<GemTypes, Sprite> gemSprites = new Dictionary<GemTypes, Sprite>();

    [SerializeField]
    Text buttonText, pointText, colourText;
    [SerializeField]
    Image chestRenderer, gemRenderer;

    Sprite chestClosed, chestOpen;

    bool opened;

    Chest isBeingOpened;

    static Sprite GemSprite(GemTypes colour)
    {
        return Resources.Load<Sprite>("PlanetCute/Gem " + colour);
    }
    PlayerManager player;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerManager>();

        gemSprites.Add(GemTypes.Blue, GemSprite(GemTypes.Blue));
        gemSprites.Add(GemTypes.Green, GemSprite(GemTypes.Green));
        gemSprites.Add(GemTypes.Orange, GemSprite(GemTypes.Orange));

        chestClosed = Resources.Load<Sprite>("PlanetCute/Chest Closed");
        chestOpen = Resources.Load<Sprite>("PlanetCute/Chest Open");
    }


    public void Open(Chest chest, GemTypes colour)
    {
        isBeingOpened = chest;

        gameObject.SetActive(true);
        chestRenderer.sprite = chestClosed;

        //print(colour);
        gemRenderer.sprite = gemSprites[colour];
        gemRenderer.enabled = false;

        colourText.text = colour + " Gem";
        colourText.enabled = false;

        pointText.text = gemValues[colour] + " points";
        pointText.enabled = false;

        buttonText.text = "Open " + (Random.Range(0, 5) == 0 ? "loootcase": "chest");

        opened = false;

        player.hintPoints += gemValues[colour];
    }

    
    public void Click()
    {
        if (!opened)
        {
            buttonText.text = "Back to game";

            gemRenderer.enabled = true;
            colourText.enabled = true;
            pointText.enabled = true;

            chestRenderer.sprite = chestOpen;

            opened = true;
        }
        else
        {
            //print("?");
            player.paused = false;
            player.UpdateHints();
            gameObject.SetActive(false);
            isBeingOpened.GetComponentInChildren<SpriteRenderer>().sprite = chestOpen;
        }
    }
}
