using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelecionaAmbienteVelocidade : MonoBehaviour {

	public void OnClickButtonPanel1 (){
		SceneManager.LoadScene("SelecionarPersonagemVelocidadeS");
	}
	
	public void OnClickButtonPanel2 (){
		SceneManager.LoadScene("SelecionarPersonagemVelocidadeC");
	}
}