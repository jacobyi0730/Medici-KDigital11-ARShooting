using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 나를 생성한 EnemyManager 를 기억하고싶다.
    public EnemyManager enemyManager;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.gameObject;
    }

    float speed = 1;
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
        transform.forward = dir;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 상대가 Bullet이라면
        if (collision.gameObject.name.Contains("Bullet"))
        {
            // 너죽고 나죽고 하고싶다.
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (enemyManager != null)
        {
            enemyManager.OnMyDestroyed(this);
        }
    }
}
