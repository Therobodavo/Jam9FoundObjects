using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    float currentRotation = 0;
    public int speed = 2;
    public bool hasKey = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sideMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");

        if (vertMovement > 0)
        {
            currentRotation = 90;
        }
        else if (vertMovement < 0)
        {
            currentRotation = 270;
        }
        else if (sideMovement > 0)
        {
            currentRotation = 0;
        }
        else if (sideMovement < 0) 
        {
            currentRotation = 180;
        }
        this.gameObject.transform.rotation = Quaternion.identity;
        this.gameObject.transform.Rotate(0, 0, currentRotation);
        this.gameObject.transform.position += new Vector3(sideMovement, vertMovement, 0) * Time.deltaTime * speed;
    }
}
