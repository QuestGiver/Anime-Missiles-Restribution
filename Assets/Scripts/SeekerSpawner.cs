using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerSpawner : MonoBehaviour
{
    [SerializeField]
    private float RateOfFire;//Bullets per second
    public ObjectPool pool;
    float timer = 0;
    

    // Use this for initialization
    void Start()
    {
        timer = 1 / RateOfFire;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (timer >= 1/RateOfFire)
            {
                FireGun();
                timer = 0;
            }
        }
    }

    private void FireGun()
    {
        GameObject bullet = pool.getObj();
        bullet.transform.rotation = transform.rotation;
        bullet.transform.Rotate(Vector3.forward, Random.Range(-180, 180), Space.Self);
        bullet.transform.position = transform.position + (transform.forward * 2);
        bullet.SetActive(true);
    }
}
