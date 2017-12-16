using UnityEngine;
using _Scripts.GUI;
using _Scripts.Tooltips;

namespace _Scripts.Objects
{
	public class InteractiveObject : MonoBehaviour
	{
		[SerializeField] private ScriptableToolTips _toolTip;

		public void Interact()
		{
			DialogueManager.Instance.Show("I am a test");
		}
	}
}
