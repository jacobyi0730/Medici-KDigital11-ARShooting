using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // 마우스 입력값을 이용해서 회전하고싶다.
    float rx, ry;
    float rotSpeed = 100;
    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        rx += my * rotSpeed * Time.deltaTime; 
        ry += mx * rotSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(-rx, ry, 0);

    }
}
