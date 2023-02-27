using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ���� ������ EnemyManager �� ����ϰ�ʹ�.
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
        // �ε��� ��밡 Bullet�̶��
        if (collision.gameObject.name.Contains("Bullet"))
        {
            // ���װ� ���װ� �ϰ�ʹ�.
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
