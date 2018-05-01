using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonAccessibles
{
    public enum Mode
    {
        COMMAND, BUILD, PRODUCTION
    }

    private static Building m_CurrentBuilding;
    public static Building CurrentBuilding
    {
        get
        {
            return m_CurrentBuilding;
        }

        set
        {
            if (m_CurrentBuilding != value)
            {
                m_CurrentBuilding = value;
            }
        }
    }
    private static Mode m_ModeState;
    public static Mode ModeState
    {
        get
        {
            return m_ModeState;
        }

        set
        {
            m_ModeState = value;
            OnModeChange(m_ModeState);
        }
    }

    public delegate void GiveOrderOnVariableChange(Mode val);
    public static GiveOrderOnVariableChange OnModeChange;

}
