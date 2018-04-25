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
        CommonAccessibles.mode = CommonAccessibles.Mode.COMMAND;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CommonAccessibles.mode != CommonAccessibles.Mode.PRODUCTION || CommonAccessibles.mode != CommonAccessibles.Mode.BUILD)
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
                        CommonAccessibles.mode = CommonAccessibles.Mode.BUILD;

                        break;
                    case "Building":
                        CommonAccessibles.mode = CommonAccessibles.Mode.PRODUCTION;
                        break;
                    default:
                    case "Unbuildable":
                        CommonAccessibles.mode = CommonAccessibles.Mode.COMMAND;
                        break;

                }
            }
 

    }

}
