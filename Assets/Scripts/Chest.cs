using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GemTypes
{
    Blue,
    Green,
    Orange
}
public class Chest : MonoBehaviour
{
    public GemTypes gem;
    public bool opened = false;

    private void Awake()
    {
        gem = (GemTypes)Random.Range(0, 3);
    }
}
