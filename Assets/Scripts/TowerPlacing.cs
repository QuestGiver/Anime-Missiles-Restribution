using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacing : MonoBehaviour
{
    float timer;
    public Camera cam;
    public float PlaceRate;
    [SerializeField]
    public GameObject[] Towers;

    // Use this for initialization
    void Start()
    {
        timer = PlaceRate;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 200, Color.yellow);


        if (Physics.Raycast(ray, out hit, 200))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (timer >= PlaceRate)
                {
                    if (hit.collider.tag != "tower" && hit.collider.tag != "Enemy")
                    {
                        GameObject newTower = Instantiate(Towers[0], hit.point, new Quaternion(0, 0, 0, 0));
                        timer = 0;
                    }

                }
            }

        }



    }
}
