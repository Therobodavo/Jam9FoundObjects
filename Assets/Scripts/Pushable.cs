using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PushableTypes
{
    DirtBlock,
    DoorTallClosed,
    Rock,
};
public class Pushable : MonoBehaviour
{
    

    public PushableTypes type;

    public string typeString;

    string Stringify(PushableTypes enumValue)
    {
        string from = enumValue.ToString(), result = from[0].ToString();

        for (int i = 1; i < from.Length; i++)
        {
            char c = from[i];
            if (c - 'A' < 26)
            {
                result += ' ';
            }
            result += c;
        }

        return result;
    }

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        typeString = Stringify(type);
        sr = GetComponentInChildren<SpriteRenderer>();
        print(sr.sprite = Resources.Load<Sprite>(typeString));
    }

}
