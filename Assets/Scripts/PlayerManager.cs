using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int speed = 2;
    Rigidbody2D rb;
    public Transform spriteForm;
    public Transform[] d;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteForm = (d=GetComponentsInChildren<Transform>())[1]; //Since the first willl always be the self;
    }


    // Update is called once per frame
    void Update()
    {
        float sideMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.ClampMagnitude(new Vector3(sideMovement, vertMovement), 1);

        if (movement.sqrMagnitude > 0.01f)
        {
            //Rotate
            float angle = Mathf.Atan2(vertMovement, sideMovement) * Mathf.Rad2Deg;
            if (angle > 90 || angle < -90)
            {
                spriteForm.localScale = new Vector3(1, -1, 1);
            }
            else
            {
                spriteForm.localScale = Vector3.one;
            }
            spriteForm.rotation = Quaternion.Euler(0, 0, angle);
        }

        rb.velocity = movement * speed;
    }
}
