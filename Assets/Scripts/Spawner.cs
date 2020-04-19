using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int spawnTime;
    public GameObject dummy;
    public GameObject player;
    public List<GameObject> dummyPool;
    void Start()
    {
        for(int i = 1; i<=10; i++){
            Spawn(i*spawnTime);
        }
        // InvokeRepeating("Spawn", 0, spawnTime);
        // Invoke("Spawn", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(float x){
        GameObject tmp = Instantiate(dummy);
        tmp.transform.position = new Vector3((player.transform.position.x + x), (this.transform.position.y + Random.Range(-2f, 2f)), player.transform.position.z);
        dummyPool.Add(tmp);
    }

    public float Getlast(){
        return dummyPool[dummyPool.Count-1].transform.position.y;
    }

    public int GetSpawnTime(){
        return spawnTime;
    }

    public void Shuffle(int condition){
        if(condition == 1){
            for(int i = 0; i<4; i++){
                GameObject tmp = dummyPool[i];
                tmp.transform.position = new Vector3(tmp.transform.position.x, (this.transform.position.y + Random.Range(-2f, 2f)), tmp.transform.position.z);
            }
        }else{
            for(int i = 4; i<10; i++){
                GameObject tmp = dummyPool[i];
                tmp.transform.position = new Vector3(tmp.transform.position.x, (this.transform.position.y + Random.Range(-2f, 2f)), tmp.transform.position.z);
            }
        }
    }
}
