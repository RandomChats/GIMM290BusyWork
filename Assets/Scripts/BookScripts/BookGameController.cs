using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGameController : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemySpawn;
    private GameObject enemy;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (enemy == null) {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = enemySpawn.transform.position;
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
