using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonAccessibles
{
    public enum Mode
    {
        COMMAND, BUILD, PRODUCTION
    }



    public static Mode ModeState
    {
        get
        {
            return ModeState;
        }

        set
        {
            OnModeChange();
            ModeState = value;
        }
    }

    public delegate void GiveOrderOnVariableChange();
    public static GiveOrderOnVariableChange OnModeChange;

}
