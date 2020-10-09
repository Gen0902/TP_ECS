using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POO
{
    [DisallowMultipleComponent]
    public class Eat : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Virus"))
                Destroy(collision.gameObject);
        }
    }
}