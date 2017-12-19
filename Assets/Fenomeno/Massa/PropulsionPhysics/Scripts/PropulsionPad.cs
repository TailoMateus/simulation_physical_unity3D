using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace Polycrime
{
    public class PropulsionPad : MonoBehaviour
    {
        public Transform target;
        public float reachTime = 1.5f;
        public Color trajectoryColor = Color.magenta;
        public bool showTrajectory = true;
		public Button reiniciar;
		public GameObject capsula;
		public InputField velocidade;
		public Text info;
		public GameObject pTarget;
		public Text cosseno;
		
		public Toggle toggle1;
		public Toggle toggle2;
		public Toggle toggle3;
		
		private float velocidadeF;
		private float velocidadeX;
		private float velocidadeY;
		private float segundos;
		private float distancia;
		private float valorX;
		private float valorRT;
		private string textToggle;
		private float cos;
		private float seno;

        protected virtual void Start()
        {
			reiniciar.onClick.AddListener(clickReiniciar);
			toggle1.onValueChanged.AddListener((x) => Invoke("MyFunction1", 0f));
			toggle2.onValueChanged.AddListener((x) => Invoke("MyFunction2", 0f));
			toggle3.onValueChanged.AddListener((x) => Invoke("MyFunction3", 0f));
			
			toggle1.transform.position = new Vector3 (((Screen.width) / 12) * 11.2f, (Screen.height / 12) * 10, 0);
			toggle2.transform.position = new Vector3 (((Screen.width) / 12) * 10.5f, (Screen.height / 12) * 10, 0);
			toggle3.transform.position = new Vector3 (((Screen.width) / 12) * 9.8f, (Screen.height / 12) * 10, 0);
			
			if(Screen.width < 1000){
				toggle1.transform.position = new Vector3 (((Screen.width) / 12) * 11f, (Screen.height / 12) * 9, 0);
				toggle2.transform.position = new Vector3 (((Screen.width) / 12) * 9f, (Screen.height / 12) * 9, 0);
				toggle3.transform.position = new Vector3 (((Screen.width) / 12) * 7f, (Screen.height / 12) * 9, 0);
			}
        }
		
		private void MyFunction1() {
			 if(toggle1.isOn) {
				toggle2.isOn = false;
				toggle3.isOn = false;
				
				cosseno.text = "cos: 0.86\nseno: 0.5";
			}
		 }
		 
		 private void MyFunction2() {
			if(toggle2.isOn) {
				toggle1.isOn = false;
				toggle3.isOn = false;
				
				cosseno.text = "cos: 0.70\nseno: 0.70";
			}
		 }
		 
		 private void MyFunction3() {
			if(toggle3.isOn) {
				toggle2.isOn = false;
				toggle1.isOn = false;
				
				cosseno.text = "cos: 0.5\nseno: 0.86";
			}
		 }
		
		void Update() {
			
		}

		void clickReiniciar() {
			capsula.transform.position = new Vector3 (-3.419778f, -0.06213951f, 6.324774f);
			velocidadeF = float.Parse(velocidade.text);
			
			if(toggle1.isOn) {
				seno = 0.5f;
				cos = 0.86f;
			}
			else if(toggle2.isOn) {
				seno = 0.70f;
				cos = 0.70f;
			}
			else if(toggle3.isOn) {
				seno = 0.86f;
				cos = 0.5f;
			}
			
			velocidadeX = velocidadeF * cos;
			velocidadeY = velocidadeF * seno;
			
			segundos = (velocidadeY / 10) * 2;
			distancia = velocidadeX * segundos;
			
			distancia = Mathf.Round(distancia * 100f) / 100f;
			
			valorX = velocidadeX / 10;
			valorRT = velocidadeY/100f + 1;
			
			reachTime = valorRT;
			pTarget.transform.position = new Vector3 (valorX, -1.373896f, 5.491088f);
			
			info.text = "VoX (m/s): "+velocidadeX+"\nVoY (m/s): "+velocidadeY+"\nAlcance (m): "+distancia;
		}
        ////////////////////////////////////////////////////////////////////////////////
        // When an object hits me, check to see if it implements the tsg_IPropelBehavior
        // interface and if it does call its implemented method.
        protected virtual bool PropelObject(GameObject propelObject, Vector3 velocity)
        {
            var objectInterface = propelObject.GetComponent(typeof(IPropelBehavior)) as IPropelBehavior;

            if (objectInterface != null)
            {
                objectInterface.React(velocity);
                return true;
            }

            return false;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            HandleTrigger(other.gameObject, other.bounds);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            HandleTrigger(other.gameObject, other.bounds);
        }

        private void HandleTrigger(GameObject gameObject, Bounds bounds)
        {
            if (PropulsionPadActive())
            {
                Vector3 veloctiy = TrajectoryMath.CalculateVelocity(bounds.center, target.position, reachTime);
                PropelObject(gameObject, veloctiy);
            }
        }

        private void OnDrawGizmos()
        {
            if (showTrajectory && PropulsionPadActive())
            {
                TrajectoryLine.Render(transform.position, target.position, reachTime, trajectoryColor);
            }
        }

        private bool PropulsionPadActive()
        {
            return (enabled && target != null && reachTime > 0);
        }
    }
}