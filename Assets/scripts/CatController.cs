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

				state = State.JUMPING_FORWARD;
			}
			else
			if (direction==SwipeRecognizer.SwipeDirection.Down)
			{
				animationController.SetTrigger("Slide_Up");

				state = State.SLIDING;
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