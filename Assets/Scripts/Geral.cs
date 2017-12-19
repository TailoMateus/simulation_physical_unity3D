using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Geral : MonoBehaviour {

	public void OnClickVoltar (){

		SceneManager.LoadScene("EscolherFenomeno");
	}
}