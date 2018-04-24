using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownManager : MonoBehaviour
{
    public delegate void receptacleFunction(int value);
    public receptacleFunction modeDependentFunction;//functions added to delegate by external class;
    public BuildMenu buildMenu;

    public InteractionManager interaction;

    CommonAccessibles.Mode mode;

    Dropdown dropDown;
    Text modeText;
    private List<string> options;
    
    // Use this for initialization
    void Start()
    {
        dropDown.Hide();
        dropDown.onValueChanged.AddListener(delegate{OnDropdownValueChanged(dropDown);});//when an option in the dropdown menu is selected
        interaction.action += OnModeChange;

    }

    void OnDropdownValueChanged(Dropdown change)//run external function
    {
        modeDependentFunction(change.value);
    }

    void OnModeChange()
    {
        options.Capacity = 0;
        switch (mode)
        {

            case CommonAccessibles.Mode.BUILD:

                for (int i = 0; i < buildMenu.buildingItems.Length; i++)
                {
                    options.Add(buildMenu.buildingItems[i].name);
                }
                modeDependentFunction += buildMenu.OnSelectedBuilding;
                dropDown.AddOptions(options);
                dropDown.Show();
                break;

            case CommonAccessibles.Mode.PRODUCTION:

                break;
            default:
            case CommonAccessibles.Mode.COMMAND:
                
                break;
        }

    }

}
