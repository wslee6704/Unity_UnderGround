using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float countExample = 0;
    Vector2 EnemyPos;//플레이어 위치를 일일이 써주면 더러워져서 지정
    public GameObject _helpMove;//플레이어의 이동을 도와주는 객체를 복사하기 위해 선언   
    GameObject helpMove;
    blockMakerTwo Maker;//블럭 배열 참조해주려고 쓰는 함수
    Vector2 Destination;//자기가 가는 블럭의 목적지 지정
    public int difX, difY;//목적지와의 차이를 지정해줘서 얼마만큼 갈지 만들어줌
    int nowX = 2;
    int nowY = 0;
    public GameObject right, left, down;
    public GameObject colideBlock;//블럭의 정보를 확인하고 부수기 위해서
    public int blockFiber = 0;
    public bool blockColide = false;//플레이어랑 블럭이 닿아있는지 확인

    private void Awake()
    {

    }

    void Start()
    {
        Maker = GameObject.Find("player_ui").GetComponent<blockMakerTwo>();

    }
    void Update()
    {
        if (countExample < 3)
        {
            countExample += Time.deltaTime;
        }
        else
        {
            Debug.Log("Move! now!");
            int ran = Random.Range(0, 10);
            
            if (ran % 2 == 0) moveRight();
            else moveLeft();

            countExample = 0;
        }
    }

    public void moveRight()
    {

        EnemyPos = this.gameObject.transform.position;



        if (nowX < 5)//플레이어가 6번째 블럭에 서있으면 오른쪽으로 갈 수 없으므로
        {
            nowX++;
            
            for (int i = 0; i < Maker.Block.Count; i++)
            {
                if (Maker.Block[i][nowX] != null)
                {

                    Destination = Maker.Block[i][nowX].gameObject.transform.position;//가장 높은 곳이 가야할 곳이므로 목적지로 지정한다.
                    difX = 1;
                    difY = (int)Maker.Block[i][nowX].gameObject.transform.position.y - (int)(EnemyPos.y - 1.515f);//무조건 소수점에서 내림이 되기 때문에
                    if (difY > 0)
                    {

                    }
                    else if (difY <= 0)
                    {
                        
                        this.gameObject.GetComponent<EnemyMoveDown>().enabled = true;
                    }
                    
                    
                    break;
                }
            }
        }

    }
    public void moveLeft()
    {

        EnemyPos = this.gameObject.transform.position;

        if (nowX > 0)//플레이어가 1번째 블럭에 서있으면 오른쪽으로 갈 수 없으므로
        {
            nowX--;
            for (int i = 0; i < Maker.Block.Count; i++)
            {
                if (Maker.Block[i][nowX] != null)
                {
                    Destination = Maker.Block[i][nowX].gameObject.transform.position;//가장 높은 곳이 가야할 곳이므로 목적지로 지정한다.
                    difX = -1;
                    difY = (int)Maker.Block[i][nowX].gameObject.transform.position.y - (int)(EnemyPos.y - 1.515f);
                    if (difY > 0)
                    {

                    }
                    else if (difY <= 0)
                    {
                        this.gameObject.GetComponent<EnemyMoveDown>().enabled = true;
                    }
                    
                    
                    break;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            blockColide = true;
            Debug.Log(collision.gameObject.transform.position);
            colideBlock = collision.gameObject;

            blockFiber = 50 - (int)collision.gameObject.transform.position.y;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        float grScale = this.GetComponent<Rigidbody2D>().gravityScale;
        if (collision.gameObject.tag == "Block" && grScale != 0)
        {
            blockColide = false;
        }
    }
}












