using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lay : MonoBehaviour
{
    public GameObject[] lay = new GameObject[6];
    public LayShot[] _LayShot = new LayShot[6];

    void Start()
    {
        for(int i = 0; i<6; i++)
        {
            _LayShot[i] = lay[i].GetComponent<LayShot>();
        }
    }


    void Update()
    {
        GameObject player = GameObject.Find("player_ui");
        Vector2 pos = player.gameObject.transform.position;
        GameObject camera = GameObject.Find("Main Camera");
        camera.gameObject.transform.position = new Vector3(2.5f, pos.y + 0.3f, -10);
    }


}
