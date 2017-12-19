using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Funcoes : MonoBehaviour {
	public InputField rotacao;
	public InputField translacao;

	public void Formulario () {
		
		if(rotacao.text == "24" && translacao.text == "365"){
			SceneManager.LoadScene("RespostaCorretaGravidadeFase1");
		}
		else {
			SceneManager.LoadScene("RespostaIncorretaGravidadeFase1");
		}
	}
	
	public void TentarNovamente () {
		SceneManager.LoadScene("SistemaSolar");
	}
	
	public void VoltarFase1 () {
		SceneManager.LoadScene("SistemaSolar");
	}
	
	public void ProximaFase2 () {
		Debug.Log("Fase 2");
	}
	
	public void ObjetivoFase1 () {
		SceneManager.LoadScene("ObjetivoFase1Gravidade");
	}
	
	public void ProgressoFase1 () {
		SceneManager.LoadScene("ProgressoFase1Gravidade");
	}
}