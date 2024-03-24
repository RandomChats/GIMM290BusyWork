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
            float height = Random.Range(2, 4);
            Vector3 change = new Vector3(1, height, 1);
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.localScale = change;
            Color randomColor = new Color(Random.Range(0, 255)/255f, Random.Range(0, 255)/255f, Random.Range(0, 255)/255f, 0.75f);
            var enemyRenderer = enemy.GetComponent<Renderer>();
            enemyRenderer.material.color = randomColor;
            Debug.Log(randomColor);
            enemy.transform.position = enemySpawn.transform.position;
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
