using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class EnemyMoveDown : MonoBehaviour
{
    EnemyMove Enemy; //플레이어무브의 함수 참조
    Vector2 startPos, finishPos;
    Rigidbody2D rb;
    float xCount = 0, yCount = 0;
    int difYcount = 0;
    Stopwatch sw = new Stopwatch();
    // Use this for initialization
    void Start()
    {



    }

    private void OnEnable()
    {
        rb = this.GetComponent<Rigidbody2D>();//플레이어의 강체받아오기
        GameObject _Enemy = this.gameObject;//플레이어 오브젝트 찾기
        Enemy = _Enemy.GetComponent<EnemyMove>();//플레이어의 무브 함수 참조
        startPos = this.gameObject.transform.position;//플레이어의 이동 전 위치
        xCount = 0;
        yCount = 0;
        finishPos = startPos;
        finishPos.x += Enemy.difX;//먼저 옆으로 옮긴뒤 내려가야 하므로 현재위치에 가야되는 x만큼만 더해줌
        Debug.Log(Enemy.difY);
        difYcount = Enemy.difY;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (xCount < 1)
        {//x를 먼저 움직일 것이므로
            xCount += Time.deltaTime * 10;//
            this.gameObject.transform.position = Vector3.Lerp(startPos, finishPos, xCount);
        }
        else if (xCount >= 1)
        {
            if (difYcount < 0)
            {
                if (yCount == 0)
                {
                    startPos = finishPos;
                    finishPos.y -= 1.0f;
                    yCount += Time.deltaTime * 15;
                }
                else if (yCount < 1)
                {
                    yCount += Time.deltaTime * 15;
                    this.gameObject.transform.position = Vector3.Lerp(startPos, finishPos, yCount);
                }
                else if (yCount >= 1)
                {
                    yCount = 0;
                    difYcount++;
                }
            }
            else
            {
                
                rb.gravityScale = 1;
                this.gameObject.GetComponent<EnemyMoveDown>().enabled = false;
            }

        }
    }
}

