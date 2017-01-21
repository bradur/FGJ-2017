using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wave")
        {
            GameObject waveCollider = collision.gameObject;
            Transform waveObject = waveCollider.transform.parent;
            PuffWave puffWave = waveObject.parent.GetComponent<PuffWave>();
            puffWave.IsMoving = false;
            puffWave.transform.SetParent(WorldManager.main.WorldParent, true);

            LevelManager.main.NextObject();
            //TODO: WorldManager kutsu että player voi liikkua
            WorldManager.main.SetPlayerMovement(true);
        }
    }
}
