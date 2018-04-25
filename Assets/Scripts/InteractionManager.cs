using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public delegate void OnMouseAction();
    public OnMouseAction action;


    

    public Camera cam;
    //CommonAccessibles.Mode mode;
    // Use this for initialization

    void Awake()
    {
        action += OnMouseInput;
    }

    void Start()
    {
        CommonAccessibles.ModeState = CommonAccessibles.Mode.COMMAND;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CommonAccessibles.ModeState != CommonAccessibles.Mode.PRODUCTION || CommonAccessibles.ModeState != CommonAccessibles.Mode.BUILD)
            {
                action();
            }
        }
    }


    public void OnMouseInput()
    {
        
        RaycastHit hit;

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                switch (hit.collider.tag)
                {
                    case "Buildable":
                        CommonAccessibles.ModeState = CommonAccessibles.Mode.BUILD;

                        break;
                    case "Building":
                        CommonAccessibles.ModeState = CommonAccessibles.Mode.PRODUCTION;
                        break;
                    default:
                    case "Unbuildable":
                        CommonAccessibles.ModeState = CommonAccessibles.Mode.COMMAND;
                        break;

                }
            }
 

    }

}
