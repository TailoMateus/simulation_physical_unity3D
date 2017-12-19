#pragma strict
import UnityEngine.UI;
internal var animator:Animator;
var v:float;
var h:float;
var run:float;
var acelaracao:InputField;

function Start () {
	
	animator=GetComponent (Animator);
}

function Update () {
	v=Input.GetAxis("Vertical");
	h=Input.GetAxis("Horizontal");
	if (animator.GetFloat("Run")==0.2){
		if (Input.GetKeyDown("space")){
			animator.SetBool("Jump",true);
		}
	}
	Sprinting();
	
}

function FixedUpdate (){
	animator.SetFloat("Walk",v);
	animator.SetFloat("Run",run);
	animator.SetFloat("Turn",h);
}

function Sprinting(){
	var valorRun = System.Convert.ToInt32(acelaracao.text);
	
	if (Input.GetKey(KeyCode.LeftShift)){
		run=0.2;
	}
	else {
		run = valorRun / 10;
	}
}