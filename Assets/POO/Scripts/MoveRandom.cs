using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POO
{
    public class MoveRandom : MonoBehaviour
    {
        public Vector2 fieldSize;
        public float speed;

        Vector3 target = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {
            target = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position == target)
                target = GetRandomPosition();

            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        private Vector2 GetRandomPosition()
        {
            return new Vector2(Random.Range(-fieldSize.x / 2, fieldSize.x / 2), Random.Range(-fieldSize.y / 2, fieldSize.y / 2));
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(Vector2.zero, fieldSize);
        }
    }
}