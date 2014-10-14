using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CatsBoxes
{
	public class CatController : MonoBehaviour {

		private const string RunAnimation = "A_run";
		private const string JumpAnimation = "A_jump_all";
		private const string SlideAnimation = "A_play";

		private enum State
		{
			RUNNING,
			JUMPING_FORWARD,
			JUMPING_UP
		}

		private Dictionary<State, float> stateToSpeed = new Dictionary<State, float>(){
			{ State.RUNNING, 15f },
			{ State.JUMPING_FORWARD, 12f },
			{ State.JUMPING_UP, 0.0f }
		};

		private State state;

		public Animation animation;

		// Use this for initialization
		void Start () {
			animation.wrapMode = WrapMode.Loop;

			var jumpAnim = animation.GetClip(JumpAnimation);
			jumpAnim.AddEvent(new AnimationEvent() {functionName="jumpAnimationFinished", time=jumpAnim.length});

			var slideAnim = animation.GetClip(SlideAnimation);
			slideAnim.AddEvent(new AnimationEvent() {functionName="jumpAnimationFinished", time=slideAnim.length});

			animation.Play (RunAnimation);
			animation.wrapMode = WrapMode.Loop;

			AppEvents.SwipeEvent += DoAction;

			state = State.RUNNING;
		}

		private void jumpAnimationFinished()
		{
			animation.CrossFade (RunAnimation);
			animation.wrapMode = WrapMode.Loop;

			state = State.RUNNING;
		}

		public void DoAction(SwipeRecognizer.SwipeDirection direction)
		{
			if (direction==SwipeRecognizer.SwipeDirection.Up)
			{
				animation.Play (JumpAnimation);
				animation.wrapMode = WrapMode.Once;

				state = State.JUMPING_FORWARD;
			}
			else
			if (direction==SwipeRecognizer.SwipeDirection.Down)
			{
				animation.Play (SlideAnimation);
				animation.wrapMode = WrapMode.Once;

				state = State.JUMPING_UP;
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