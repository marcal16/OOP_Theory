using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static PlayerManager Instance {get; private set;}
    public GameObject currentController;
    [SerializeField] private GameObject playerEntity;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    void Start()
    {
        if (currentController = null)
        {
            ChangeController(playerEntity);
        }
    }
        
    public void ChangeController(GameObject controller)
    {
        currentController = controller;
    }

}
