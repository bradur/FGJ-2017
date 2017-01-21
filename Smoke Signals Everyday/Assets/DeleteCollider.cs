using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PuffWave")
        {
            PuffWave pw = collision.gameObject.GetComponent<PuffWave>();
            PuffPool.main.DestroyPuff(pw);
        }
    }
}
