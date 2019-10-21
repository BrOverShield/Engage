using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PressureManager : MonoBehaviour
{

    static public string MAX_PRESSURE_MESSAGE_START = "Max Boost : ";
    static public string AVG_PRESSURE_MESSAGE_START = "Avg Boost : ";
    static public float DEGREE_PER_KPA = -0.6f;
    static public float DEGREE_PER_PSI = -6.0f;
    static public string PSI_UNIT = "PSI";
    static public float NEEDLE_OFFSET = -60.0f;

    public GameObject needle;
    public EngineData engineData;
    public TimeManager timeManager;
    public Text pressureText;
    public Text maxPressureText;
    public Text avgPressureText;

    private float firstPressure;
    private float rotationSpeed;
    private int maxPressure;
    private int avgPressure;
    private int sumPressure = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePressureValues()
    {
        firstPressure = engineData.getPressure(timeManager.getIterator());
        float secondPressure = engineData.getPressure(timeManager.getIterator() + 1);
        float splitPressure = secondPressure - firstPressure;
        rotationSpeed = splitPressure / engineData.SPLIT_TIME;
    }

    public void updatePressureNeedle()
    {
        if (timeManager.getIterator() + 1 <= engineData.getListLength() - 2)
        {
            float currentPressure = firstPressure + (timeManager.currentTime%engineData.SPLIT_TIME) * rotationSpeed;
            int intCurrentPressure = (int)currentPressure;
            confirmAndSetMaxPressure(intCurrentPressure);
            updateAvgPressure(intCurrentPressure);
            pressureText.text = intCurrentPressure.ToString();
            float currentDegree = currentPressure * DEGREE_PER_PSI + NEEDLE_OFFSET;
            needle.transform.Rotate(0.0f ,0.0f,  currentDegree);
            needle.transform.localRotation = Quaternion.Euler(0f, 0f, currentDegree);
        }
        else
        {
            print("done!");
            Application.Quit();
        }
    }

    public void confirmAndSetMaxPressure(int value)
    {
        if (value > maxPressure)
        {
            maxPressure = value;
            updateMaxPressureText();
        }
    }

    private void updateMaxPressureText()
    {
        maxPressureText.text = MAX_PRESSURE_MESSAGE_START + maxPressure.ToString() + " " + PSI_UNIT;
    }

    private void updateAvgPressure(int newPressure)
    {
        sumPressure += newPressure;
        int frameCount = timeManager.getFrameCount();
        avgPressure = (int)((float)sumPressure/(float)frameCount);
        updateAvgPressureText();
    }

    private void updateAvgPressureText()
    {
        avgPressureText.text = AVG_PRESSURE_MESSAGE_START + avgPressure.ToString() + " " + PSI_UNIT;
    }
}