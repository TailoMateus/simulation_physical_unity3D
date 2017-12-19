using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolherConf : MonoBehaviour {

	public void Click () {
		SceneManager.LoadScene("configuracao");
	}
}