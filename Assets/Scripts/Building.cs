using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct GivenUnitContainer
{
    public UnitItem data;
    public string key;
}

public class Building : MonoBehaviour, IDamageable
{
    public GivenUnitContainer[] givenUnits;
    public Dictionary<string,UnitItem> implamentedUnits = new Dictionary<string, UnitItem>();
    private float Hp;
    public float GetSetHp
    {
        get
        {
            return Hp;
        }
        set
        {
            Hp = value;
            if (Hp <= 0)
            {
                OnDeath();
            }
        }
    }

    private void Awake()
    {
        foreach (GivenUnitContainer given in givenUnits)
        {
            implamentedUnits.Add(given.key, given.data);
        }
    }

    // Use this for initialization
    //void Start()
    //{

    //}

    private void OnMouseDown()
    {
        CommonAccessibles.ModeState = CommonAccessibles.Mode.PRODUCTION;
        CommonAccessibles.CurrentBuilding = this;
    }

    public void ApplyTrueDamage(float damage)
    {
        GetSetHp -= damage;
    }

    void OnDeath()
    {
        Destroy(gameObject);
    }
}
