﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VirtualUnit : MonoBehaviour, IDamageable
{

    [SerializeField]
    protected float RateOfFire;//Bullets per second
    public ObjectPool pool;
    protected float timer = 0;
    protected float altitude;

    //private List<GameObject> detectedEnemies;
    protected GameObject mainEnemy;
    protected bool hasNoTarget = true;

    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float attackRange;

    public NavMeshAgent agent;

    protected Vector3 destination;
    public Vector3 GetSetDestination
    {
        get
        {
            return destination;
        }

        set
        {
            destination = value;
            OnDestinationChange(destination);
        }
    }

    protected float hp;
    public float GetSetHp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
            if (hp <= 0)
            {
                OnDeath();
            }
        }
    }

    protected virtual void OnDestinationChange(Vector3 value)
    {
        agent.destination = destination;
    }

    protected void Awake()
    {
        pool = FindObjectOfType<ObjectPool>();
    }

    // Use this for initialization
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = 1 / RateOfFire;
        agent.baseOffset = altitude;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer += Time.deltaTime;


        if (hasNoTarget == true)
        {
            foreach (Collider item in Physics.OverlapSphere(transform.position, attackRange,5))
            {
                if (item.transform.tag == "Enemy")
                {
                    if (item.gameObject.activeInHierarchy)
                    {
                        mainEnemy = item.gameObject;
                        hasNoTarget = false;
                    }
                }
            }
        }

        if (mainEnemy != null)
        {
            if (!mainEnemy.activeInHierarchy)
            {
                hasNoTarget = true;
            }
        }




        if (hasNoTarget == false)
        {
            if (timer >= 1 / RateOfFire)
            {
                FireGun();
                timer = 0;
            }
        }
    }

    protected void FireGun()
    {
        GameObject bullet = pool.getObj();
        bullet.GetComponent<BulletScript>().damage = damage;
        bullet.GetComponent<BulletScript>().isPlayersBullet = true;
        bullet.transform.rotation = transform.rotation;
        bullet.transform.Rotate(Vector3.forward, Random.Range(-180, 180), Space.Self);
        bullet.transform.position = transform.position + (transform.forward * 2);
        bullet.SetActive(true);
    }

    public virtual void ApplyTrueDamage(float damage)
    {
        GetSetHp -= damage;
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }

}
