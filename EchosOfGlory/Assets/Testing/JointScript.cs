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

	public float range { 
		get { 
			return this.max - this.min; 
		} 
		private set{

		} 
	}

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
		Vector3 deltaVector = new Vector3 (0, 0, 0);
		float normalizedTargetAngle = (this.targetAngle + 180) % 360;
		float actual;
		if (this.axis == AXIS.X) {
			actual = this.transform.localEulerAngles.x;
			deltaVector.x = 1;
		} else if (this.axis == AXIS.Y) {
			actual = this.transform.localEulerAngles.y;
			deltaVector.y = 1;
		} else {
			actual = this.transform.localEulerAngles.z;
			deltaVector.z = 1;
		}
		float zeroedTargetAngle = normalizedTargetAngle - actual;
		while (zeroedTargetAngle < 0) {
			zeroedTargetAngle -= 360.0f;
		}
		if (zeroedTargetAngle > 180) {
			//pull
			this.pullMuscle.flex();
			this.pushMuscle.relax();
			deltaVector = EOGMath.multiplyVectoryBy(deltaVector,-1 * 
			                                       	Mathf.Min (actual,
		           												this.pullMuscle.currentStrength()-this.pushMuscle.currentStrength()
			           										)
			                                        );
		} else {
			//push
			this.pullMuscle.relax();
			this.pushMuscle.flex();
			deltaVector = EOGMath.multiplyVectoryBy(deltaVector, 
			                                        Mathf.Min (actual,
			           											this.pushMuscle.currentStrength()-this.pullMuscle.currentStrength()
			          										 )
			                                        );
		}
		Debug.Log (deltaVector);
		this.transform.localEulerAngles = this.transform.localEulerAngles + deltaVector;
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
