using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeringByPosition : MonoBehaviour
{
    Vector3 offset;
    Transform spriteForm;
    private void Start()
    {
        spriteForm = GetComponentsInChildren<Transform>()[1]; //Since the first willl always be the self.
    }
    // Update is called once per frame
    void Update()
    {
        offset.z = transform.position.y;

        spriteForm.localPosition = offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer == LayerMask.NameToLayer("Mobilia") && collision.gameObject.layer == LayerMask.NameToLayer("Levantes"))
        {
            offset.y = 0.2f;
            print(name + " going up!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.layer == LayerMask.NameToLayer("Mobilia") && collision.gameObject.layer == LayerMask.NameToLayer("Levantes"))
        {
            print(name + " going down!");
            offset.y = 0;
        }
    }
}
