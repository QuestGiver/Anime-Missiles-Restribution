using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownManager : MonoBehaviour
{
    public delegate void receptacleFunction(int value);
    public receptacleFunction modeDependentFunction;//functions added to delegate by external class;
    public BuildingPlacement buildingPlacement;

    public InteractionManager interaction;



    public Dropdown dropDown;
    public Text modeText;
    public List<string> options;
    
    // Use this for initialization
    void Start()
    {
        dropDown.Hide();
        

    }

    private void OnMouseDown()
    {
        for (int i = 0; i < buildingPlacement.buildingItems.Length; i++)
        {
            options[i] = buildingPlacement.buildingItems[i].name;
        }

        CommonAccessibles.ModeState = CommonAccessibles.Mode.BUILD;

        modeDependentFunction += buildingPlacement.OnSelectedBuilding;
    }

}
