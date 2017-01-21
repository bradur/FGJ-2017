using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Puff : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    
    public Sprite Sprite { get { return spriteRenderer.sprite; } set { spriteRenderer.sprite = value; } }

    public void SetSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    // Use this for initialization
    void Start () {
    }    
    // Update is called once per frame
    void Update () {
        
    }
}
