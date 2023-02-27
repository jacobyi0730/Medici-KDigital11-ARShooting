using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 준비가 되면 공을 origin의 자식으로 놓고, 공의 물리를 끄고싶다.
public class BasketBallPlayer : MonoBehaviour
{
    public Transform origin;
    public Transform ball;
    Rigidbody ballRB;

    // Start is called before the first frame update
    void Start()
    {
        ballRB = ball.GetComponent<Rigidbody>();
    }

    public void OnMyReady()
    {
        // 나의 부모 = 너
        ball.parent = origin;
        ball.transform.localPosition = Vector3.zero;
        ball.transform.localRotation = Quaternion.identity;
        ballRB.isKinematic = true;
    }

    Vector3 firstTouchPosition;
    public float maxForce = 20;
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
           float force = maxForce * (Input.mousePosition.y - firstTouchPosition.y) / Screen.height;

            ShootBall(force);
        }

    }

    private void ShootBall(float force)
    {
        ball.parent = null;
        ballRB.isKinematic = false;
        Vector3 dir = Camera.main.transform.forward + Camera.main.transform.up;
        dir.Normalize();

        ballRB.AddForce(dir * force, ForceMode.Impulse);
    }
}
