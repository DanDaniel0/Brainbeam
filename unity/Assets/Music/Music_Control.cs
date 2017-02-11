using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music_Control : MonoBehaviour {
	
	AudioSource audio;
	public float emoRate;

	void Update() {
		audio = GetComponent<AudioSource>();
		audio.pitch = Mathf.Clamp(1f + emoRate*SampleApp.emo, -3f, 3f);
	}


}