using UnityEngine;
using System.Collections;

public class InstanciadorVelocidade : MonoBehaviour {

	public Vector3 PosicaoParaInstanciar;
	public float RotacaoX, RotacaoY, RotacaoZ; 
	public GameObject[] Players;

	void Start () {
		Instantiate (Players [DataVelocidade.PersonagemVelocidadeInstanciar], PosicaoParaInstanciar, Quaternion.Euler(RotacaoX, RotacaoY, RotacaoZ));
	}
}
