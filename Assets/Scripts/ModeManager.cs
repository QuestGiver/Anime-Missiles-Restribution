using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public DropDownManager dropDown;
    public BuildingPlacement buildingPlacement;
    public ProduceUnitsManager produceUnits;
    public CommandUnits commandUnits;

    [HideInInspector]
    public Building currentBuilding;

    // Use this for initialization
    void Start()
    {
        CommonAccessibles.OnModeChange += ModeController;
        CommonAccessibles.OnModeChange(CommonAccessibles.ModeState);
        ModeController(CommonAccessibles.ModeState);
    }

    void ModeController(CommonAccessibles.Mode val)
    {
        dropDown.modeDependentFunction = null;
        switch (CommonAccessibles.ModeState)
        {
            case CommonAccessibles.Mode.BUILD:
                dropDown.modeDependentFunction += buildingPlacement.ModeManagerResponceHandler;
                

                break;
            case CommonAccessibles.Mode.PRODUCTION:
                dropDown.modeDependentFunction += produceUnits.ModeManagerResponceHandler;

                break;
            default:
            case CommonAccessibles.Mode.COMMAND:
                dropDown.modeDependentFunction += commandUnits.ModeManagerResponceHandler;
                break;
        }
    }

}
