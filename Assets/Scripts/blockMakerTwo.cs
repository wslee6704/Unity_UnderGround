using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMakerTwo : MonoBehaviour
{
    public List<GameObject[]> Block = new List<GameObject[]>();//블럭의 배열
    public GameObject _block = null, _bomb = null;
    int lowestY;//이 블럭에서 가장 낮은 블럭의 Y값
    public Vector2 highest = new Vector2(0,0);

    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            Block.Add(new GameObject[6]);//블럭 배열 추가 하는 함수
            for (int j = 0; j < 6; j++)
            {
                int ran = UnityEngine.Random.Range(0, 100);
                if (ran % 20 == 0)
                {
                    Block[i][j] = GameObject.Instantiate(_bomb);
                }
                else
                {
                    Block[i][j] = GameObject.Instantiate(_block);
                }
                Block[i][j].transform.position = new Vector2(j, -i);
            }
            lowestY = -i;//블럭배열의 가장 낮은 수 설정
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DeleteBlockArray()
    {
        for (int i = 0; i < Block.Count; i++)
        {
            int delaycount = 0;//6개가 다 없는지 확인하는 변수
            for (int j = 0; j < 6; j++)
            {
                if (Block[i][j] != null) break;//null이 아닐때는 굳이 더 확인할 필요 X
                else if (Block[i][j] == null) delaycount++;//비어있을 때는 카운트
            }
            if (delaycount == 6)//for문을 벗어난 후 카운트가 6이면 다 비어있으므로 배열 삭제
            {
                Block.RemoveAt(i);
            }
        }
    }//블럭이 다 비어있을 때 쓸모없는 걸 지워줄려고 추가하는 함수


    public void NeedMoreBlock()//가장낮은 블럭이 플레이와 가까워졌을때 블럭을 추가하는 함수
    {
        
        if (this.gameObject.transform.position.y - lowestY <= 10)
        {
            lowestY--;//y의 값을 더 내려서 추가되는 블럭의 Y좌표 지정
            Block.Add(new GameObject[6]);//블럭 배열 추가 하는 함수
            for (int j = 0; j < 6; j++)
            {
                int ran = UnityEngine.Random.Range(0, 100);
                if (ran % 20 == 0)
                {
                    Block[Block.Count - 1][j] = GameObject.Instantiate(_bomb);//배열을 지울수도 있기 때문에 COunt를 쓴다
                }
                else
                {
                    Block[Block.Count - 1][j] = GameObject.Instantiate(_block);
                }
                Block[Block.Count - 1][j].transform.position = new Vector2(j, lowestY);//y위치 설정
            }
        }
    }
    public void highestBlock()
    {
        bool continue_ = false;
        for (int i = 0; i < Block.Count; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (Block[i][j] != null)
                {
                    highest = Block[i][j].gameObject.transform.position;
                    continue_ = true;
                    break;
                }
            }
            if (continue_) break;
        }
    }

    //void gravityNow()
    //{
    //    int moveDistance = 0;
    //    for (int j = 0; j < 6; j++)
    //    {
    //        for (int i = 0; i < Block.Count - 1; i++)
    //        {
    //            if (Block[i][j] == null)
    //            {
    //                moveDistance++;
    //                Block[i][j] = Block[i][j] = GameObject.Instantiate(_empty);
    //            }
    //        }
    //        //그다음에 moveDistance 반환해서 내려야할만큼의 거리획득, 그걸 내려줄 투명 오브젝트 생성
    //        //두 빈칸이 따로 존재할떄는 어떡할래
    //    }
    //}
}
