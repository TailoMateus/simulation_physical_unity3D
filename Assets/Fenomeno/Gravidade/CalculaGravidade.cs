using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class CalculaGravidade : MonoBehaviour {
	// Massa cubo: 10 kg
	// Calcula peso: p = m * g
	
	// Planeta terra: 90 N
	// Gravidade: 9.8 m/s³
	
	// Planeta marte: 37 N
	// Gravidade: 3.7 m/s²
	
	// Calcula tempo de queda: d = g*t² / 2
	
	// Distancia: 75 metros
	
	// 75 = 9.8 * t² / 2
	// 2 * 75 = 9.8 * t²
	// 150 = 9.8 * t²
	// t² = 15.306
	// t = 3.91 s
	
	public Text info;
	public InputField distancia;
	public Text distanciaText;
	public InputField tempoC;
	public Text tempoCText;
	public GameObject cubo;
	private double tempo;
	private int tempoInt;
	private float tempoFloat;
	private int distanciaConvertido;
	private float velocidade;
	private int executa;
	
	public Button reiniciar;
	public Button voltar;
	public Button ajuda;

	void Start () {
		info.transform.position = new Vector3 (((Screen.width) / 12) * 2, ((Screen.height - 10) / 12) * 10, 0);

		distancia.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 11, 0);
		distanciaText.transform.position = new Vector3 (((Screen.width) / 12) * 9, ((Screen.height - 10) / 12) * 11, 0);
		
		tempoC.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 10, 0);
		tempoCText.transform.position = new Vector3 (((Screen.width) / 12) * 9, ((Screen.height - 10) / 12) * 10, 0);
		
		reiniciar.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 8, 0);
		voltar.transform.position = new Vector3 (((Screen.width) / 12) * 1, (Screen.height / 12) * 1, 0);
		ajuda.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 1, 0);
		
		reiniciar.onClick.AddListener(clickReiniciar);
		ajuda.onClick.AddListener(clickAjuda);
		
		if(Screen.width < 1000){
			info.enabled = false;
			ajuda.interactable = false;
			ajuda.transform.position = new Vector3 (((Screen.width) / 12) * 1000, (Screen.height / 12) * 1000, 0);
			
			voltar.enabled = false;
			
			distancia.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 11, 0);
			distanciaText.transform.position = new Vector3 (((Screen.width) / 12) * 4, ((Screen.height - 10) / 12) * 11, 0);
			
			tempoC.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 9, 0);
			tempoCText.transform.position = new Vector3 (((Screen.width) / 12) * 4, ((Screen.height - 10) / 12) * 9, 0);
			
			reiniciar.transform.position = new Vector3 (((Screen.width) / 12) * 8, (Screen.height / 12) * 6, 0);
			
			RectTransform rt = reiniciar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt.sizeDelta = new Vector2 (100, 50);
			
			RectTransform rt1 = voltar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt1.sizeDelta = new Vector2 (100, 50);
		}
		
		distancia.text = "75";
		tempoC.text = "0";
		tempoC.enabled = false;
		executa = 0;
	}
	
	void Update () {
		
		if(GameObject.Find ("Planeta1(Clone)") != null) {
			info.text = "Massa do cubo: 10kg\nGravidade: 9.8 m/s²\nPeso do cubo: 90 N";
		
			if(executa == 1) {
				distanciaConvertido = int.Parse(distancia.text);
				
				tempo = (distanciaConvertido * 2 / 9.8);
				tempo = Math.Sqrt(tempo);
				
				float tempoFloat = (float)tempo;
				tempoFloat = Mathf.Round(tempoFloat * 100f) / 100f;
				
				tempoInt = (int) tempo;
			
				if(tempoInt == 1 || tempoInt == 2){
					velocidade = 1f;
				}
				
				if(tempoInt == 3 || tempoInt == 4){
					velocidade = 0.8f;
				}
				
				if(tempoInt == 5 || tempoInt == 6){
					velocidade = 0.6f;
				}
				
				if(tempoInt == 7 || tempoInt == 8){
					velocidade = 0.4f;
				}
				
				if(tempoInt == 9 || tempoInt == 10){
					velocidade = 0.2f;
				}
				
				if(tempoInt > 10){
					velocidade = 0.1f;
				}
					
				tempoC.text = tempoFloat.ToString();
				
				if(cubo.transform.position.y > -60){
					cubo.transform.Translate (0, velocidade * (-1) , 0, Space.World );
				}
			}
		}
			
		if(GameObject.Find ("Planeta2(Clone)") != null) {
			info.text = "Massa do cubo: 10kg\nGravidade: 3.7 m/s²\nPeso do cubo: 37 N";
			
			if(executa == 1) {
			
				distanciaConvertido = int.Parse(distancia.text);
				
				tempo = (distanciaConvertido * 2 / 3.7);
				tempo = Math.Sqrt(tempo);
				
				float tempoFloat = (float)tempo;
				tempoFloat = Mathf.Round(tempoFloat * 100f) / 100f;
				
				tempoInt = (int) tempo;
				
				if(tempoInt == 1 || tempoInt == 2){
					velocidade = 1f;
				}
				
				if(tempoInt == 3 || tempoInt == 4){
					velocidade = 0.8f;
				}
				
				if(tempoInt == 5 || tempoInt == 6){
					velocidade = 0.6f;
				}
				
				if(tempoInt == 7 || tempoInt == 8){
					velocidade = 0.4f;
				}
				
				if(tempoInt == 9 || tempoInt == 10){
					velocidade = 0.2f;
				}
				
				if(tempoInt > 10){
					velocidade = 0.1f;
				}
				
				tempoC.text = tempoFloat.ToString();
				
				if(cubo.transform.position.y > -60){
					cubo.transform.Translate (0, velocidade * (-1) , 0, Space.World );
				}
			}
		}
	}
	
	void clickReiniciar() {
		executa = 1;
		cubo.transform.position = new Vector3 ( 30, 40, 200);
	}
	
	void clickAjuda() {
		SceneManager.LoadScene("ajuda_gravidade");
	}
}
