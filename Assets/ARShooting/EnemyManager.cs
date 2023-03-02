using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ð����� �� ���忡�� ���� �����ϰ�ʹ�.
// ���� �ϳ� ������ٸ� �׳༮�� �ı��� �� ������ �ȸ����ʹ�.
public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory;
    float currentTime;
    float makeTime = 1;
    public int maxCount = 1;
    int count;
    List<Enemy> makeList;
    // Start is called before the first frame update
    void Start()
    {
        makeList = new List<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. �ð��� �帣�ٰ�
        currentTime += Time.deltaTime;
        // 2. ����ð��� �����ð��� �Ǹ�
        if (currentTime > makeTime)
        {
            // 3. ���� ������ �� �ִٸ�
            if (count < maxCount)
            {
                // 4. �� ī��Ʈ�� 1 �����ϰ�ʹ�.
                count++;
                // 5. �� ���忡�� ���� ����
                GameObject enemy = Instantiate(enemyFactory);

                Enemy enemyComp = enemy.GetComponent<Enemy>();
                enemyComp.enemyManager = this;
                if (false == makeList.Contains(enemyComp))
                {
                    makeList.Add(enemyComp);
                }

                // 6. ������ ��ġ�� ��ġ�ϰ�ʹ�.
                Vector3 origin = Camera.main.transform.position;

                Vector3 randDir = Random.insideUnitSphere.normalized;

                randDir.y = 0;

                Vector3 newPosition = origin + randDir * Random.Range(5, 10);

                enemy.transform.position = newPosition;
            }
        }
    }

    internal void OnMyDestroyed(Enemy enemy)
    {
        // �ı��� enemy�� ���� ���� ��Ͽ� �ִ°�?
        if (makeList.Contains(enemy))
        {
            // ���� ī��Ʈ�� �ϳ� ���ҽ�Ű��
            count--;
            makeList.Remove(enemy);
        }

    }
}
