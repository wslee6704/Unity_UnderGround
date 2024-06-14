using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpMoveYup : MonoBehaviour
{
    public GameObject right, down, left;
    PlayerMove Player; //플레이어무브의 함수 참조
    Vector2 startPos, finishPos;
    Rigidbody2D rb;
    float xCount = 0, yCount = 0;
    int difYcount = 0;
    // Use this for initialization
    void Start()
    {



    }

    private void OnEnable()
    {

        rb = this.GetComponent<Rigidbody2D>();//플레이어의 강체받아오기
        GameObject _Player = GameObject.Find("player_ui") as GameObject;//플레이어 오브젝트 찾기
        Player = _Player.GetComponent<PlayerMove>();//플레이어의 무브 함수 참조
        startPos = this.gameObject.transform.position;//플레이어의 이동 전 위치
        xCount = 0;
        yCount = 0;
        finishPos = startPos;

        Debug.Log(Player.difY);
        difYcount = Player.difY;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (difYcount > 0)
        {
            if (yCount == 0)
            {
                startPos = finishPos;
                finishPos.y += 1.0f;
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
                difYcount--;
                if (difYcount <= 0)
                {
                    startPos = finishPos;
                    finishPos.x += Player.difX;
                }
            }
        }
        else
        {
            xCount += Time.deltaTime * 10;
            this.gameObject.transform.position = Vector3.Lerp(startPos, finishPos, xCount);
            if (xCount >= 1)
            {
                Player.right.SetActive(!Player.right.active);
                Player.left.SetActive(!Player.left.active);
                Player.down.SetActive(!Player.down.active);
                rb.gravityScale = 1;
                this.gameObject.GetComponent<helpMoveYup>().enabled = false;
            }
        }


    }
}
