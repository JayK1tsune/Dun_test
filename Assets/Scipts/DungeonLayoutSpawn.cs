using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DungeonLayout
{
    [CreateAssetMenu(fileName = "DungeonLayoutSpawn", menuName = "")]
    public class DungeonLayoutSpawn : ScriptableObject
    {
        [Tooltip("The name of the room")]
        public string roomName;
        [Tooltip("The room prefab")]
        public GameObject roomPrefab;
        [Tooltip("The room Type")]
        public string roomType;
        [Tooltip("Colour of the room")]
        public Color roomColor;
        private Renderer roomColorTemp;

        void OnEnable()
        {
            roomColorTemp = roomPrefab.GetComponent<Renderer>();
            roomColorTemp.sharedMaterial.color = roomColor;
            Debug.Log("Awake");
        }
        void OnDisable()
        {
            roomColorTemp = roomPrefab.GetComponent<Renderer>();
            roomColorTemp.sharedMaterial.color = Color.white;
            Debug.Log("Disable");
        }
    }
}

