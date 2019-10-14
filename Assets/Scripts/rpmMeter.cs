using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class rpmMeter : MonoBehaviour
{
    static public float DEGREE_PER_RPM = -0.0426f;
    
    public GameObject needle;
    public EngineData engineData;
    public TimeManager timeManager;
    public Text RPMtext;

    private float splitTime;
    private int firstRPM;
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.getIterator() + 1 <= engineData.getListLength() - 2)
        {
            float currentRPM = (float)firstRPM + timeManager.currentTime%splitTime * rotationSpeed;
            RPMtext.text = (currentRPM / 1000).ToString("F1");
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

    public void updateRPMvalues()
    {
        float firstTime = engineData.getTime(timeManager.getIterator());
        float secondTime = engineData.getTime(timeManager.getIterator() + 1);
        splitTime = secondTime - firstTime;
        firstRPM = (int)engineData.getRPM(timeManager.getIterator());
        float secondRPM = engineData.getRPM(timeManager.getIterator() + 1);
        float splitRPM = secondRPM - firstRPM;
        rotationSpeed = splitRPM / splitTime;
    }
}
