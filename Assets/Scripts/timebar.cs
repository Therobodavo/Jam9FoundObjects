using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timebar : MonoBehaviour
{

    public float totalTime;
    public float speed;
    public bool isCounting;

    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        isCounting = true;
        resetTime();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCounting) return;
        if(currentTime <= 0) {
          gameObject.GetComponent<RectTransform>().localScale = new Vector3(0f,1f,1f);
          return;
        };
        currentTime -= speed;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(currentTime/totalTime,1f,1f);
    }

    public void resetTime() {
      currentTime = totalTime;
    }

    public float getCurrentTime() {
      return currentTime;
    }
}
