using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    ProduceUnitsManager produceUnitsObject;
    public UnitItem[] units;
    public int Hp;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        CommonAccessibles.ModeState = CommonAccessibles.Mode.PRODUCTION;
        CommonAccessibles.CurrentBuilding = this;
    }
}
