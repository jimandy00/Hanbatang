using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJH_Arrow : MonoBehaviour
{
    // ȭ�� �ӵ�
    

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //print(rb == null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot(float n)
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
            
        rb.isKinematic = false;
        //arrow �߻�
        rb.AddForce(transform.forward * n, ForceMode.Impulse);        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
