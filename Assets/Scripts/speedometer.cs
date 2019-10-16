using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    static public float DEGREE_PER_KM_PER_H = -1.41f;
    
    public GameObject needle;
    public EngineData engineData;
    public TimeManager timeManager;
    public Text speedText;

    private float firstSpeed;
    private float rotationSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void updateSpeedometerValues()
    {
        firstSpeed = engineData.getSpeed(timeManager.getIterator());
        float secondSpeed = engineData.getSpeed(timeManager.getIterator() + 1);
        float splitSpeed = secondSpeed - firstSpeed;
        rotationSpeed = splitSpeed / engineData.SPLIT_TIME;
    }

    public void updateSpeedometerNeedle()
    {
        if (timeManager.getIterator() + 1 <= engineData.getListLength() - 2)
        {
            float currentSpeed = firstSpeed + (timeManager.currentTime%engineData.SPLIT_TIME) * rotationSpeed;
            //print("splittime : " + timeManager.currentTime%timeManager.SPLIT_TIME);
            int intCurrentSpeed = (int)currentSpeed;
            speedText.text = intCurrentSpeed.ToString();
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
