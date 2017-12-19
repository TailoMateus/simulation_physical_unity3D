using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelecionaAtrito : MonoBehaviour {
	
	public void OnClickAtrito (){
		SceneManager.LoadScene("cena_atrito");
	}
	
	public void OnClickVoltarAtrito (){
		SceneManager.LoadScene("EscolherFenomeno");
	}
}