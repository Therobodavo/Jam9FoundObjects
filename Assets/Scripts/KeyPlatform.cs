using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlatform : MonoBehaviour
{
    public PushableTypes target;
    [SerializeField] GameObject keyPref;
    PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Pushable>()?.type == target && !player.HasKey)
        {
            player.GiveKey(Instantiate(keyPref, transform.position, Quaternion.identity));
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
