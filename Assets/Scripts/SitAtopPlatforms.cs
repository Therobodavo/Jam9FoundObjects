using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitAtopPlatforms : MonoBehaviour
{
    ZFixer layererer;
    private void Start()
    {
        layererer = GetComponent<ZFixer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Levantes"))
        {
            layererer.offset.y = 0.2f;
            //print(name + " going up!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Levantes"))
        {
            //print(name + " going down!");
            layererer.offset.y = 0;
        }
    }
}
