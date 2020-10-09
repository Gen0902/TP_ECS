using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class SpawnSliderSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void UpdateSlider(SpawnSlider spawnSlider)
	{
		MainLoop.callAppropriateSystemMethod ("SpawnSliderSystem", "UpdateSlider", spawnSlider);
	}

}