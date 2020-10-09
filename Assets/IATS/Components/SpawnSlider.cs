using UnityEngine;
using UnityEngine.UI;

public class SpawnSlider : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
    public Text label;
    public Slider slider;
    public EUnitType type;
}

public enum EUnitType
{
    Worker,
    Guard,
    Explorator
}