using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Transform target;

    [Header("Tuning")]
    [Tooltip("Affects Rotation Speed. (Default = 3)")] public float rotSpeed = 3.0f;
    [Tooltip("Affects Movement Speed. (Default = 5)")] public float moveSpeed = 3.0f;

    // Use this for initialization
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        FollowPlayer();
    }

    private void FollowPlayer() {
        transform.rotation = Quaternion.Slerp(
            transform.rotation, 
            Quaternion.LookRotation(target.position - transform.position), 
            rotSpeed * Time.deltaTime
        );

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
