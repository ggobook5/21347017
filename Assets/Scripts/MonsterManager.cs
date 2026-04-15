using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
 
    public GameObject prefabsMonster ;

    float nowTime=0.0f;
    float minTime = 1f;
    float maxTime = 5f;


    public float createTime = 1f;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        nowTime = nowTime + Time.deltaTime;

        if (nowTime > createTime)
        {

            GameObject monster = Instantiate(prefabsMonster);
            monster.transform.position = transform.position;

            //랜덤 함수로 몬스터 생성 시간 설정
            createTime = Random.Range(minTime, maxTime);

            nowTime = 0.0f;  //시간 누적 초기화
        }
    }
}
