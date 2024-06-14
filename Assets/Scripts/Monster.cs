using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    IEnumerator MonstersMove()
    {
        while (true)
        {
            float ran = Random.Range(5, 10);

            yield return new WaitForSeconds(ran);
           // layActive = true;
          //  yield return StartCoroutine(Caution());
          //  yield return new WaitForSeconds(1.0f);
           // yield return StartCoroutine(LayShoot());
            
        }
    }

   
}
