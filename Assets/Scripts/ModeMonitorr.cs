using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeMonitorr : MonoBehaviour
{
    public string currentMode = CommonAccessibles.ModeState.ToString();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentMode = CommonAccessibles.ModeState.ToString();
        Debug.Log(CommonAccessibles.ModeState);
    }
}
