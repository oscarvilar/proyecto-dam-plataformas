using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour {

    private static GameMaster instance;
    public Vector3 ultimo_checkpoint;
    public string nivel;

    // Use this for initialization
    void Awake() {

        nivel = SceneManager.GetActiveScene().name;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
     }

}
