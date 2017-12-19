using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelecionaMassa : MonoBehaviour {
	
	public void OnClickMassa (){
		SceneManager.LoadScene("Massa");
	}
}