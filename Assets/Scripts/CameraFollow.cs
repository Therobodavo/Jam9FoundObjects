using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public float lerpSpeed;

    private float startTime;

    private float distance;

    private Vector3 startPos;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.z = -10.0f;
        if((target - playerPos).sqrMagnitude >= 0.1f)
        {
            startPos = transform.position;
            target = playerPos;
            startTime = Time.time;
            distance = Vector3.Distance(target, transform.position);
        }
        float d = (target - transform.position).sqrMagnitude;
        //if (d >= 0.5f)
            //transform.position = Vector3.Lerp(startPos, target, ((Time.time - startTime) * lerpSpeed) / distance);
        if(d >= 0.001f)
            transform.position = Vector3.Lerp(startPos, target, ((Time.time - startTime) * lerpSpeed) / distance);
    }
}
