using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ZBS Unity project test script


public class testing : MonoBehaviour
{
    public Text visualLog;

    private bool isLogEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        // check if the log is assigned
        if (visualLog == null)
        {
            Debug.LogError("Visual log is not assigned");
            return;
        }
        else
        {
            isLogEnabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddLogLine(string newLog)
    {
        // add a new line to the log
        if (isLogEnabled)
        {
            visualLog.text += newLog + "\n";
        }
    }

}