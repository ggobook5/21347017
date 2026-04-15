using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    public float spd = 1.0f;

    GameObject target;

    public GameObject prefabEx;

    Vector3 direct = Vector3.down;

    private void Start()
    {

        target = GameObject.Find("Character");

        int rndNum = Random.Range(0, 10);

        if(rndNum % 3 == 0) //3의 배수인 경우
        {
            direct = target.transform.position - transform.position;
            direct.Normalize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {

            GameObject gameManager = GameObject.Find("GameManager");
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();

            scoreManager.nowScore++;
            scoreManager.nowScoreUI.text = "Now Score : " + scoreManager.nowScore;

            if(scoreManager.nowScore > scoreManager.bestScore)
            {
                PlayerPrefs.SetInt("BestScore", scoreManager.nowScore);

                scoreManager.bestScore = scoreManager.nowScore;
                scoreManager.bestScoreUI.text = "Best Score : " + scoreManager.bestScore;
            }



            GameObject exTenmp = Instantiate(prefabEx);
            exTenmp.transform.position = transform.position;

            Destroy(collision.gameObject);

            Destroy(gameObject);


        }



    }
}
