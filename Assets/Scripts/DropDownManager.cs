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
        dropDown.onValueChanged.AddListener(delegate{OnModeChange();});//when an option in the dropdown menu is selected
        //interaction.action += OnModeChange;
    }

    void OnDropdownValueChanged(Dropdown change)//run external function
    {
        dropDown.Hide();
        modeDependentFunction(change.value);

    }


    public void ExcuteModeFunction()
    {
        modeDependentFunction(dropDown.value);
    }

    public void OnModeChangeUpdateDropDown()//prepares the dropdown menue for the player before an option is chosen by the player
    {       
        dropDown.ClearOptions();
        options.Clear();
        modeDependentFunction = null;
        switch (CommonAccessibles.mode)
        {

            case CommonAccessibles.Mode.BUILD:

                for (int i = 0; i < buildingPlacement.buildingItems.Length; i++)
                {
                    options.Add(buildingPlacement.buildingItems[i].name);
                }
                modeDependentFunction += buildingPlacement.OnSelectedBuilding;
                dropDown.AddOptions(options);
                dropDown.Show();
                

                break;

            case CommonAccessibles.Mode.PRODUCTION:
                CommonAccessibles.mode = CommonAccessibles.Mode.COMMAND;//temporary
                break;
            default:
            case CommonAccessibles.Mode.COMMAND:
                
                break;
        }

    }

}
