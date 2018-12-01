using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float CameraShakeIntesity = 1;
    public float CameraShakeDecay = 0.1f;

    public static GameManager Instance;

    public CameraShake CameraShake;

    public Player Player1;
    public Player Player2;

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        Player1.Start();
        Player2.Start();

        CameraShake = Camera.main.transform.GetComponent<CameraShake>();
    }
    
    void Update () {
        if (Player1.PowerLevel < 0) {
            Player1.PowerLevel = 0;
        }
        
        if (Player2.PowerLevel < 0) {
            Player2.PowerLevel = 0;
        }

        if (Input.GetKeyDown("space")) {
            CameraShake.Shake(CameraShakeIntesity, CameraShakeDecay);
        }
        
    }
}
