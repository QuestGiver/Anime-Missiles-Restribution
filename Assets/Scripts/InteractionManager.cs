using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public delegate void OnMouseAction();
    public OnMouseAction action;
    CommonAccessibles.Mode mode;

    

    public Camera cam;
    //CommonAccessibles.Mode mode;
    // Use this for initialization

    void Awake()
    {
        action += OnMouseInput;
    }

    void Start()
    {
        mode = CommonAccessibles.Mode.COMMAND;
    }

    // Update is called once per frame


    private void OnMouseDown()
    {
        action();
    }

    public void OnMouseInput()
    {
        
        RaycastHit hit;
        if (mode != CommonAccessibles.Mode.PRODUCTION || mode != CommonAccessibles.Mode.BUILD)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                switch (hit.collider.tag)
                {
                    case "Buildable":
                        mode = CommonAccessibles.Mode.BUILD;

                        break;
                    case "Building":
                        mode = CommonAccessibles.Mode.PRODUCTION;
                        break;
                    default:
                    case "Unbuildable":
                        mode = CommonAccessibles.Mode.COMMAND;
                        break;

                }
            }
        }

    }

}
