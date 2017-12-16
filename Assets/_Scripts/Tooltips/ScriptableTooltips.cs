using UnityEngine;

namespace _Scripts.Tooltips
{
	[CreateAssetMenu(fileName = "Tooltips", menuName = "Other/ObjectTooltip", order = 1)]
	public class ScriptableToolTips : ScriptableObject
	{

		[SerializeField] public string Description = "The developper forgot to add a description on this object, SHAME ON THEM !";
	}
}
