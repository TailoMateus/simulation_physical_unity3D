using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResponsividadeAjuda : MonoBehaviour {
	
	public Button voltar;

	void Start () {
		
		voltar.transform.position = new Vector3 ((((Screen.width) / 12) * 2) + 30, ((Screen.height / 12) * 1) - 30, 0);
	}
}
