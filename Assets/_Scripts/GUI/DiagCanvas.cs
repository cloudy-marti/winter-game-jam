using DG.Tweening;
using UnityEngine;

namespace _Scripts.GUI
{
	public class DiagCanvas : MonoBehaviour
	{
		private CanvasGroup _canvasGroup;

		// Use this for initialization
		void Start ()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			_canvasGroup.DOFade(1f, 1f);
		}
	}
}
