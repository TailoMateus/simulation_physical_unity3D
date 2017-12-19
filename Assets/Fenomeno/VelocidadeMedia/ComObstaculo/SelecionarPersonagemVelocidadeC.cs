using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelecionarPersonagemVelocidadeC : MonoBehaviour {

	public Texture[] PersonagemVelocidade;
	private int SelecaoAtual;

	void Start() {
		SelecaoAtual = 0;
	}

	void OnGUI() {
		
		float width = 240;
		float height = 220;
		
		float widthProximoAnterior = 100;
		float heightProximoAnterior = 60;
		
		//Posição width, posição height, tamanho width, tamanho height

		if (GUI.Button (new Rect ((Screen.width - width) / 2f, (Screen.height - height) / 2f, width - 10f, height - 10f), "")) {
			DataVelocidade.PersonagemVelocidadeInstanciar = SelecaoAtual;
			SceneManager.LoadScene("VelocidadeMediaC");
		}

		if (SelecaoAtual == 0) {
			GUI.DrawTexture (new Rect ((Screen.width / 2) - (width/2), (Screen.height / 2) - (height/2), width, height), PersonagemVelocidade [SelecaoAtual]);
			if (GUI.Button (new Rect ((Screen.width / 2f) + 150, (Screen.height - heightProximoAnterior) / 2f, widthProximoAnterior, heightProximoAnterior), "Próximo")) {
				SelecaoAtual = SelecaoAtual + 1;
			}
		}

		if (SelecaoAtual > 0 && SelecaoAtual < (PersonagemVelocidade.Length - 1)) {
			GUI.DrawTexture (new Rect ((Screen.width / 2) - (width/2), (Screen.height / 2) - (height/2), width, height), PersonagemVelocidade [SelecaoAtual]);

			if (GUI.Button (new Rect ((Screen.width / 2f) + 150, (Screen.height - heightProximoAnterior) / 2f, widthProximoAnterior, heightProximoAnterior), "Próximo")) {
				SelecaoAtual = SelecaoAtual + 1;
			}

			if (GUI.Button (new Rect ((Screen.width / 2f - widthProximoAnterior) - 150, (Screen.height - heightProximoAnterior) / 2f, widthProximoAnterior, heightProximoAnterior), "Anterior")) {
				SelecaoAtual = SelecaoAtual - 1;
			}
		}

		if (SelecaoAtual >= (PersonagemVelocidade.Length - 1)) {
			GUI.DrawTexture (new Rect ((Screen.width / 2) - (width/2), (Screen.height / 2) - (height/2), width, height), PersonagemVelocidade [SelecaoAtual]);

			if (GUI.Button (new Rect ((Screen.width / 2f - widthProximoAnterior) - 150, (Screen.height - heightProximoAnterior) / 2f, widthProximoAnterior, heightProximoAnterior), "Anterior")) {
				SelecaoAtual = SelecaoAtual - 1;
			}
		}
	}
}
