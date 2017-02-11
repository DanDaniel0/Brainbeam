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
    private bool laserActivated = false;
    public float charge = 0;
    public float rechargeRate = .001f;
    public float dischargeRate = .01f;
    public float range = 312.5f;
    public Ray laserbeam;
    public RaycastHit target;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        em = laser.emission;
        em.enabled = false;
        charge = 0;
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
        if(Input.GetKey(KeyCode.Space)&&(charge>.1||charge>0&&laserActivated==true)) {
            em.enabled = true;
            laserActivated = true;
            shoot();
            charge -=dischargeRate;
            if (charge < 0) charge = 0;
        } else {
            em.enabled = false;
            laserActivated = false;
            charge += rechargeRate;
            if (charge > 1) charge = 1;
        }
    }

    // Look for targets
    public void shoot() {
        laserbeam.origin = transform.position;
        laserbeam.direction = transform.forward;
        if(Physics.Raycast(laserbeam, out target, range)) {

        }
    }
}