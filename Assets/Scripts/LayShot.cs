using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayShot : MonoBehaviour
{
    SpriteRenderer[] spriteRenderer;
    public GameObject cautionMark;
    bool blockColide = false;
    public bool layActive = false;
    Vector2 layserPos;
    Lay layControl;
    blockMakerTwo Maker;
    Vector2 blockPos;
    int thisNum;
    void Start()
    {
        spriteRenderer = cautionMark.gameObject.GetComponents<SpriteRenderer>();
        cautionMark.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        layserPos = cautionMark.gameObject.transform.position;
        layControl = GameObject.Find("Main Camera").GetComponent<Lay>();
        StartCoroutine("LayDelay");
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        Maker = GameObject.Find("player_ui").GetComponent<blockMakerTwo>();
        thisNum = int.Parse(this.gameObject.name);//레이저의 
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LayDelay()
    {
        while (true)
        {           
            float ran = Random.Range(5, 10);
            
            yield return new WaitForSeconds(ran);
            layActive = true;
            yield return StartCoroutine(Caution());
            yield return new WaitForSeconds(1.0f);
            yield return StartCoroutine(LayShoot());
            layActive = false;                          
        }         
    }
    IEnumerator Caution()
    {
        cautionMark.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        int countTime = 0;
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer[0].color = new Color32(255, 255, 255, 45);
            }
            else spriteRenderer[0].color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.1f);
            countTime++;
        }
        cautionMark.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return null;
    }


    IEnumerator LayShoot()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 30;
        while (true)
        {
            
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
            if (blockColide == true)
            {
                
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                yield return new WaitForSeconds(0.3f);
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Maker.highestBlock();
                Debug.Log(Maker.highest.y);
                this.gameObject.transform.position = new Vector2(layserPos.x, Maker.highest.y + 14);
                blockColide = false;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                break;

            }
            yield return null;
        }
        
        
        yield return null;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Block")
        {
            
            blockColide = true;

        }
        if (collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.GetComponent<helpMoveYup>().enabled = false;
            collision.gameObject.GetComponent<helpMoveYdown>().enabled = false;
            Application.LoadLevel("GameOverScene");
            
        }
        
    }

    bool activeCount()
    {
        int count = 0;
        for(int i = 0; i < 6; i++)
        {
            if (layControl._LayShot[i].layActive == true) count++;
        }
        if (count == 5) return false;
        else return true;
    }

    
}
