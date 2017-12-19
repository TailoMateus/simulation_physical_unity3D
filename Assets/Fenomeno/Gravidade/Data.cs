using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {

	private GameObject[] datas;
	public static int PlanetaInstanciar;

	void Awake (){
		datas = GameObject.FindGameObjectsWithTag("Data");

		if (datas.Length >= 2) {
			Destroy (datas [0]);
		}

		DontDestroyOnLoad (transform.gameObject);
	}
	/*void Update() {
		if (Input.GetKeyDown ("e")) {
			Application.LoadLevel ("SistemaSolar");
		}
	}*/
}
