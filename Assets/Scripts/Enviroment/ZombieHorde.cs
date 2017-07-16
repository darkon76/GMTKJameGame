using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHorde : MonoBehaviour {

    [SerializeField]    Transform SpawnPoint;
    [SerializeField]    Transform ForwardPoint;
    [SerializeField]    float SpawnForwardProbability = .15f;
    [MinMaxRange (-10,10)]
    [SerializeField]    RangedFloat Width = new RangedFloat(-3,3);
    [SerializeField]    GameObject[] ZombiePrefabs;

    [SerializeField]    int spawnPreCook = 30;
    [SerializeField]    float radiusSpawn = 6;
    private void Awake()
    {
        for(var i=0; i< spawnPreCook; ++i )
        {
            Spawn( );
        }
    }




    void Spawn()
    {
        var randomPos = Random.insideUnitCircle * radiusSpawn;
        var zombie = PoolObjectDictionary.Instance.Get(ZombiePrefabs.Random());
        zombie.transform.position = new Vector3( randomPos.x, 0, randomPos.y ) + SpawnPoint.position;
        zombie.SetActive( true );

    }

    public void Recycle(GameObject zombie)
    {
        var spawnForward = Random.value < SpawnForwardProbability;

        var randomPos = spawnForward? ForwardPoint.position: SpawnPoint.position;
        randomPos.z =   Width.RandomValue;
        zombie.transform.position = randomPos;

    }


}
