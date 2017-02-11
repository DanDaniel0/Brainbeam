using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehavior : MonoBehaviour {
    public float trigger_distance;
    public float trigger_delay;
    public float speed;
    public float kill_time;
    public GameObject player; // use tags
    bool has_started_moving = false;
    int time = 0;
    float curTime;
    private Rigidbody rb;
    public float initial_angle;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    public void is_shot(float delay)
    {
        Destroy(gameObject, 0.25f + delay);
    }
	// Update is called once per frame
	void Update () {
        curTime = Time.time;
		if (-player.transform.position.x + transform.position.x <= trigger_distance)
        {
            has_started_moving = true;
        }

        if (has_started_moving)
        {
            print("gah");
            rb.velocity = (new Vector3((float)Math.Cos(initial_angle*Math.PI/180), 0, (float)Math.Sin(initial_angle * Math.PI / 180))) * speed;
            Destroy(gameObject, kill_time);
        }

	}
}
