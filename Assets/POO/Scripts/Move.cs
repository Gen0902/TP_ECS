using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POO
{
    [DisallowMultipleComponent]
    public class Move : MonoBehaviour
    {
        public float speed = 2.5f;

        // Update is called once per frame
        void Update()
        {
            Vector3 movement = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftArrow))
                movement += Vector3.left;
            if (Input.GetKey(KeyCode.RightArrow))
                movement += Vector3.right;
            if (Input.GetKey(KeyCode.UpArrow))
                movement += Vector3.up;
            if (Input.GetKey(KeyCode.DownArrow))
                movement += Vector3.down;

            transform.position += movement * speed * Time.deltaTime;


        }


    }

}
