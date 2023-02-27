using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 태어날 때 앞방향으로 힘을 가하고싶다.
public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float force = 5;
    // Start is called before the first frame update
    void Start()
    {
        print("Bullet.Start");
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = rb.velocity;  
    }

   
}
