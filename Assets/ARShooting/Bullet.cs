using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �¾ �� �չ������� ���� ���ϰ�ʹ�.
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
