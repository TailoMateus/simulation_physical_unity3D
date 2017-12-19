using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class conf : MonoBehaviour {

 public Slider BarraVolume;
 public Dropdown Resolucoes, Qualidades;
 public Button BotaoVoltar, BotaoSalvarPref;
 public Text textoVol;
 private float VOLUME;
 private int qualidadeGrafica, resolucaoSalveIndex;
 private Resolution[] resolucoesSuportadas;

 void Awake(){
 DontDestroyOnLoad (transform.gameObject);
 resolucoesSuportadas = Screen.resolutions;
 }

 void Start () {
 BotaoVoltar.transform.position = new Vector3 (((Screen.width) / 12) * 2, (Screen.height / 12) * 2, 0);
 BotaoSalvarPref.transform.position = new Vector3 (((Screen.width) / 12) * 10, (Screen.height / 12) * 2, 0);

 Qualidades.transform.position = new Vector3 (((Screen.width) / 12) * 5, (Screen.height / 12) * 7, 0);
 Resolucoes.transform.position = new Vector3 (((Screen.width) / 12) * 7, (Screen.height / 12) * 7, 0);

 textoVol.transform.position = new Vector3 (((Screen.width) / 12) * 6, ((Screen.height - 20) / 12) * 5, 0);
 BarraVolume.transform.position = new Vector3 (((Screen.width) / 12) * 7, (Screen.height / 12) * 5, 0);
 
 if(Screen.width < 1000){
	BotaoVoltar.transform.position = new Vector3 (((Screen.width) / 12) * 3, (Screen.height / 12) * 2, 0);
	BotaoSalvarPref.transform.position = new Vector3 (((Screen.width) / 12) * 9, (Screen.height / 12) * 2, 0);

	Qualidades.transform.position = new Vector3 (((Screen.width) / 12) * 3, (Screen.height / 12) * 9, 0);
	Resolucoes.transform.position = new Vector3 (((Screen.width) / 12) * 9, (Screen.height / 12) * 9, 0);

	textoVol.transform.position = new Vector3 (((Screen.width) / 12) * 5, ((Screen.height - 30) / 12) * 6, 0);
	BarraVolume.transform.position = new Vector3 (((Screen.width) / 12) * 7, (Screen.height / 12) * 6, 0);
 }

 Opcoes (true);
 ChecarResolucoes ();
 AjustarQualidades ();
 //
 if (PlayerPrefs.HasKey ("RESOLUCAO")) {
 int numResoluc = PlayerPrefs.GetInt ("RESOLUCAO");
 if (resolucoesSuportadas.Length <= numResoluc) {
 PlayerPrefs.DeleteKey ("RESOLUCAO");
 }
 }
 //
 Cursor.visible = true;
 Time.timeScale = 1;
 //
 BarraVolume.minValue = 0;
 BarraVolume.maxValue = 1;

 //=============== SAVES===========//
 if (PlayerPrefs.HasKey ("VOLUME")) {
 VOLUME = PlayerPrefs.GetFloat ("VOLUME");
 BarraVolume.value = VOLUME;
 } else {
 PlayerPrefs.SetFloat ("VOLUME", 1);
 BarraVolume.value = 1;
 }
 //=============MODO JANELA===========//

 Screen.fullScreen = true;
 
 //========RESOLUCOES========//
 if (PlayerPrefs.HasKey ("RESOLUCAO")) {
 resolucaoSalveIndex = PlayerPrefs.GetInt ("RESOLUCAO");
 Screen.SetResolution(resolucoesSuportadas[resolucaoSalveIndex].width,resolucoesSuportadas[resolucaoSalveIndex].height,true);
 Resolucoes.value = resolucaoSalveIndex;
 } else {
 resolucaoSalveIndex = (resolucoesSuportadas.Length -1);
 Screen.SetResolution(resolucoesSuportadas[resolucaoSalveIndex].width,resolucoesSuportadas[resolucaoSalveIndex].height,true);
 PlayerPrefs.SetInt ("RESOLUCAO", resolucaoSalveIndex);
 Resolucoes.value = resolucaoSalveIndex;
 }
 //=========QUALIDADES=========//
 if (PlayerPrefs.HasKey ("qualidadeGrafica")) {
 qualidadeGrafica = PlayerPrefs.GetInt ("qualidadeGrafica");
 QualitySettings.SetQualityLevel(qualidadeGrafica);
 Qualidades.value = qualidadeGrafica;
 } else {
 QualitySettings.SetQualityLevel((QualitySettings.names.Length-1));
 qualidadeGrafica = (QualitySettings.names.Length-1);
 PlayerPrefs.SetInt ("qualidadeGrafica", qualidadeGrafica);
 Qualidades.value = qualidadeGrafica;
 }

 // =========SETAR BOTOES==========//
 BotaoVoltar.onClick = new Button.ButtonClickedEvent();
 BotaoSalvarPref.onClick = new Button.ButtonClickedEvent();
 BotaoVoltar.onClick.AddListener(() => VoltarPreferencias());
 BotaoSalvarPref.onClick.AddListener(() => SalvarPreferencias());

 }
 //=========VOIDS DE CHECAGEM==========//
 private void ChecarResolucoes(){
 Resolution[] resolucoesSuportadas = Screen.resolutions;
 Resolucoes.options.Clear ();
 for(int y = 0; y < resolucoesSuportadas.Length; y++){
 Resolucoes.options.Add(new Dropdown.OptionData() { text = resolucoesSuportadas[y].width + "x" + resolucoesSuportadas[y].height });
 }
 Resolucoes.captionText.text = "Resolucao";
 }
 private void AjustarQualidades(){
 string[] nomes = QualitySettings.names;
 Qualidades.options.Clear ();
 for(int y = 0; y < nomes.Length; y++){
 Qualidades.options.Add(new Dropdown.OptionData() { text = nomes[y] });
 }
 Qualidades.captionText.text = "Qualidade";
 }
 private void Opcoes(bool ativarOP){
 //
 textoVol.gameObject.SetActive (ativarOP);
 BarraVolume.gameObject.SetActive (ativarOP);
 Resolucoes.gameObject.SetActive (ativarOP);
 Qualidades.gameObject.SetActive (ativarOP);
 BotaoVoltar.gameObject.SetActive (ativarOP);
 BotaoSalvarPref.gameObject.SetActive (ativarOP);
 }
 //=========VOIDS DE SALVAMENTO==========//
 private void VoltarPreferencias() {
	 SceneManager.LoadScene("Menu 3D");
 }
 
 private void SalvarPreferencias(){
 PlayerPrefs.SetFloat ("VOLUME", BarraVolume.value);
 PlayerPrefs.SetInt ("qualidadeGrafica", Qualidades.value);
 PlayerPrefs.SetInt ("RESOLUCAO", Resolucoes.value);
 resolucaoSalveIndex = Resolucoes.value;
 AplicarPreferencias ();
 SceneManager.LoadScene("Menu 3D");
 }
 private void AplicarPreferencias(){
 VOLUME = PlayerPrefs.GetFloat ("VOLUME");
 QualitySettings.SetQualityLevel(PlayerPrefs.GetInt ("qualidadeGrafica"));
 Screen.SetResolution(resolucoesSuportadas[resolucaoSalveIndex].width,resolucoesSuportadas[resolucaoSalveIndex].height,true);
 }
 //===========VOIDS NORMAIS=========//
 void Update(){
 AudioListener.volume = VOLUME;
 }
}