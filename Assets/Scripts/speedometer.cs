using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    static public float DEGREE_PER_KM_PER_H = -1.41f;
    static public string KM_PER_H_UNIT = "km/h";
    static public string MAX_SPEED_MESSAGE_START = "Max Speed : ";
    static public string AVG_SPEED_MESSAGE_START = "Avg Speed : ";
    
    public GameObject needle;
    public EngineData engineData;
    public TimeManager timeManager;
    public Text speedText;
    public Text maxSpeedText;
    public Text avgSpeedText;

    private float firstSpeed;
    private float rotationSpeed;
    private int maxSpeed;
    private int avgSpeed;
    private int sumSpeed = 0;
    
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
            int intCurrentSpeed = (int)currentSpeed;
            confirmAndSetMaxSpeed(intCurrentSpeed);
            updateAvgSpeed(intCurrentSpeed);
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

    public void confirmAndSetMaxSpeed(int value)
    {
        if (value > maxSpeed)
        {
            maxSpeed = value;
            updateMaxSpeedText();
        }
    }

    private void updateMaxSpeedText()
    {
        maxSpeedText.text = MAX_SPEED_MESSAGE_START + maxSpeed.ToString() + " " + KM_PER_H_UNIT;
    }

    private void updateAvgSpeed(int newSpeed)
    {
        sumSpeed += newSpeed;
        int frameCount = timeManager.getFrameCount();
        avgSpeed = (int)((float)sumSpeed/(float)frameCount);
        updateAvgSpeedText();
    }

    private void updateAvgSpeedText()
    {
        avgSpeedText.text = AVG_SPEED_MESSAGE_START + avgSpeed.ToString() + " " + KM_PER_H_UNIT;
    }
}
