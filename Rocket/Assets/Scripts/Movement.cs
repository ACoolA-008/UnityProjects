using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audioSource;
    bool isAlive;

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

      // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
           rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
           if(!audioSource.isPlaying)
           {
                audioSource.PlayOneShot(mainEngine); 
           }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotationThrust); 
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //Manually rotate by freezing systematic rotations.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //Unfreeze rotations, recover physical rotation.
    }
}
