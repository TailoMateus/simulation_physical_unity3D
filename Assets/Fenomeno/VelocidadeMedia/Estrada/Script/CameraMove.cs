
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float moveSpeed;
	public InputField moveSpeedField;
	public InputField mainInputField;
	public GameObject mainCamera;
	private int clicou;
	private int entrou;
	public Button btn;
	public AudioClip otherClip;

	// Use this for initialization
	void Start () {
		mainCamera.transform.localPosition = new Vector3 ( 0, 0, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler (18, 180, 0);
		clicou = 0;
		entrou = 0;
		
		btn.onClick.AddListener(OnClickIniciarAnimacaoVelocidade);
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = otherClip;
		
	}

	void FixedUpdate()
	{
		if(clicou == 1){
			MoveObj ();
		}
		
		if(clicou == 1 && entrou == 0){
			entrou = 1;
			
			moveSpeed = 4 * (-1);
		}
		
		if(float.Parse (mainInputField.text) == 7) {
			clicou = 0;
		}
	}
	
	public void OnClickIniciarAnimacaoVelocidade (){
		clicou = 1;
		GetComponent<AudioSource>().Play();
	}
	
	void MoveObj() {		
		float moveAmount = Time.smoothDeltaTime * moveSpeed;
		transform.Translate ( 0f, 0f, moveAmount );	
	}
}