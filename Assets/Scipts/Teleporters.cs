using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] List<Transform> _teleporters;
    private Transform _currentTeleporter;

    private void Start()
    {
        StartCoroutine(ChangeTeleporterPeriodically(5f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            Transform _destination = GetRandomTeleporter();
            player.Teleport(_destination.position);
            Debug.Log("Teleporting");
        }

    }
    void OnDrawGizmos()
    {
        
        Gizmos.color = Color.blue;
        foreach (Transform teleporter in _teleporters)
        {
            Gizmos.DrawWireSphere(teleporter.position, 4f);
            var direction = teleporter.TransformDirection(Vector3.forward);
            Gizmos.DrawRay(teleporter.position, direction);
        }
    }

    Transform GetRandomTeleporter()
    {
        if (_teleporters.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, _teleporters.Count);
        return _teleporters[randomIndex];
    }

    void Update()
    {
        Transform _destination = GetRandomTeleporter();
        Debug.Log(_destination);
    }

    private IEnumerator ChangeTeleporterPeriodically(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            // Get a new random teleporter
            _currentTeleporter = GetRandomTeleporter();

            if (_currentTeleporter != null)
            {
                Debug.Log("Current teleporter changed");
            }
            else
            {
                Debug.LogWarning("No teleporters available");
            }
        }
    }
   
}
