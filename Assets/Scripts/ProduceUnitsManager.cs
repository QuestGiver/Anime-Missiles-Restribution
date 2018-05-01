using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceUnitsManager : VirtualStateFunction//Only One object per scene
{

    public override void ModeManagerResponceHandler(int val)
    {
        Instantiate(CommonAccessibles.CurrentBuilding.units[val].unit,CommonAccessibles.CurrentBuilding.transform);
    }
}
