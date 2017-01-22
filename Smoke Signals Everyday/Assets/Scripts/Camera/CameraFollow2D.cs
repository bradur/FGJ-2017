// Date   : 21.01.2017 01:38
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

public class CameraFollow2D : MonoBehaviour {

    [SerializeField]
    private bool allowVerticalFollow = true;
    [SerializeField]
    private bool allowHorizontalFollow = true;

    [SerializeField]
    [Range(-10f, 10f)]
    private float horizontalOffsetX = 0f;

    [SerializeField]
    [Range(-10f, 10f)]
    private float horizontalOffsetY = 0f;

    [SerializeField]
    private Transform target;

    void Update () {
        float x = allowHorizontalFollow ? target.position.x + horizontalOffsetX : transform.position.x;
        float y = allowVerticalFollow ? target.position.y + horizontalOffsetY : transform.position.y;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
