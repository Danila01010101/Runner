using System;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public Action CollisionHappened;

    private void OnTriggerEnter(Collider other)
    {
        CollisionHappened();
    }
}
