using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public bool IsAlive { get; set; }

	// Use this for initialization
	public virtual void Start () {
        IsAlive = true;
	}

    public virtual void destroy() {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

		
	}


}
