using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour {
	
	public Button voltar;

	void Start () {

		voltar.transform.position = new Vector3 (((Screen.width) / 12) * 3, (Screen.height / 12) * 2, 0);
		
		if(Screen.width < 1000){
			
			voltar.transform.position = new Vector3 (((Screen.width) / 12) * 1, (Screen.height / 12) * 1, 0);
			
			RectTransform rt1 = voltar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt1.sizeDelta = new Vector2 (100, 50);
		}
	}
}