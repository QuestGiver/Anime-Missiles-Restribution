using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float timer = 0;
    public float timeLimmit = 5;



    public float damage;
    public bool isPlayersBullet = true;
    public float evaluationScale = 4;
    public float speed = 10;

    public float deviation = 1;

    Vector3 deviationVect;
    public AnimationCurve curve;


    private void OnEnable()
    {
        curve.postWrapMode = WrapMode.Loop;

        deviationVect = new Vector3(Random.Range(-deviation, deviation), Random.Range(-deviation, deviation), Random.Range(-deviation, deviation));
        //myPool = FindObjectOfType<ObjectPool>();

    }
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        float offset = curve.Evaluate(Time.time / evaluationScale);
        Debug.Log(offset);
        if (timer >= timeLimmit)
        {
            timer = 0;
        }
        transform.Translate(((Vector3.forward + deviationVect) + (Vector3.right * offset)) * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward, 360 * Time.deltaTime, Space.Self);

    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    timer = 0;
    //    returnToPool();
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (isPlayersBullet)
        {
            if (collision.collider.tag == "Enemy")
            {
                collision.collider.gameObject.GetComponent<Unit>().ApplyTrueDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
