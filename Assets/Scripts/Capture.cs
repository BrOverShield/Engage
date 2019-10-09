using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    public int iName = 10000;
    
    // Start is called before the first frame update
    void Start()
    {
        //Time.captureFramerate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        iName = iName + 1;
        ScreenCapture.CaptureScreenshot ("image-"+iName.ToString()+".png",1);
    }
}
