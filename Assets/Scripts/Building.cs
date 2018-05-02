using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct UnityStuff
{
    public UnitItem data;
    public string key;
}

public class Building : MonoBehaviour, IDamageable
{
    public List<UnityStuff> stuffs;
    public Dictionary<string,UnitItem> units;
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
