using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간마다 적 공장에서 적을 생성하고싶다.
// 만약 하나 만들었다면 그녀석이 파괴될 때 까지는 안만들고싶다.
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
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 2. 현재시간이 생성시간이 되면
        if (currentTime > makeTime)
        {
            // 3. 적을 생성할 수 있다면
            if (count < maxCount)
            {
                // 4. 적 카운트를 1 증가하고싶다.
                count++;
                // 5. 적 공장에서 적을 만들어서
                GameObject enemy = Instantiate(enemyFactory);

                Enemy enemyComp = enemy.GetComponent<Enemy>();
                enemyComp.enemyManager = this;
                if (false == makeList.Contains(enemyComp))
                {
                    makeList.Add(enemyComp);
                }

                // 6. 랜덤한 위치에 배치하고싶다.
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
        // 파괴된 enemy가 내가 만든 목록에 있는가?
        if (makeList.Contains(enemy))
        {
            // 생성 카운트를 하나 감소시키고
            count--;
            makeList.Remove(enemy);
        }

    }
}
