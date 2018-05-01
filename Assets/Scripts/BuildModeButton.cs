using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeButton : MonoBehaviour
{

    //private void OnMouseDown()
    //{
    //    CommonAccessibles.ModeState = CommonAccessibles.Mode.BUILD;
    //}

    public void OnButtonClick()
    {
        CommonAccessibles.ModeState = CommonAccessibles.Mode.BUILD;
    }

}
