using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
   public float speed;

   public Transform[] destinations;

    private void Start()
    {
        transform.position = destinations[0].transform.position;
        transform.rotation = destinations[0].transform.rotation;
    }
    public void MoveToMainMenu()
    {
        StartCoroutine(SetDestination(0));
        //transform.position = destinations[0].transform.position;
        //transform.rotation = destinations[0].transform.rotation;

    }
    public void MoveToOptions()
    {
        StartCoroutine(SetDestination(1));
        //transform.position = destinations[1].transform.position;
        //transform.rotation = destinations[1].transform.rotation;
    }
    public void MoveToExtras()
    {
        StartCoroutine(SetDestination(2));
        //transform.position = destinations[2].transform.position;
        //transform.rotation = destinations[2].transform.rotation;
    }
    public void MoveToAbout()
    {
        StartCoroutine(SetDestination(3));
    }
    public void MoveToExit()
    {

    }

    IEnumerator SetDestination(int index)
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, destinations[index].transform.position, i);
            transform.rotation = Quaternion.Lerp(startRot, destinations[index].transform.rotation, i);

            yield return null;
        }
    }
}

//GameObject playerObj;
//public Vector3 offset;
//public float speed = 2;

//void Start()
//{
//    playerObj = GameObject.FindGameObjectWithTag("Player");
//}

//void LateUpdate()
//{
//    transform.position = Vector3.Lerp(transform.position, playerObj.transform.position + offset, speed * Time.deltaTime);
//}
