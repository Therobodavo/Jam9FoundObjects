using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZFixer : MonoBehaviour
{
    [HideInInspector]
    public Vector3 offset;
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
}
