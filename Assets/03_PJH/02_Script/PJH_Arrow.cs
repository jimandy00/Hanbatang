using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJH_Arrow : MonoBehaviour
{
    // 화살 속도
    public float speed = 20;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
