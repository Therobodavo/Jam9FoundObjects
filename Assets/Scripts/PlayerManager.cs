using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int speed = 2;
    Rigidbody2D rb;
    Transform spriteForm;
    [SerializeField] RectTransform timeBar;
    public bool paused;
    [Tooltip("Use Timer Paused to pause the timer while alllowing movement")]
    public bool timerPaused;

    [Header("These are hard set in Start() but safe to change at runtime.")]
    public float maxTime; public float timeLeft;

    [Space(10)]
    GameObject keyInst;
    public bool HasKey { get; private set; }

    [Space(10)]
    [SerializeField] Text hintText;

    [Header("Also hard set on Start(). Editor changes won't update text")]
    [Tooltip("but it willl stilll take efffect in game logic.")]
    public int hintPoints = 15;

    [HideInInspector]
    /// <summary>
    /// Set by RooommManger for the first rooom, then OnTrigggerEnter in this script
    /// </summary>
    public Room currentRoom;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteForm = GetComponentsInChildren<Transform>()[1]; //Since the first willl always be the self;
        maxTime = timeLeft = 40;
        hintPoints = 15;
        UpdateHints();
    }


    // Update is called once per frame
    void Update()
    {
        if (paused) return;
        Move();
        CheckInputForHint();

        if (timerPaused) return;
        UpdateTimer();
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

    void CheckInputForHint()
    {
        if(Input.GetKeyDown(KeyCode.Space) && currentRoom.CanHint)
        {
            if (hintPoints >= 10)
            {
                hintPoints -= 10;
                UpdateHints();
                currentRoom.ShowHint();
            }
        }
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


    public void GiveKey(GameObject key)
    {
        HasKey = true;
        keyInst = key;
    }

    void UpdateHints()
    {
        hintText.text = "Hint points: " + hintPoints;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chest" && HasKey)
        {
            print("nepO emaseS");
            Destroy(keyInst);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Triggger enter");
        if (other.tag == "Player detector")
        {
            timeLeft = maxTime;
            currentRoom = other.gameObject.transform.parent.GetComponent<Room>();
            timerPaused = false;
            Destroy(other);
        }
    }
}
