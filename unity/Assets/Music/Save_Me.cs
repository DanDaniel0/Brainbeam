using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Me : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
