using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelecionaVelocidade : MonoBehaviour {
	
	public void OnClickVelocidade (){
		SceneManager.LoadScene("SelecionaAmbienteVelocidade");
	}
}
