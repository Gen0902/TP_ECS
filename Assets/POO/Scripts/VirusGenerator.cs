using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POO
{
    [DisallowMultipleComponent]
    public class VirusGenerator : MonoBehaviour
    {
        public GameObject virusPrefab;
        public Vector2 size;

        public float reloadTime = 2f;
        private float reloadProgress = 0f;

        private void Update()
        {
            reloadProgress += Time.deltaTime;
            if (reloadProgress >= reloadTime)
            {
                Vector2 position = new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.x / 2));

                Instantiate<GameObject>(virusPrefab, position, Quaternion.identity);
                reloadProgress = 0;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(Vector2.zero, size);
        }
    }
}