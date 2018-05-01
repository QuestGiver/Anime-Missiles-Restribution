using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownManager : MonoBehaviour
{
    public delegate void receptacleFunction(int value);
    public receptacleFunction modeDependentFunction;//functions added to delegate by external class;
    public BuildingPlacement buildingPlacement;
    public Dropdown dropDown;
    public Text modeText;

    public List<string> options;
    
    // Use this for initialization
    void Start()
    {
        dropDown.options.Clear();
        dropDown.Hide();
        for (int i = 0; i < buildingPlacement.buildingItems.Length; i++)
        {
            dropDown.options.Add(new Dropdown.OptionData(buildingPlacement.buildingItems[i].name));//[i].text = buildingPlacement.buildingItems[i].name;
        }
        CommonAccessibles.OnModeChange += OptionTextChange;
        dropDown.onValueChanged.AddListener(
                                                delegate
                                                        {
                                                            modeDependentFunction(dropDown.value);
                                                                    Debug.Log(dropDown.value);
                                                        }
                                           );
        Debug.Log(dropDown.value);


    }

    

    public void OptionTextChange(CommonAccessibles.Mode value)
    {
        dropDown.options.Clear();
        switch (value)
        {
            case CommonAccessibles.Mode.BUILD:
                for (int i = 0; i < buildingPlacement.buildingItems.Length; i++)
                {
                    dropDown.options.Add(new Dropdown.OptionData(buildingPlacement.buildingItems[i].name));//[i].text = buildingPlacement.buildingItems[i].name;
                }
                dropDown.Show();
                break;
            case CommonAccessibles.Mode.PRODUCTION:
                for (int i = 0; i < CommonAccessibles.CurrentBuilding.units.Length; i++)
                {
                    dropDown.options.Add(new Dropdown.OptionData(CommonAccessibles.CurrentBuilding.units[i].name));
                }
                dropDown.Show();
                break;
            default:
            case CommonAccessibles.Mode.COMMAND:

                break;
        }
    }



}




