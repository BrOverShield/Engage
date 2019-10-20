using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public rpmMeter RPMmanager;
    public Speedometer speedometer;
    public EngineData engineData;
    public float currentTime;
    public static int framesPerSecond = 30;
    public int originalIteratorNumber = 0;
    private int iterator;

    public float frameLength;
    private float beginningTimeStamp;
    private int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        iterator = originalIteratorNumber;
        frameLength = (float)(1m/framesPerSecond);
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + frameLength;
        if (currentTime / ((iterator + 1) * engineData.SPLIT_TIME) > 1)
        {
            iterator += 1;
            RPMmanager.updateRPMvalues();
            speedometer.updateSpeedometerValues();

        }
        frameCount += 1;
        speedometer.updateSpeedometerNeedle();
    }

    public void setBeginningTimeStamp(float value)
    {
        beginningTimeStamp = value;
    }

    public int getIterator()
    {
        return iterator;
    }
    public int getFrameCount()
    {
        return frameCount;
    }

}
