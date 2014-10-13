
using System;
namespace CatsBoxes
{
	public class AppEvents
	{
		public static event Action<CatsBoxes.SwipeRecognizer.SwipeDirection> SwipeEvent;
		public static void OnSwipe(CatsBoxes.SwipeRecognizer.SwipeDirection direction)
		{
			if(SwipeEvent!=null)
				SwipeEvent(direction);
		}
	}
}

