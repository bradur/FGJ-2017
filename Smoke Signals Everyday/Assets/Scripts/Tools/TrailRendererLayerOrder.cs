// Date   : 21.01.2017 01:23
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailRendererLayerOrder : MonoBehaviour {

    [SerializeField]
    private TrailRenderer trailRenderer;

    [SerializeField]
    [Range(-100, 100)]
    private int order = 10;

    void Start () {
        trailRenderer.sortingOrder = order;
    }

    public void Reset()
    {
        trailRenderer.Clear();
    }
}
