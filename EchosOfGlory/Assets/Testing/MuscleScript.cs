using UnityEngine;
using System.Collections;

public class MuscleScript : MonoBehaviour {

	public float acceleration = 0.1f;
	public float strength = 1; 
	public Vector3 flexedScale = new Vector3(0.25f,0.25f,0.25f);
	public Vector3 streachedScale = new Vector3(1,1,1);
	[Range(0,1)]
	public float flexedPecentage = 0.5f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = this.flexedScale * this.flexedPecentage + (1 - this.flexedPecentage) * this.streachedScale;
	}
	//TODO some sort of ramping of strength
	public float currentStrength() {
		return this.strength * ((this.flexedPecentage-0.5f)*2.0f);
	}
	public void flex() {
		this.flexedPecentage = Mathf.Min(1.0f,this.flexedPecentage + this.acceleration);
	}

	public void relax() {
		this.flexedPecentage = Mathf.Max (0.0f,this.flexedPecentage - this.acceleration);
	}
}
