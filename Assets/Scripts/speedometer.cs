using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class speedometer : MonoBehaviour
{
    public GameObject needle;
    public EngineData engineData;
    public TimeManager timeManager;
    
    static public float DEGREE_PER_KM_PER_H = -1.41f;

    private int iterator = 0;
    
    void Start()
    {
        iterator = engineData.originalIteratorNumber;
    }

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
            float firstSpeed = engineData.speed.ElementAt(iterator);
            float secondSpeed = engineData.speed.ElementAt(iterator + 1);
            float splitSpeed = secondSpeed - firstSpeed;
            float rotationSpeed = splitSpeed / splitTime;
            float currentSpeed = firstSpeed + timeManager.currentTime%splitTime * rotationSpeed;
            float currentDegree = currentSpeed * DEGREE_PER_KM_PER_H;
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
