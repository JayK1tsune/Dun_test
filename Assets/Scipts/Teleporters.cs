using JetBrains.Annotations;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] Transform _destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            player.Teleport(_destination.position);
            Debug.Log("Teleporting");
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_destination.position, 4f);
        var direction = _destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(_destination.position, direction);
    }
}
