using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class UIManager : MonoBehaviour {

    public static UIManager main;

    void Awake()
    {
        main = this;
    }

}