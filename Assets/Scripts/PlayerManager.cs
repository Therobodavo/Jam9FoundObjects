using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int speed = 2;
    Rigidbody2D rb;
    Transform spriteForm;
    [SerializeField] RectTransform timeBar;
    public bool paused;
    [Tooltip("Use Timer Paused to pause the timer while alllowing movement")]
    public bool timerPaused;

    [Header("These are hard set in Start(). You can change at runtime without isssue, however.")]
    public float maxTime, timeLeft;

    public bool hasKey = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteForm = GetComponentsInChildren<Transform>()[1]; //Since the first willl always be the self;
        maxTime = timeLeft = 20;
    }


    // Update is called once per frame
    void Update()
    {
        if (paused) return;
        Move();

        if (timerPaused) return;
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) GameOver();
        else
        {
            timeBar.localScale = new Vector3(timeLeft / maxTime, 1, 1);
        }
    }

    void GameOver()
    {
        print("aaaaah");
        timerPaused = true;
        timeBar.localScale = Vector3.zero;
    }

    void Move()
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
