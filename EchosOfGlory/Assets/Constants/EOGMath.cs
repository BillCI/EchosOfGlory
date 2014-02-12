using UnityEngine;
using System.Collections;

public class EOGMath {
	private enum Box {small,medium,large}
	public static float angleGiven(Vector3 A,Vector3 B, Vector3 C) {
		float a = (B.y - A.y) * (C.z - A.z) - (C.y - A.y) * (B.z - A.z);
		float b = (B.z - A.z) * (C.x - A.x) - (C.z - A.z) * (B.x - A.x);
		float c = (B.x - A.x) * (C.y - A.y) - (C.x - A.x) * (B.y - A.y);
		float d = -(a * A.x + b * A.y + c * A.z);
		Debug.Log ("f(x,y) = ("+a+" * x + "+b+" * y + "+d+") / ("+(-1*c)+")");

		float AB = Mathf.Pow (A.x-B.x,2) + Mathf.Pow (A.y-B.y,2) + Mathf.Pow (A.z-B.z,2);
		float CB = Mathf.Pow (C.x-B.x,2) + Mathf.Pow (C.y-B.y,2) + Mathf.Pow (C.z-B.z,2);
		Vector3 Q = Vector3.zero;
		Vector3 R = Vector3.zero;
		Box type = Box.small;

		if (c != 0) {

		} else {
			if(A.x > B.x && A.y > B.y && C.x > B.x && C.y > B.y){ //--------------------------- 90º
				// __ _Q AC
				// __  B _R
				// __ __ __
				type = Box.small;
				Q = new Vector3(B.x,A.y,(a * B.x + b * A.y + d) / (-c));
				R = new Vector3(C.x,B.y,(a * C.x + b * B.y + d) / (-c));
			} else if(A.x > B.x && A.y > B.y && C.x > B.x && C.y < B.y){
				// __ _Q A_
				// __  B __
				// __ _R C_
				type = Box.medium;
				Q = new Vector3(B.x,A.y,(a * B.x + b * A.y + d) / (-c));
				R = new Vector3(B.x,C.y,(a * B.x + b * C.y + d) / (-c));
			} else if(A.x > B.x && A.y > B.y && C.x < B.x && C.y > B.y){
				// _C __ A_
				// _R  B Q_
				// __ __ __
				type = Box.medium;
				Q = new Vector3(A.x,B.y,(a * A.x + b * B.y + d) / (-c));
				R = new Vector3(C.x,B.y,(a * C.x + b * B.y + d) / (-c));
			} else if(A.x > B.x && A.y > B.y && C.x < B.x && C.y < B.y){ //--------------------- special case
				// _Q __ A_
				// __  B __
				// _C __ R_
				type = Box.large;
				Q = new Vector3(C.x,A.y,(a * C.x + b * A.y + d) / (-c));
				R = new Vector3(A.x,C.y,(a * A.x + b * C.y + d) / (-c));
			} else if(A.x > B.x && A.y < B.y && C.x > B.x && C.y > B.y){
				// __ R_ _C
				// __  B __
				// __ Q_ A_
				type = Box.medium;
				Q = new Vector3(B.x,A.y,(a * B.x + b * A.y + d) / (-c));
				R = new Vector3(B.x,C.y,(a * B.x + b * C.y + d) / (-c));
			} else if(A.x > B.x && A.y < B.y && C.x > B.x && C.y < B.y){//--------------------------- 90º
				// __ __ __
				// __  B _R
				// __ _Q AC
				type = Box.small;
				Q = new Vector3(B.x,A.y,(a * B.x + b * A.y + d) / (-c));
				R = new Vector3(C.x,B.y,(a * C.x + b * B.y + d) / (-c));
			} else if(A.x > B.x && A.y < B.y && C.x < B.x && C.y > B.y){ //--------------------- special case
				// _C __ Q_
				// __  B __
				// R_ __ A_
				type = Box.large;
				Q = new Vector3(A.x,C.y,(a * A.x + b * C.y + d) / (-c));
				R = new Vector3(C.x,A.y,(a * C.x + b * A.y + d) / (-c));
			} else if(A.x > B.x && A.y < B.y && C.x < B.x && C.y < B.y){
				// __ __ __
				// _R  B Q_
				// _C __ A_
				type = Box.medium;
				Q = new Vector3(A.x,B.y,(a * A.x + b * B.y + d) / (-c));
				R = new Vector3(C.x,B.y,(a * C.x + b * B.y + d) / (-c));
			} else if(A.x < B.x && A.y > B.y && C.x > B.x && C.y > B.y){
				// _A __ C_
				// _Q  B R_
				// __ __ __
				type = Box.medium;
				Q = new Vector3(A.x,B.y,(a * A.x + b * B.y + d) / (-c));
				R = new Vector3(C.x,B.y,(a * C.x + b * B.y + d) / (-c));
			} else if(A.x < B.x && A.y > B.y && C.x > B.x && C.y < B.y){ //--------------------- special case
				// _A __ Q_
				// __  B __
				// _R __ C_
				type = Box.large;
				Q = new Vector3(C.x,A.y,(a * C.x + b * A.y + d) / (-c));
				R = new Vector3(A.x,C.y,(a * A.x + b * C.y + d) / (-c));
			} else if(A.x < B.x && A.y > B.y && C.x < B.x && C.y > B.y){//--------------------------- 90º
				// AC _Q __
				// _R  B __
				// __ __ __
				type = Box.small;
				Q = new Vector3(B.x,A.y,(a * B.x + b * A.y + d) / (-c));
				R = new Vector3(C.x,B.y,(a * C.x + b * B.y + d) / (-c));
			} else if(A.x < B.x && A.y > B.y && C.x < B.x && C.y < B.y){
				// A_ Q_ __
				// __  B __
				// C_ R_ __
				type = Box.medium;
				Q = new Vector3(B.x,A.y,(a * B.x + b * A.y + d) / (-c));
				R = new Vector3(B.x,C.y,(a * B.x + b * C.y + d) / (-c));
			} else if(A.x < B.x && A.y < B.y && C.x > B.x && C.y > B.y){ //--------------------- special case
				// R_ __ C_
				// __  B __
				// _A __ Q_
				type = Box.large;
				Q = new Vector3(C.x,A.y,(a * C.x + b * A.y + d) / (-c));
				R = new Vector3(A.x,C.y,(a * A.x + b * C.y + d) / (-c));
			} else if(A.x < B.x && A.y < B.y && C.x > B.x && C.y < B.y){
				// __ __ __
				// Q_  B R_
				// _A __ C_
				type = Box.medium;
				Q = new Vector3(A.x,B.y,(a * A.x + b * B.y + d) / (-c));
				R = new Vector3(C.x,B.y,(a * C.x + b * B.y + d) / (-c));
			} else if(A.x < B.x && A.y < B.y && C.x < B.x && C.y > B.y){
				// _C R_ __
				// __  B __
				// _A Q_ __
				type = Box.medium;
				Q = new Vector3(B.x,A.y,(a * B.x + b * A.y + d) / (-c));
				R = new Vector3(B.x,C.y,(a * B.x + b * C.y + d) / (-c));
			} else if(A.x < B.x && A.y < B.y && C.x < B.x && C.y < B.y){//--------------------------- 90º
				// __ __ __
				// R_  B __
				// AC Q_ __
				type = Box.small;
				Q = new Vector3(B.x,A.y,(a * B.x + b * A.y + d) / (-c));
				R = new Vector3(C.x,B.y,(a * C.x + b * B.y + d) / (-c));
			}  
		}
		
		float QB = Mathf.Pow (Q.x-B.x,2) + Mathf.Pow (Q.y-B.y,2) + Mathf.Pow (Q.z-B.z,2);
		float RB = Mathf.Pow (R.x-B.x,2) + Mathf.Pow (R.y-B.y,2) + Mathf.Pow (R.z-B.z,2);
		float alpha = Mathf.Acos (QB / AB);
		float beta = Mathf.Acos (RB / CB);
		if (type == Box.small) {
			return 90 - alpha - beta;
		} else if (type == Box.medium){
			return 180 - alpha - beta;
		} else if (type == Box.large){
			return Mathf.Min ( 180 - beta + alpha, 180 - alpha + beta );
		}
		return -1000;

	}


	public static float AngleBetween(Vector3 v1, Vector3 v2) {

		Vector3 v3 = Vector3.Cross (Vector3.up, v1);
		float angle = Vector3.Angle (v2, v1);
		float sign = (Vector3.Dot (v2,v3) > 0.0f) ? 1.0f : -1.0f;
		return sign * angle;
	}

	public static float ContAngle(Vector3 fwd,  Vector3 targetDir,  Vector3 upDir) {
		
		var angle = Vector3.Angle(fwd, targetDir);
				
		if (EOGMath.AngleDir(fwd, targetDir, upDir) == -1) {			
			return 360 - angle;
		} else {			
			return angle;			
		}		
	}
	//returns -1 when to the left, 1 to the right, and 0 for forward/backward
	
	public static float AngleDir(Vector3 fwd,  Vector3 targetDir,  Vector3 up) {
		
		Vector3 perp  = Vector3.Cross(fwd, targetDir);		
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0.0) {			
			return 1.0f;			
		} else if (dir < 0.0) {			
			return -1.0f;			
		} else {			
			return 0.0f;			
		}		
	}
}
