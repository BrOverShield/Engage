using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class rpmMeter : MonoBehaviour
{
    public GameObject needle;
    public EngineData engineData;
    public TimeManager timeManager;

    private int iterator;
    
    static public float DEGREE_PER_RPM = -0.0426f;

    // Start is called before the first frame update
    void Start()
    {
        iterator = engineData.originalIteratorNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (iterator + 1 <= engineData.time.Count - 2)
        {
            if (timeManager.currentTime > engineData.time[iterator] - engineData.beginningTimeStamp)
            {
                iterator = iterator + 1;
            }
            float firstTime = engineData.time.ElementAt(iterator);
            float secondTime = engineData.time.ElementAt(iterator + 1);
            float splitTime = secondTime - firstTime;
            float firstRPM = engineData.rpm.ElementAt(iterator);
            float secondRPM = engineData.rpm.ElementAt(iterator + 1);
            float splitRPM = secondRPM - firstRPM;
            float rotationSpeed = splitRPM / splitTime;
            float currentRPM = firstRPM + timeManager.currentTime%splitTime * rotationSpeed;
            float currentDegree = currentRPM * DEGREE_PER_RPM;
            needle.transform.Rotate(0.0f ,0.0f,  currentDegree);
            needle.transform.localRotation = Quaternion.Euler(0f, 0f, currentDegree);
        }
        else
        {
            print("done!");
            Application.Quit();
        }
    }
}
