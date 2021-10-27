using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickIt : MonoBehaviour
{
    [SerializeField]
    private GameObject sideCollider;
    [SerializeField]
    private GameObject transactions;
    int Iflag;
    GameObject side;


    private float time = 0.0f;
    public float interpolationPeriod = 0.3f;
    Vector3 x;
    Quaternion y;



    void Awake()
    {
        side = Instantiate(sideCollider, this.transform.position, this.transform.rotation);
        /*side.transform.Translate(0, 0, 0.05f);*/
        x = this.transform.position + new Vector3(0, 0, 0.05f);
        y = this.transform.rotation;
    }

    private void Update()
    {
        float step = 0.3f * Time.deltaTime;
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;
            x = this.transform.position + new Vector3(0, 0, 0.05f);
            y = this.transform.rotation;
        }

        side.transform.SetPositionAndRotation(x, y);

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == sideCollider.name)
        {
            side = Instantiate(transactions, this.transform.position, this.transform.rotation);
        }
    }

}
