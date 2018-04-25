﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    public delegate void CreateBuilding();
    CreateBuilding create;
    int selectedBuilding;

    public GameObject buildArea;

   // public float PlaceRate;
    public Camera cam;
    //float timer;
    public BuildingItem[] buildingItems;

    // Use this for initialization
    void Start()
    {
        //timer = PlaceRate;
        buildArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (create != null)
        {
            create();
        }

    }


    void BuildProccess()
    {
        //timer += Time.deltaTime;
        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 200, Color.yellow);

        if (Physics.Raycast(ray, out hit, 200,0,QueryTriggerInteraction.Ignore))
        {

            //show build area
            buildArea.transform.position = hit.point;
            if (!buildArea.activeInHierarchy)
            {
                buildArea.SetActive(true);
            }




            if (Input.GetMouseButtonDown(1))
            {
                //if (timer >= PlaceRate)
                //{
                if (hit.collider.tag != "tower" && hit.collider.tag != "Enemy")
                {
                    buildArea.SetActive(false);
                    GameObject newBuilding = Instantiate(buildingItems[selectedBuilding].structure, hit.point, new Quaternion(0, 0, 0, 0));
                    CommonAccessibles.mode = CommonAccessibles.Mode.COMMAND;                  
                    create -= BuildProccess;
                    // timer = 0;
                }

                //}
            }

        }
    }

    public void OnSelectedBuilding(int value)
    {
        create += BuildProccess;
        selectedBuilding = value;
    }

}