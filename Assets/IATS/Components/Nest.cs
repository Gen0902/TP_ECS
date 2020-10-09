using UnityEngine;

public class Nest : MonoBehaviour
{
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).

    public float spawnRate = 2.5f;
    [HideInInspector] public float timer;

    public GameObject workerPrefab;
    public GameObject guardPrefab;
    public GameObject exploratorPrefab;
}