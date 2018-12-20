using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [Header("Tuning")]
    [Tooltip("Default: 0.75")] public float alignSpeed;
    [Tooltip("Default: 5")] public float moveSpeed;


    GameObject model;
    NavMeshAgent agent;
    Transform target;

    void Start() {
        model = this.gameObject.transform.GetChild(0).gameObject;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = moveSpeed;
    }

    void Update() {
        agent.destination = target.position;
        model.transform.position = new Vector3(model.transform.position.x, Mathf.Lerp(model.transform.position.y, target.position.y, alignSpeed * Time.deltaTime), model.transform.position.z);
    }
    public void UpdateSpeed(float speed)
    {
        agent.speed = speed;
    }
    public void ResetSpeed()
    {
        agent.speed = moveSpeed;
    }
}