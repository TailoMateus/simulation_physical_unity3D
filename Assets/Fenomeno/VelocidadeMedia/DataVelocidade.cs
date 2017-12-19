using UnityEngine;
using System.Collections;

public class DataVelocidade : MonoBehaviour {

	private GameObject[] datas;
	public static int PersonagemVelocidadeInstanciar;

	void Awake (){
		datas = GameObject.FindGameObjectsWithTag("Data");

		if (datas.Length >= 2) {
			Destroy (datas [0]);
		}

		DontDestroyOnLoad (transform.gameObject);
	}
}
