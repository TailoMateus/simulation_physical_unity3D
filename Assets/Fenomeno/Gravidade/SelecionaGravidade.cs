using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelecionaGravidade : MonoBehaviour {

	public void OnClickGravidade (){
		SceneManager.LoadScene("SelecionarPlanetas");
	}
}