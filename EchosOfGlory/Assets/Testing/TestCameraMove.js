#pragma strict
var r : float = 10;
var speed : float = 5.0;
var lookAtVector : Vector3 = Vector3.zero;
private var aDown : boolean = false;
private var dDown : boolean = false;
private var wDown : boolean = false;
private var sDown : boolean = false;
private var zDown : boolean = false;
private var xDown : boolean = false;
function Start () {

}

function Update () {
	if(aDown || wDown || sDown || dDown ||zDown ||xDown) {	
		var x : float = transform.position.x;
		var y : float = transform.position.y;
		var z : float = transform.position.z;
		if (aDown) { x -= speed; }
		if (dDown) { x += speed; }
		if (sDown) { y -= speed; } 
		if (wDown) { y += speed; }
		if (zDown) { r -= speed; }
		if (xDown) { r += speed; }
		
		z = Mathf.Pow((r*r - Mathf.Pow(x-lookAtVector.x,2) - Mathf.Pow(y-lookAtVector.y,2)),0.5) + lookAtVector.z;
		transform.position = Vector3(x,y,z);
		transform.LookAt(lookAtVector);
	
	}
	if(Input.GetKeyDown ("a")) { aDown = true;}
	if(Input.GetKeyUp ("a"))   { aDown = false;}
	if(Input.GetKeyDown ("d")) { dDown = true;}
	if(Input.GetKeyUp ("d"))   { dDown = false;}
	if(Input.GetKeyDown ("w")) { wDown = true;}
	if(Input.GetKeyUp ("w"))   { wDown = false;}
	if(Input.GetKeyDown ("s")) { sDown = true;}
	if(Input.GetKeyUp ("s"))   { sDown = false;}
	if(Input.GetKeyDown ("z")) { zDown = true;}
	if(Input.GetKeyUp ("z"))   { zDown = false;}
	if(Input.GetKeyDown ("x")) { xDown = true;}
	if(Input.GetKeyUp ("x"))   { xDown = false;}
}