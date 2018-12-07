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
        //StartCoroutine(SetDestination(0));
        transform.position = destinations[0].transform.position;
        transform.rotation = destinations[0].transform.rotation;

    }
    public void MoveToOptions()
    {
        transform.position = destinations[1].transform.position;
        transform.rotation = destinations[1].transform.rotation;
    }
    public void MoveToExtras()
    {
        transform.position = destinations[2].transform.position;
        transform.rotation = destinations[2].transform.rotation;
    }
    public void MoveToAbout()
    {

    }
    public void MoveToExit()
    {

    }

    IEnumerator SetDestination(int i)
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        float timeMax = Time.deltaTime + speed;
        

        while (Vector3.Distance(transform.position, destinations[i].transform.position) > 0.01f) {
            Debug.Log(("SetDestination inside loop" + (timeMax - Time.deltaTime) / speed));
            transform.position = Vector3.Lerp(startPos, destinations[i].transform.position, (timeMax - Time.deltaTime)/speed);
            transform.rotation = Quaternion.Lerp(startRot, destinations[i].transform.rotation, (timeMax - Time.deltaTime) / speed);
            yield return new WaitForSeconds(0.1f);
            
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
