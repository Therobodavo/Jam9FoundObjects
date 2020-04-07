using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PushableTypes target;
    /// <summary>
    /// Does this platform have its object?
    /// </summary>
    public bool ready;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Pushable>()?.type == target)
        {
            ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Pushable>()?.type == target)
        {
            ready = false;
        }
    }
}
