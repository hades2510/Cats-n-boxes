using UnityEngine;
using System.Collections;

namespace CatsBoxes
{
	public class CatController : MonoBehaviour {

		public const float NORMAL_RUN_STEP = 0.02f;
		private const string RunAnimation = "A_run";
		private const string JumpAnimation = "A_jump_all";
		private const string SlideAnimation = "A_play";

		public Animation animation;

		// Use this for initialization
		void Start () {
			animation.wrapMode = WrapMode.Loop;
			var jumpAnim = animation.GetClip(JumpAnimation);
			jumpAnim.AddEvent(new AnimationEvent() {functionName="jumpAnimationFinished", time= jumpAnim.length});
			var slideAnim = animation.GetClip(SlideAnimation);
			slideAnim.AddEvent(new AnimationEvent() {functionName="jumpAnimationFinished", time= slideAnim.length});

			animation.Play (RunAnimation);
			animation.wrapMode = WrapMode.Loop;
			AppEvents.SwipeEvent += DoAction;
		}

		private void jumpAnimationFinished()
		{
			animation.Play (RunAnimation);
			animation.wrapMode = WrapMode.Loop;
		}

		public void DoAction(SwipeRecognizer.SwipeDirection direction)
		{
			if (direction==SwipeRecognizer.SwipeDirection.Up)
			{
				animation.Play (JumpAnimation);
				animation.wrapMode = WrapMode.Once;
			}
			else
			if (direction==SwipeRecognizer.SwipeDirection.Down)
			{
				animation.Play (SlideAnimation);
				animation.wrapMode = WrapMode.Once;
			}
		}
		
		// Update is called once per frame
		void Update () {
			var tr = gameObject.transform.parent.transform.localPosition;
			tr.z += NORMAL_RUN_STEP;
			gameObject.transform.parent.transform.localPosition = tr;
		}
	}
}