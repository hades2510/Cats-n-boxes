using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CatsBoxes
{
	public class CatController : MonoBehaviour {

		private const string RunAnimation = "A_run";
		private const string JumpAnimation = "A_jump_all";
		private const string SlideAnimation = "A_play";
		private Animator animationController;
		public float StrafeForceX = 3000f;		
		public float StrafeForceY = 200f;
		public float JumpForceY = 4000f;

		private enum State
		{
			RUNNING,
			JUMPING_FORWARD,
			JUMPING_UP,
			SLIDING
		}

		private Dictionary<State, float> stateToSpeed = new Dictionary<State, float>(){
			{ State.RUNNING, 15f },
			{ State.JUMPING_FORWARD, 15f },
			{ State.SLIDING, 17f },
			{ State.JUMPING_UP, 0.0f }
		};

		private State state;

		// Use this for initialization
		void Start () {
			animationController = this.GetComponent<Animator> ();

			AppEvents.SwipeEvent += DoAction;

			state = State.RUNNING;
		}

		public void DoAction(SwipeRecognizer.SwipeDirection direction)
		{
			if (direction==SwipeRecognizer.SwipeDirection.Up)
			{
				animationController.SetTrigger("Jump");
				
				this.rigidbody.AddForce(0f, JumpForceY, 0f);
				state = State.JUMPING_FORWARD;
			}
			else
			if (direction==SwipeRecognizer.SwipeDirection.Down)
			{
				animationController.SetTrigger("Slide_Up");
				state = State.SLIDING;
			}
			else
				if (direction==SwipeRecognizer.SwipeDirection.Left)
			{
				animationController.SetTrigger("StrafeLeft");
				this.rigidbody.AddForce(-StrafeForceX,StrafeForceY,0f);
				state = State.RUNNING;
			}
			else
				if (direction==SwipeRecognizer.SwipeDirection.Right)
			{
				animationController.SetTrigger("StrafeRight");
				this.rigidbody.AddForce(StrafeForceX,StrafeForceY,0f);
				state = State.RUNNING;
			}
		}
		
		// Update is called once per frame
		void Update () {
			var tr = gameObject.transform.parent.transform.localPosition;

			tr.z += Time.deltaTime*stateToSpeed[ state ];
			gameObject.transform.parent.transform.localPosition = tr;
		}
	}
}