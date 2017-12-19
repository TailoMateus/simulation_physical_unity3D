using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VelocidadeMediaC : MonoBehaviour {
	private float moveSpeed;
	public GameObject mainCamera;
	public GameObject Lumberjack1;
	public GameObject Lumberjack2;
	public GameObject Lumberjack3;
	public InputField mainInputField;
	public InputField mainInputField2;
	public InputField mainInputField3;
	public InputField mainInputField4;
	private float tempo;
	private float distancia;
	private float distanciaCalculo;
	private float velocidadeMedia;
	private int clicou;
	public int contadorMoedas;
	private int tamanhoPulo;
	public GameObject cubo;
	public Button btn;
	public Button ajuda;
	
	void Start () {
		mainCamera.transform.localPosition = new Vector3 ( 0, 0, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler (18, 180, 0);
		mainInputField.text = "Não cálculado";
		mainInputField2.text = "0";
		mainInputField3.text = "0";
		mainInputField4.text = contadorMoedas.ToString();
		cubo.transform.position = new Vector3 ( 1f, 1f, -15f );	
		
		moveSpeed = -4;
		
		mainInputField.enabled = false;
		mainInputField2.enabled = false;
		mainInputField3.enabled = false;
		mainInputField4.enabled = false;
		
		tempo = 0;
		contadorMoedas = 0;
		tamanhoPulo = 0;
		clicou = 0;
		
		ajuda.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 3, 0);
		ajuda.onClick.AddListener(clickAjuda);
		btn.onClick.AddListener(OnClickIniciarAnimacaoVelocidade);
		
		if(Screen.width < 1000){
			ajuda.interactable = false;
			ajuda.transform.position = new Vector3 (((Screen.width) / 12) * 1000, (Screen.height / 12) * 1000, 0);
		}
		
		if(Lumberjack1.name == "Lumberjack1(Clone)" || (GameObject.Find ("Lumberjack1(Clone)") != null && Lumberjack1.name == "Lumberjack1")){
			Lumberjack1.SetActive(false);
			Lumberjack2.SetActive(false);
			Lumberjack3.SetActive(false);
			if(Lumberjack1.name == "Lumberjack1")
				Lumberjack1.SetActive(true);
		}
		
		if(Lumberjack2.name == "Lumberjack2(Clone)" || (GameObject.Find ("Lumberjack2(Clone)") != null && Lumberjack2.name == "Lumberjack2")){
			Lumberjack1.SetActive(false);
			Lumberjack2.SetActive(false);
			Lumberjack3.SetActive(false);
			if(Lumberjack2.name == "Lumberjack2")
				Lumberjack2.SetActive(true);
		}
		
		if(Lumberjack3.name == "Lumberjack3(Clone)" || (GameObject.Find ("Lumberjack3(Clone)") != null && Lumberjack3.name == "Lumberjack3")){
			Lumberjack1.SetActive(false);
			Lumberjack2.SetActive(false);
			Lumberjack3.SetActive(false);
			if(Lumberjack3.name == "Lumberjack3")
				Lumberjack3.SetActive(true);
		}
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)){
			tamanhoPulo = tamanhoPulo + 1;
			if(tamanhoPulo > 1){
				tamanhoPulo = 1;
			}
			personagemAtivado().transform.position = new Vector3 (tamanhoPulo, 0, (distancia + 5) * (-1) );
		}
		
		if (Input.GetKey (KeyCode.RightArrow)){
			tamanhoPulo = tamanhoPulo - 1;
			if(tamanhoPulo < -1){
				tamanhoPulo = -1;
			}
			personagemAtivado().transform.position = new Vector3 (tamanhoPulo, 0, (distancia + 5) * (-1) );
		}
		
		if (Input.GetKey (KeyCode.F1)){
			SceneManager.LoadScene("ParallaxVelocidadeMedia");
		}
	}

	void FixedUpdate(){
		if(clicou == 1){
			MoveObj();
			mainInputField.enabled = false;
		}

		if(contadorMoedas == 7) {
			clicou = 0;
			velocidadeMedia = distanciaCalculo / tempo;
			mainInputField.text = velocidadeMedia.ToString();
			
			personagemAtivado().SetActive(false);
		}
	}

	public void OnClickIniciarAnimacaoVelocidade (){
		clicou = 1;
	}

	GameObject personagemAtivado (){
		if(Lumberjack1.activeSelf == true)
			return Lumberjack1;
		else if(Lumberjack2.activeSelf == true)
			return Lumberjack2;
		else
			return Lumberjack3;
	}

	void MoveObj() {

		moveSpeed = 4;
		moveSpeed = moveSpeed * (-1);

		tempo = tempo + Time.deltaTime;
		tempo = Mathf.Round(tempo * 100f) / 100f;
		mainInputField2.text = tempo.ToString();
		distanciaCalculo = (5) * tempo;

		mainInputField3.text = distanciaCalculo.ToString();
		
		distancia = ((moveSpeed * -1) * tempo);
		personagemAtivado().transform.position = new Vector3 (tamanhoPulo, 0, (distancia + 5) * (-1) );

		if((int)personagemAtivado().transform.position.z == (int)cubo.transform.position.z && (int)personagemAtivado().transform.position.x == (int)cubo.transform.position.x){
			contadorMoedas = contadorMoedas + 1;
			posicionaCubo();
			
			tempo = tempo - Time.deltaTime;
		}
		else if((int)personagemAtivado().transform.position.z == (int)cubo.transform.position.z) {
			posicionaCubo();
			
			tempo = tempo - Time.deltaTime;
		}
		
		mainInputField4.text = contadorMoedas.ToString();
	}
	
	void posicionaCubo() {
		
		if(contadorMoedas % 3 == 0) 
			cubo.transform.position = new Vector3 ( 1f, 1, (distancia + 25) * (-1) );	
		else if(contadorMoedas % 2 == 0) {
			cubo.transform.position = new Vector3 ( -1f, 1, (distancia + 25) * (-1) );	
		}
		else {
			if(contadorMoedas > 1)
				cubo.transform.position = new Vector3 ( 0, 1, (distancia + 25) * (-1) );
			else 
				cubo.transform.position = new Vector3 ( -1f, 1, (distancia + 25) * (-1) );	
		}
	}
	
	void clickAjuda() {
		SceneManager.LoadScene("ajuda_velocidade");
	}
}