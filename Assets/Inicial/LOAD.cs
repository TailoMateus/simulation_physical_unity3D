using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LOAD : MonoBehaviour {
	public string cenaCarregar;
	public float tempoFixoSegundo = 5;
	public enum tipoCarregamento { carregamento, tempoFixo };
	public tipoCarregamento tipoDeCarregamento;
	public Image barraCarregamento;
	public Text textoProgresso;
	private int progresso = 0;
	private string textoOriginal;

	void Start () {
		switch (tipoDeCarregamento) {
			case tipoCarregamento.carregamento:
				StartCoroutine (cenaCarregamento (cenaCarregar));
			break;
			case tipoCarregamento.tempoFixo:
				StartCoroutine (tempoFixoCarregar (cenaCarregar));
			break;
		}

		if (textoProgresso != null) {
			textoOriginal = textoProgresso.text;
		}

		if (barraCarregamento != null) {
			barraCarregamento.type = Image.Type.Filled;
			barraCarregamento.fillMethod = Image.FillMethod.Horizontal;
			barraCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
		}
	}

	IEnumerator cenaCarregamento(string cena){
		AsyncOperation carregamento = SceneManager.LoadSceneAsync (cena);
		while (!carregamento.isDone) {
			progresso = (int)(carregamento.progress * 100.0f);
			yield return null;
		}
	}

	IEnumerator tempoFixoCarregar(string cena){
		yield return new WaitForSeconds (tempoFixoSegundo);
		SceneManager.LoadScene (cena);
	}

	void Update () {
		switch (tipoDeCarregamento) {
		case tipoCarregamento.carregamento:
			break;
		case tipoCarregamento.tempoFixo:
			progresso = (int)(Mathf.Clamp((Time.time / tempoFixoSegundo), 0.0f,1.0f) * 100.0f);
			break;
		}

		if (textoProgresso != null) {
			textoProgresso.text = textoOriginal + " " + progresso + "%";
		}

		if (barraCarregamento != null) {
			barraCarregamento.fillAmount = (progresso / 100.0f);
		}
	}

	public void PularCarregamento (){
		SceneManager.LoadScene("Menu 3D");
	}
}