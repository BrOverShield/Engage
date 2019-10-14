using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public rpmMeter RPMmanager;
    public Speedometer speedometer;
    public float currentTime;
    public static int framesPerSecond = 30;
    public int originalIteratorNumber = 0;
    private int iterator;

    public float frameLength;
    private float beginningTimeStamp;

    // Start is called before the first frame update
    void Start()
    {
        iterator = originalIteratorNumber;
        frameLength = (float)(1m/framesPerSecond);
        currentTime = 0;
        // print(frameLength);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + frameLength;
        //print(currentTime);
        if (currentTime / ((iterator + 1) * 1.9f) > 1)
        {
            iterator += 1;
            print("NOW");
            RPMmanager.updateRPMvalues();
            speedometer.updateSpeedometerValues();
        }
    }

    public void setBeginningTimeStamp(float value)
    {
        beginningTimeStamp = value;
    }

    public int getIterator()
    {
        return iterator;
    }
}
