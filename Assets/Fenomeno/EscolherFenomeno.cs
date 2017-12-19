using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolherFenomeno : MonoBehaviour {

	// Use this for initialization

	public void Start () {
		//StartCoroutine ("EscolherFenomeno");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click () {
		SceneManager.LoadScene("EscolherFenomeno");
	}
}