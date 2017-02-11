using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

    public Rigidbody rb;
    public float speed = 5;
    public float angularSpeed = 1;
    public ParticleSystem laser;
    private ParticleSystem.EmissionModule em;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        em = laser.emission;
        em.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        float vx = (Input.GetKey(KeyCode.A) ? -1 : 1) + (Input.GetKey(KeyCode.D) ? 1 : -1);
        float vy = (Input.GetKey(KeyCode.S) ? -1 : 1) + (Input.GetKey(KeyCode.W) ? 1 : -1);
        float wx = (Input.GetKey(KeyCode.LeftArrow) ? -1 : 1) + (Input.GetKey(KeyCode.RightArrow) ? 1 : -1);
        float wy = (Input.GetKey(KeyCode.DownArrow) ? -1 : 1) + (Input.GetKey(KeyCode.UpArrow) ? 1 : -1);
        double theta = rb.rotation.eulerAngles[1] * Math.PI / 180; // radians
        double phi = rb.rotation.eulerAngles[2];
        float outputX = vy * (float)Math.Sin(theta) + vx * (float)Math.Cos(theta);
        float outputY = vy * (float)Math.Cos(theta) + vx * (float)Math.Sin(theta);
        Vector3 movement = new Vector3(outputX, 0.0f, outputY);
        Vector3 turn = new Vector3(-wy*(float)Math.Cos(theta), wx, wy*(float)Math.Sin(theta));

        rb.velocity = (movement * speed);
        rb.angularVelocity = (turn * angularSpeed);
        if(Input.GetKey(KeyCode.Space)) {
            em.enabled = true;
        } else {
            em.enabled = false;
        }
    }
}
