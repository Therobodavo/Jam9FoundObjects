using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Transform playerSpriteorm;
    Vector3 offfsetFromPlayer = new Vector3(0, 2, 0);

    private void Start()
    {
        playerSpriteorm = FindObjectOfType<PlayerManager>().GetComponentsInChildren<Transform>()[1];
    }

    float time;

    // Update is called once per frame
    void Update()
    {
        time += 4*Time.deltaTime;

        time = time % (Mathf.PI * 2);

        Vector3 pos = playerSpriteorm.position + offfsetFromPlayer;
        pos.y += 0.2f * Mathf.Sin(time);

        transform.position = Vector3.Lerp(transform.position, pos, 0.05f);
    }
}
