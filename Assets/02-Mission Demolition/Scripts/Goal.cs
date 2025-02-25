﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class Goal : MonoBehaviour
{
	static public bool 	goalMet = false;

	void OnTriggerEnter(Collider other) {
		// when the trigger is hit by something
		// check to see if it's a Projectile 
		Projectile proj = other.GetComponent<Projectile>();
		if (proj !=null ){
			Goal.goalMet = true;
			Material mat = GetComponent<Renderer>().material;
			Color c = mat.color;
			c.a = 0.75f;
			mat.color = c;
		}
	}
}
