using UnityEngine;
using System.Collections;

public class EOGMath {

	public static void planeGiven(Vector3 A,Vector3 B, Vector3 C) {
		float a = (B.y - A.y) * (C.z - A.z) - (C.y - A.y) * (B.z - A.z);
		float b = (B.z - A.z) * (C.x - A.x) - (C.z - A.z) * (B.x - A.x);
		float c = (B.x - A.x) * (C.y - A.y) - (C.x - A.x) * (B.y - A.y);
		float d = -(a * A.x + b * A.y + c * A.z);

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
