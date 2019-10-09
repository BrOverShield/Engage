using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineData : MonoBehaviour
{
    public List<float> time = new List<float>();
    public List<float> throttle = new List<float>();
    public List<float> temp = new List<float>();
    public List<float> rpm = new List<float>();
    public List<float> pressure = new List<float>();
    public List<float> speed = new List<float>();

    public int originalIteratorNumber = 0;
    public float beginningTimeStamp = 0;
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
        beginningTimeStamp = time[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
