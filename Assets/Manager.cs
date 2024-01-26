using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    public List<GameObject> Heros { get; internal set; }

    private void Awake()
    {
        _instance = this;
        if(Ui.gameObject == false)
        {
            Ui.SetActive(true);
        }
    
    
    }
    [SerializeField] SpawnRoom spawnRoom;
    [SerializeField] GameObject Ui;
    [SerializeField] Animator animator;
    [SerializeField] GameObject InGameUi;
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
        //add heros to the list of heros
        

    }
    private void GameStarted(){
        Ui.SetActive(false);
        animator.gameObject.SetActive(false);
        InGameUi.SetActive(true);

        
        //animator.Play("Pan_To_Start 0");
    }



}
