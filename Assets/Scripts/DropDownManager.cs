using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DropDownManager : MonoBehaviour
{

    public delegate void receptacleFunction(string value);

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

        string[] names = ReturnNameArray(buildingPlacement.implamentedBuildings);
        for (int i = 0; i < buildingPlacement.implamentedBuildings.Count; i++)
        {
            dropDown.options.Add(new Dropdown.OptionData(names[i]));//[i].text = buildingPlacement.buildingItems[i].name;
        }


        CommonAccessibles.OnModeChange += OptionTextChange;
        dropDown.onValueChanged.AddListener(
                                                delegate
                                                        {
                                                            if (modeDependentFunction != null)
                                                            {
                                                                modeDependentFunction(dropDown.options[dropDown.value].text);
                                                            }
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
                string[] names = ReturnNameArray(buildingPlacement.implamentedBuildings);

                for (int i = 0; i < names.Length; i++)
                {
                    dropDown.options.Add(new Dropdown.OptionData(names[i]));
                }
                dropDown.Show();
                break;
            case CommonAccessibles.Mode.PRODUCTION:


                string[] unames = ReturnNameArray(CommonAccessibles.CurrentBuilding.implamentedUnits);

                for (int i = 0; i < CommonAccessibles.CurrentBuilding.implamentedUnits.Count; i++)
                {
                    dropDown.options.Add(new Dropdown.OptionData(unames[i]));
                }
                dropDown.Show();
                break;
            default:
            case CommonAccessibles.Mode.COMMAND:

                break;
        }
    }

    public string[] ReturnNameArray<T>(Dictionary<string,T> val)
    {
        string[] names = new string[val.Count];
        int x = 0;
        foreach (string item in val.Keys)
        {
            names[x] = item;
            x++;
        }
        return names;
    }


}




