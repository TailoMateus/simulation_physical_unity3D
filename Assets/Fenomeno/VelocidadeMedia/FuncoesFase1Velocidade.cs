using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuncoesFase1Velocidade : MonoBehaviour {
	
	public void VoltarFase1 () {
		SceneManager.LoadScene("VelocidadeMedia");
	}
}