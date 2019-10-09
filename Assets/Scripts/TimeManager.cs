using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float currentTime;
    public static int framesPerSecond = 30;

    public float frameLength;

    // Start is called before the first frame update
    void Start()
    {
        frameLength = (float)(1m/framesPerSecond);
        currentTime = 0;
        print(frameLength);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + frameLength;
        //print(currentTime);
    }
}
