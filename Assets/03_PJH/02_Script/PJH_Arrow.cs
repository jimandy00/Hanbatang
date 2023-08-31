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
        
    }

    // Update is called once per frame
    void Update()
    {
        //좌클릭시 발사
        if (Input.GetButtonDown("Fire1"))
        {
            rb.isKinematic = false;
            //arrow 발사
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
