using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool myPool;
    float timer = 0;
    public float timeLimmit = 5;

    public void returnToPool()
    {
        gameObject.SetActive(false);
        transform.parent = myPool.transform;
        myPool.pool.Push(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= timeLimmit)
        {
            timer = 0;
            returnToPool();
        }

    }

}
