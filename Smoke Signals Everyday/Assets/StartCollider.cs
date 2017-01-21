using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour
{
    PuffWave collider;

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
            collider = puffWave;

            //pause the object for a moment
            puffWave.IsMoving = false;
            StartCoroutine(MoveAfterDelay());
        }
    }

    private IEnumerator MoveAfterDelay()
    {
        if(collider == null)
        {
            yield return null;
        }

        LevelManager.main.NextObject();
        yield return new WaitForSeconds(2f);

        collider.IsMoving = true;
        collider = null; //not needed anymore
        
        yield return null;
    }
}
