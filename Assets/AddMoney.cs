using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMoney : MonoBehaviour
{
    [SerializeField]
    private GameObject twoHundered;
    [SerializeField]
    private GameObject hundred;
    int Iflag;
    GameObject newTwoHundered;
    GameObject newHundered;
    GameObject bal;
    GameObject buf;
    GameObject buf2;


    public GameObject balance;
    public GameObject newBalance;
    public GameObject buffer;
    public GameObject newBuffer;

    void Awake()
    {
        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        transform.Rotate(90, 0, 0);
        Iflag = 0;

        newHundered = Instantiate(hundred, this.transform.position, this.transform.rotation);

        newTwoHundered = Instantiate(twoHundered, Vector3.zero, Quaternion.identity);
        newTwoHundered.SetActive(false);
        bal = Instantiate(balance, this.transform.position, this.transform.rotation);
        buf = Instantiate(buffer, this.transform.position, this.transform.rotation);
        buf2 = Instantiate(newBuffer, this.transform.position, this.transform.rotation);
        buf.SetActive(true);
        buf2.SetActive(false);
    }

    private void Update()
    {
        newHundered.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        collisionInfo.gameObject.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
        if (Iflag == 0)
        {
            newTwoHundered.SetActive(true);
            newHundered.SetActive(false);
            newTwoHundered.transform.position = collisionInfo.gameObject.transform.position;
            /*newTwoHundered.transform.Translate(0.1f, 0.1f, 0.1f);*/
            newTwoHundered.transform.rotation = collisionInfo.gameObject.transform.rotation;
            
            Iflag = Iflag + 1;
            buf.SetActive(false);
            buf2.SetActive(true);
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        newTwoHundered.SetActive(false);
        newHundered.SetActive(true);
        collisionInfo.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        Iflag = Iflag - 1;
        buf.SetActive(true);
        buf2.SetActive(false);
    }
}
