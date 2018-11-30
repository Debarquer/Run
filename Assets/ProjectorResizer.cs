using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projector))]
public class ProjectorResizer : MonoBehaviour {

    Projector projector;

    public float projectorMaxSize = 10;
    public float projectorMinSize = 2;
    public float maxHeight;
    public float minHeight;

	// Use this for initialization
	void Start () {
        projector = GetComponent<Projector>();
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        float distance = transform.position.y - hit.point.y;

        float max = maxHeight - minHeight;
        max = Mathf.Clamp(max, minHeight, maxHeight);

        float sizeFactor = 1/(distance / max);
        sizeFactor = Mathf.Clamp(sizeFactor, 0, 1);

        //Debug.Log(sizeFactor + " = " + distance + "/" + max);

        float size = projectorMaxSize * sizeFactor;
        size = Mathf.Clamp(size, projectorMinSize, projectorMaxSize);

        projector.orthographicSize = size;
        projector.farClipPlane = distance+0.5f;
    }
}
