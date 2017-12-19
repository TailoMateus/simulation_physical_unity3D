using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Massa : MonoBehaviour {
	
	// Angulo = 37 graus 
	// Cos = 0,8
	// Seno= 0,6
	
	// Vx = v * Cos
	// Vy = v * Seno
	
	// Total de segundos = (vy / 10m/s) * 2
	// Distancia = vx * total de segundos
	
	/*
	
	https://www.assetstore.unity3d.com/en/#!/content/7092
	
	https://www.youtube.com/watch?v=U3jDHU5zY8Y
	https://www.youtube.com/watch?v=zvrhwnWBgWE
	
	*/
	
	public Text velocidadeT;
	public InputField velocidade;
	public Text cosseno;
	public Text info;
	
	public Button reiniciar;
	public Button voltar;
	public Button ajuda;
	
	private float velocidadeF;
	private float velocidadeX;
	private float velocidadeY;
	private float segundos;
	private float distancia;
	private float valorX;
	private float valorRT;
	
	void Start () {
		velocidadeT.transform.position = new Vector3 (((Screen.width) / 12) * 9, ((Screen.height - 20) / 12) * 11, 0);
		velocidade.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 11, 0);

		cosseno.transform.position = new Vector3 (((Screen.width) / 12) * 9, ((Screen.height - 20) / 12) * 10, 0);
		
		info.transform.position = new Vector3 (((Screen.width) / 12) * 9, ((Screen.height) / 12) * 8, 0);

		reiniciar.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 8, 0);
		voltar.transform.position = new Vector3 (((Screen.width) / 12) * 1, (Screen.height / 12) * 1, 0);

		reiniciar.onClick.AddListener(clickReiniciar);

		velocidade.text = "100";
		
		info.text = "VoX (m/s): 86 \nVoY (m/s): 50 \nAlcance (m): 860";
		
		ajuda.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 1, 0);
		ajuda.onClick.AddListener(clickAjuda);
		
		if(Screen.width < 1000){
			cosseno.enabled = false;
			
			velocidadeT.transform.position = new Vector3 (((Screen.width) / 12) * 6, ((Screen.height - 20) / 12) * 12, 0);
			velocidade.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 11, 0);
			
			reiniciar.transform.position = new Vector3 (((Screen.width) / 12) * 8, (Screen.height / 12) * 6, 0);
			
			info.transform.position = new Vector3 (((Screen.width) / 12) * 3, ((Screen.height) / 12) * 8, 0);
			
			RectTransform rt = reiniciar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt.sizeDelta = new Vector2 (100, 50);
			
			RectTransform rt1 = voltar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt1.sizeDelta = new Vector2 (100, 50);
			
			ajuda.interactable = false;
			ajuda.transform.position = new Vector3 (((Screen.width) / 12) * 1000, (Screen.height / 12) * 1000, 0);
		}
	}

	void clickReiniciar() {
		
	}
	
	void clickAjuda() {
		SceneManager.LoadScene("ajuda_massa");
	}
}