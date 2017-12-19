using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolherCreditos : MonoBehaviour {

	public void Click () {
		SceneManager.LoadScene("Creditos");
	}
}