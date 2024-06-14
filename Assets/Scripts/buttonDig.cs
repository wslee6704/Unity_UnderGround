using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class buttonDig : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    PlayerMove Player;
    bool check;
    int digPoint = 0;
    blockMakerTwo Maker;
    
    void Start () {
        Player = GameObject.Find("player_ui").GetComponent<PlayerMove>();
        Maker = GameObject.Find("player_ui").GetComponent<blockMakerTwo>();
    }
	void Update () {
        if (check&&Player.blockColide)
        {
            digPoint+=3;
        }
        else
        {
            digPoint = 0;
        }

        if (digPoint > Player.blockFiber)
        {
            Destroy(Player.colideBlock);
            digPoint = 0;
            Maker.NeedMoreBlock();
            gameManager.instance.AddScore(50);
        }
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        check = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        check = false;
    }
}
