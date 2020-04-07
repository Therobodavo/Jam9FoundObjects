using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] GameObject platformPref, pushablePref, door;
    [SerializeField] Transform min, max;

    float xMin, xMax, yMin, yMax;

    bool roomCleared;

    List<Platform> switches;
    List<Pushable> boxes;


    int hinted = 0;

    public bool CanHint { get { return hinted < switches.Count; } }

    // Start is called before the first frame update
    void Start()
    {
        xMin = min.position.x;
        xMax = max.position.x;
        yMin = min.position.y;
        yMax = max.position.y;

        //////////////////////////////////////Hard coded object count over here
        int numObjects = 3;


        switches = new List<Platform>();
        boxes = new List<Pushable>();

        //PushableTypes[] types = Pushable.GetUniqueTypes(numObjects);

        for (int i = 0; i < numObjects; i++)
        {
            PushableTypes type = Pushable.GetRandomType();//types[i];

            Pushable box =
            Instantiate(
                pushablePref,
                new Vector3(
                    Random.Range(xMin, xMax),
                    Random.Range(yMin, yMax),
                    0
                ),
                Quaternion.identity,
                transform
            ).GetComponent<Pushable>();
            
            box.type = type;
            boxes.Add(box);



            Platform plat =
            Instantiate(
                platformPref,
                new Vector3(
                    Random.Range(xMin, xMax),
                    Random.Range(yMin, yMax) + 1,
                    0
                ),
                Quaternion.identity,
                transform
            ).GetComponent<Platform>();

            plat.target = type;
            switches.Add(plat);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!roomCleared)
        {
            foreach (Platform p in switches)
            {
                if (!p.ready)
                {
                    return;
                }
            }

            roomCleared = true;
            Destroy(door);

            FindObjectOfType<PlayerManager>().timerPaused = true;

            FindObjectOfType<RoomManager>().GenRoom();
        }
    }

    public void ShowHint()
    {
        if (!CanHint) throw new System.Exception("No have hint idiot");

        SpriteRenderer plat, push;

        push = boxes[hinted].GetComponentInChildren<SpriteRenderer>();
        plat = switches[hinted].GetComponentInChildren<SpriteRenderer>();

        Color c = Color.HSVToRGB(Random.Range(0f, 1), 0.5f, 1);

        push.color = plat.color = c;

        hinted++;
    }
}
