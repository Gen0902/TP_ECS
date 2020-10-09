using UnityEngine;

    public class Board : MonoBehaviour
    {
        // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
        public Vector2 size;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(Vector3.zero, size);
        }
    }
