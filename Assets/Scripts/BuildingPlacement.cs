using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GivenBuildingContainer
{
    public BuildingItem data;
    public string key;
}

public class BuildingPlacement : VirtualStateFunction
{
    public delegate void CreateBuilding();
    CreateBuilding create;
    string selectedBuilding;

    public GameObject buildArea;

   // public float PlaceRate;
    public Camera cam;
    //float timer;
    public GivenBuildingContainer[] givenBuildings;

    public Dictionary<string, BuildingItem> implamentedBuildings = new Dictionary<string, BuildingItem>();


    // Use this for initialization

    private void Awake()
    {
        
        for (int i = 0; i < givenBuildings.Length; i++)
        {
            implamentedBuildings.Add(givenBuildings[i].key, givenBuildings[i].data);
        }
    }

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


    public override void ModeManagerResponceHandler(string val)
    {
        selectedBuilding = implamentedBuildings[val].name;
        create += BuildProccess;
    }


    void BuildProccess()
    {
        //timer += Time.deltaTime;
        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 200, Color.yellow);

        if (Physics.Raycast(ray, out hit, 200.0f,5))
        {

            //show build area
            buildArea.transform.position = hit.point;
            if (!buildArea.activeInHierarchy)
            {
                buildArea.SetActive(true);
            }




            if (Input.GetMouseButtonDown(0))
            {
                //if (timer >= PlaceRate)
                //{
                if (hit.collider.tag != "tower" && hit.collider.tag != "Enemy")
                {
                    buildArea.SetActive(false);
                    GameObject newBuilding = Instantiate(implamentedBuildings[selectedBuilding].structure, hit.point, new Quaternion(0, 0, 0, 0));
                    CommonAccessibles.ModeState = CommonAccessibles.Mode.COMMAND;                  
                    create = null;
                    // timer = 0;
                }

                //}
            }

        }
    }


}
