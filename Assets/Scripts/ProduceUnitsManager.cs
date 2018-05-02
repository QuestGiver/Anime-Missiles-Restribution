using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceUnitsManager : VirtualStateFunction//Only One object per scene
{

    public override void ModeManagerResponceHandler(string val)
    {
        Instantiate(CommonAccessibles.CurrentBuilding.implamentedUnits[val].unit,CommonAccessibles.CurrentBuilding.transform);
    }
}
