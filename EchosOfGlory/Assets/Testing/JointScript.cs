using UnityEngine;
using System.Collections;


public class JointScript : MonoBehaviour {
	public ArmScript childArm;
	public ArmScript parrentArm;

	public enum AXIS {X,Y,Z}
	public AXIS axis = AXIS.Z;
	[Range (0, 359)]
	public float min = 100;
	[Range (0, 359)]
	public float max = 200;
	public MuscleScript pullMuscle;
	public MuscleScript pushMuscle;

	private float pushReduction = 1;
	private float pullReduction = 1;

	//[HideInInspector] 
	[Range (0, 360)]
	public float targetAngle = 180;
	//--------------------------------------------------------------------------------
	// MonoBehaviour
	//--------------------------------------------------------------------------------
	// Use this for initialization
	void Start () {
		this.checkMinMax ();
	}
	
	// Update is called once per frame
	void Update () {
		float angle = EOGMath.angleGiven (this.parrentArm.transform.position, this.transform.position, this.childArm.transform.position);
		//Debug.Log (angle);
		//Debug.Log (this.parrentArm.transform.position + " vs " + this.childArm.transform.position);
		this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x,this.transform.eulerAngles.y, (this.targetAngle+180)%360);
	}
	//--------------------------------------------------------------------------------
	// HELPERS
	//--------------------------------------------------------------------------------
	//swap min and max if not in correct order
	private void checkMinMax(){
		if (max < min) {
				float temp = max;
				max = min;
				min = temp;
		}
	}
}
