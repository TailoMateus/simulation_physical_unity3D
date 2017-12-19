using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResponsividadeVelocidade : MonoBehaviour {
	
	public InputField velocidade;
	public InputField tempo;
	public InputField distancia;
	public InputField cubos;
	
	public Text velocidadeT;
	public Text tempoT;
	public Text distanciaT;
	public Text cubosT;
	
	public Button iniciar;
	public Button voltar;

	void Start () {
		if(Screen.width < 1000){
			velocidade.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 7, 0);
			tempo.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 11, 0);
			distancia.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 9, 0);
			
			velocidadeT.transform.position = new Vector3 (((Screen.width) / 12) * 8, ((Screen.height - 10) / 12) * 7, 0);
			tempoT.transform.position = new Vector3 (((Screen.width) / 12) * 9, ((Screen.height - 10) / 12) * 11, 0);
			distanciaT.transform.position = new Vector3 (((Screen.width) / 12) * 9, ((Screen.height - 10) / 12) * 9, 0);
			
			cubos.enabled = false;
			cubosT.enabled = false;
			
			voltar.transform.position = new Vector3 (((Screen.width) / 12) * 1, (Screen.height / 12) * 1, 0);
			
			iniciar.transform.position = new Vector3 (((Screen.width) / 12) * 7, (Screen.height / 12) * 1, 0);
			
			RectTransform rt = iniciar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt.sizeDelta = new Vector2 (100, 50);
			
			RectTransform rt1 = voltar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt1.sizeDelta = new Vector2 (100, 50);
			
			RectTransform rt2 = velocidade.GetComponent (typeof (RectTransform)) as RectTransform;
			rt2.sizeDelta = new Vector2 (70, 50);
			
			RectTransform rt3 = tempo.GetComponent (typeof (RectTransform)) as RectTransform;
			rt3.sizeDelta = new Vector2 (60, 30);
			
			RectTransform rt4 = distancia.GetComponent (typeof (RectTransform)) as RectTransform;
			rt4.sizeDelta = new Vector2 (60, 30);
		}
		else{ 
			velocidade.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 11, 0);
			tempo.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 10, 0);
			distancia.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 9, 0);
			cubos.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 8, 0);
			
			velocidadeT.transform.position = new Vector3 (((Screen.width) / 12) * 10, ((Screen.height - 12) / 12) * 11, 0);
			tempoT.transform.position = new Vector3 (((Screen.width) / 12) * 10, ((Screen.height - 12) / 12) * 10, 0);
			distanciaT.transform.position = new Vector3 (((Screen.width) / 12) * 10, ((Screen.height - 12) / 12) * 9, 0);
			cubosT.transform.position = new Vector3 (((Screen.width) / 12) * 10, ((Screen.height - 12) / 12) * 8, 0);
			
			voltar.transform.position = new Vector3 (((Screen.width) / 12) * 1, (Screen.height / 12) * 1, 0);
			
			iniciar.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 1, 0);
		}
	}
}
