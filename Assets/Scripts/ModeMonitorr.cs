using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeMonitorr : MonoBehaviour
{
    public string currentMode = CommonAccessibles.mode.ToString();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentMode = CommonAccessibles.mode.ToString();
        Debug.Log(CommonAccessibles.mode);
    }
}
