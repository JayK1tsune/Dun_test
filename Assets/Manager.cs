using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager  : MonoBehaviour
{
    private static Manager _instance;
    public static Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Manager");
                go.AddComponent<Manager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    [SerializeField] SpawnRoom spawnRoom;
    [SerializeField] GameObject Ui;
    [SerializeField] Animator animator;
    private bool hasPlayed = false;
   
  

    private void Start() {

        Button btn = spawnRoom.GetButton();
        animator = animator.GetComponent<Animator>();
    

        if (btn != null)
        {
            btn.onClick.AddListener(GameStarted);
        }
        else
        {
            Debug.LogError("Button reference is null in Manager script.");
        }
        
    }

    private void Update() {


    }
    private void GameStarted(){
        Ui.SetActive(false);
        animator.Play("Pan_To_Start 0");
    }



}
