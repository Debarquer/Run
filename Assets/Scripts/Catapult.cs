using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.transform.name);
        if (other.transform.tag == "Player")
        {
            Debug.Log("Hit Player");
            StartCoroutine(CannonizePlayer(other.transform));
        }
    }

    IEnumerator CannonizePlayer(Transform t)
    {
        Debug.Log("CannonizingPlayer");

        Vector3 startPos = t.position;
        Vector3 endPos = new Vector3(startPos.x, startPos.y, startPos.z + 55);

        for (float i = 0; i < 1; i += Time.deltaTime/2)
        {
            Debug.Log("Looping");

            t.position = Vector3.Lerp(startPos, endPos, i);

            yield return null;
        }
    }
}
