using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineData : MonoBehaviour
{
    public float SPLIT_TIME = 1.9f;
    
    public TimeManager timeManager;
    public rpmMeter RPMmeter;
    public Speedometer speedometer;
    private List<float> time = new List<float>();
    private List<float> throttle = new List<float>();
    private List<float> temp = new List<float>();
    private List<int> rpm = new List<int>();
    private List<float> pressure = new List<float>();
    private List<float> speed = new List<float>();

    // Start is called before the first frame update
    void Start()
    {

        int intResult;
        float floatResult;
        TextAsset file = Resources.Load<TextAsset>("data");

        string[] data = file.text.Split('\n');
        for (int i = 4 ; i < data.Length - 1; i++)
        {
            string[] items = data[i].Split(',');
            int.TryParse(items[5], out intResult);
            if (intResult != 0)
            {
                speed.Add(intResult);

                float.TryParse(items[0], out floatResult);
                time.Add(floatResult);
                //print(floatResult);
                float.TryParse(items[1], out floatResult);
                throttle.Add(floatResult);
                
                int.TryParse(items[2], out intResult);
                temp.Add(intResult);
                
                int.TryParse(items[3], out intResult);
                rpm.Add(intResult);
                
                float.TryParse(items[4], out floatResult);
                pressure.Add(floatResult);
            }
        }
        timeManager.setBeginningTimeStamp(getTime(0));
        RPMmeter.updateRPMvalues();
        speedometer.updateSpeedometerValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getTime(int index)
    {
        return time[index];
    }

    public int getListLength()
    {
        return time.Count;
    }

    public int getRPM(int index)
    {
        return rpm[index];
    }

    public float getSpeed(int index)
    {
        return speed[index];
    }
}
