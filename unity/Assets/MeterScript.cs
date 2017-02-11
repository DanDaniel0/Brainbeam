using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterScript : MonoBehaviour {

    private CanvasRenderer rend;
    public PlayerScript player;

	// Use this for initialization
	void Start () {
        rend = GetComponent<CanvasRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float value = player.charge;
        rend.DisableRectClipping();
        rend.EnableRectClipping(new Rect(-300,100,190*value,20));
	}
}
