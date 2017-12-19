using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Atrito : MonoBehaviour {
	
	public InputField Forca;
	public Text ForcaTexto;
	
	public InputField aceleracaoInput;
	public Text aceleracaoInputTexto;
	
	public GameObject peronagem;
    public GameObject cubo;
	
	public Button voltar;
	
	public Button reiniciar;
	
	public Button ajuda;
	
	public Text info;
	
	private float massa;
	private float uc;
	private float forcaAtritoCinetica;
	private float aceleracao;
	
	
	
	// Massa do bloco: 2kg
	// O bloco vai estar inicialmente parado: atrito estático
	// Coeficiente de atrito estático é ue: 0,5
	// Força de atrito estático maximo: ue * N = 0.5 * 20N (10 * 2kg) = 10N
	
	// Se a força informada for maior que 10N é uma força cinética
	// Força de atrito cinética: uc * N = 0.4 * 20N = 8N
	
	// Exemplo: Força de 12N
	// Para encontrar a aceleração = Força resultante = m * a
	// 12 - 8 = 2 * a
	// 4 = 2 a
	// a = 2 m/s

	void Start () {
		ForcaTexto.transform.position = new Vector3 (((Screen.width) / 12) * 10, ((Screen.height - 20) / 12) * 11, 0);
		Forca.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 11, 0);
		
		aceleracaoInputTexto.transform.position = new Vector3 (((Screen.width) / 12) * 10, ((Screen.height - 20) / 12) * 10, 0);
		aceleracaoInput.transform.position = new Vector3 (((Screen.width) / 12) * 11, (Screen.height / 12) * 10, 0);
		
		voltar.transform.position = new Vector3 (((Screen.width) / 12) * 1, (Screen.height / 12) * 1, 0);
		reiniciar.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 8, 0);
		
		ajuda.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 1, 0);
		
		info.transform.position = new Vector3 (((Screen.width) / 12) * 2, ((Screen.height - 20) / 12) * 10, 0);
		
		if(Screen.width < 1000){
			ForcaTexto.transform.position = new Vector3 (((Screen.width) / 12) * 7, ((Screen.height - 30) / 12) * 12, 0);
			Forca.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 11, 0);
			
			aceleracaoInputTexto.transform.position = new Vector3 (((Screen.width) / 12) * 7, ((Screen.height - 30) / 12) * 10, 0);
			aceleracaoInput.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 9, 0);
			
			voltar.transform.position = new Vector3 (((Screen.width) / 12) * 1, (Screen.height / 12) * 1, 0);
			reiniciar.transform.position = new Vector3 (((Screen.width) / 12) * 8, (Screen.height / 12) * 6, 0);
			
			RectTransform rt = reiniciar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt.sizeDelta = new Vector2 (100, 40);
			
			RectTransform rt1 = voltar.GetComponent (typeof (RectTransform)) as RectTransform;
			rt1.sizeDelta = new Vector2 (100, 50);
			
			info.enabled = false;
			
			ajuda.interactable = false;
			ajuda.transform.position = new Vector3 (((Screen.width) / 12) * 1000, (Screen.height / 12) * 1000, 0);
		}
		
		Forca.text = "0";
		aceleracaoInput.text = "0";
		massa = 2; //kg
		uc = 0.4f;
		aceleracaoInput.enabled = false;
		forcaAtritoCinetica = uc * (massa * 10f);
		
		reiniciar.onClick.AddListener(clickReiniciar);
		ajuda.onClick.AddListener(clickAjuda);
	}
	
	void Update () {
		int forcaInteiro;
		
		if(Forca.text != ""){
			forcaInteiro = System.Convert.ToInt32(Forca.text);
			
			if(forcaInteiro > 10){
				//Debug.Log("Dinamico");
				
				aceleracao = (forcaInteiro - forcaAtritoCinetica) / massa;
				
				aceleracaoInput.text = aceleracao.ToString();
				
				if(cubo.transform.position.x >= (peronagem.transform.position.x - 1.1f)){
					cubo.transform.position = new Vector3 (peronagem.transform.position.x + -1.1f, cubo.transform.position.y, cubo.transform.position.z);
				}

				//Debug.Log(aceleracao);
			}
			else {
				//Debug.Log("Estatico");
				aceleracaoInput.text = "0";
			}
		}
	}
	
	void clickReiniciar() {
		
		cubo.transform.position = new Vector3 (15, 33, 2);
		peronagem.transform.position = new Vector3 (20, 32, 1);
	}
	
	void clickAjuda() {
		SceneManager.LoadScene("ajuda_atrito");
	}
}