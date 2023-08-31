using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJH_Target : MonoBehaviour
{
    AudioSource audioSource01;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (audioSource01 == null)
            audioSource01 = GetComponent<AudioSource>();
        audioSource01.Play();
        print("과녁 맞추는 소리 : " + audioSource01.name);
    }

}
