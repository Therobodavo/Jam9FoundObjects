
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PushableTypes
{
    Rock,
    Star,
    TreeTall,
    TreeShort,
    TreeUgly,
    WindowTall
};
public class Pushable : MonoBehaviour
{
    static int typeCount = System.Enum.GetNames(typeof(PushableTypes)).Length;

    /// <summary>
    /// I don't know why I wrote this.
    /// </summary>
    /// <param name="count">How many pushable types do you want?</param>
    /// <returns>An arrray of distinct PushableTypes</returns>
    public static PushableTypes[] GetUniqueTypes(int count)
    {
        if (count > typeCount)
        {
            throw new System.ArgumentOutOfRangeException(string.Format("{0} is outside the range 0—{1}. ({0} was the argument given.)", count, typeCount));
        }
        List<int> indices = new List<int>();

        for (int i = 0; i < count; i++)
        {
            int next = Random.Range(0, typeCount - i);

            while (indices.Contains(next)) next++;
            print(next);

            indices.Add(next);
        }


        PushableTypes[] result = new PushableTypes[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = (PushableTypes)indices[i];
        }
        
        return result;
    }

    public static PushableTypes GetRandomType()
    {
        return (PushableTypes)Random.Range(0, typeCount);
    }





    public PushableTypes type;

    string typeString;

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
        sr.sprite = Resources.Load<Sprite>("PlanetCute/" + typeString);
    }

}
