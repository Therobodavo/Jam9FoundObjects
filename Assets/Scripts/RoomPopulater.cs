using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPopulater : MonoBehaviour
{
    [SerializeField] GameObject platformPref, pushablePref, door;
    [SerializeField] Transform min, max;

    float xMin, xMax, yMin, yMax;

    bool roomCleared;

    public List<Platform> switches;
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

        //PushableTypes[] types = Pushable.GetUniqueTypes(numObjects);

        for (int i = 0; i < numObjects; i++)
        {
            PushableTypes type = Pushable.GetRandomType();//types[i];

            Instantiate(
                pushablePref,
                new Vector3(
                    Random.Range(xMin, xMax),
                    Random.Range(yMin, yMax),
                    0
                ),
                Quaternion.identity
            ).GetComponent<Pushable>().type = type;



            Platform plat =
            Instantiate(
                platformPref,
                new Vector3(
                    Random.Range(xMin, xMax),
                    Random.Range(yMin, yMax) + 1,
                    0
                ),
                Quaternion.identity
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
}
