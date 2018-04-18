using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject pooledObj;
    public Stack<GameObject> pool;

    public int poolSize;

    // Spawns prefabs, adds to stack, assigns parent
    void Start()
    {
        pool = new Stack<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject spawenedObj = Instantiate(pooledObj);
            spawenedObj.GetComponent<PooledObject>().myPool = this;

            spawenedObj.transform.SetParent(transform);

            spawenedObj.SetActive(false);
            pool.Push(spawenedObj);
        }
    }

    public GameObject getObj()
    {
        if (pool.Count > 0)
        {
            GameObject poppedObj = pool.Pop();
            poppedObj.transform.SetParent(null);

            return pool.Pop();
        }
        else
        {
            poolSize *= 2;
            for (int i = 0; i < poolSize; i++)
            {
                GameObject spawenedObj = Instantiate(pooledObj);
                spawenedObj.transform.SetParent(transform);

                spawenedObj.SetActive(false);
                pool.Push(spawenedObj);
            }
            Debug.Log("Pool was empty. Expanded size.");
            GameObject poppedObj = pool.Pop();
            poppedObj.transform.SetParent(null);

            return pool.Pop();
        }
    }

}
