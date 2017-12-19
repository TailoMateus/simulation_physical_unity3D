using UnityEngine;
using System.Collections;

public class Instanciador : MonoBehaviour {

	public Vector3 PosicaoParaInstanciar;
	public float RotacaoX, RotacaoY, RotacaoZ; 
	public GameObject[] Players;

	void Start () {
		Instantiate (Players [Data.PlanetaInstanciar], PosicaoParaInstanciar, Quaternion.Euler(RotacaoX, RotacaoY, RotacaoZ));
	}
}
