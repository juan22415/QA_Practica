using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemmyFollow : MonoBehaviour {

    public GameObject target; 
    public float moveSpeed = 2; 
    public float rotationSpeed = 2; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

    }
}
