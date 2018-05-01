using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeDisplay : MonoBehaviour
{
    public Text text;
    // Use this for initialization
    void Start()
    {
        CommonAccessibles.OnModeChange += ModeDisplayChange;
    }

    public void ModeDisplayChange(CommonAccessibles.Mode mode)
    {
        text.text = "Mode: " + mode;
    }
}
