using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDirector : MonoBehaviour {
    private FloorSpawner[] _floors = new FloorSpawner[2];
    private FloorSpawner _walls;
    private BlocksSpawner _blockSpawner;

    [SerializeField]
    public List<RoomSO> PosibleRooms = new List<RoomSO>();
    [SerializeField]
    private RoomSO _currentRoom;

    [SerializeField] float DistanceToNextRoom;

    public RoomSO CurrentRoom
    {
        set
        {
            _currentRoom = value;
            SetCurrentRoom( );
        }
    }


    [MinMaxRange(50,1000)]
    [SerializeField]
    RangedFloat ChangeLevelDistances  =  new RangedFloat(100, 500);

    [Header("Debug")]
    [SerializeField]
    private  float _nextRoomPosition = 0;
	// Use this for initialization
	void Awake () {
        var floorSpawners = GetComponentsInChildren<FloorSpawner>();
        _floors[0] = floorSpawners[0];
        _floors[1] = floorSpawners[1];
        _walls = floorSpawners[2];
        _blockSpawner = GetComponentInChildren<BlocksSpawner>( );
        _nextRoomPosition = _blockSpawner.transform.position.x;
    }
	
    private void SetCurrentRoom()
    {
        _floors[0].GapProbability = _currentRoom.LavaFloorProb.RandomValue;
        _floors[1].GapProbability = _currentRoom.LavaFloorProb.RandomValue;
        _blockSpawner.BoxTileProbability = _currentRoom.BoxProb.RandomValue;
        _blockSpawner.BlockerTileProbability = _currentRoom.BlockerProb.RandomValue;
    }

#if UNITY_EDITOR

    private void OnValidate()
    {
        CurrentRoom = _currentRoom;
    }
#endif

    // Update is called once per frame
    void Update () {

        DistanceToNextRoom = _blockSpawner.transform.position.x - _nextRoomPosition;

        if( DistanceToNextRoom  >0)
        {
            var posibleRoom = PosibleRooms.Random( );
            if(posibleRoom == _currentRoom)
                posibleRoom = PosibleRooms.Random( );
            CurrentRoom = posibleRoom;
            _nextRoomPosition += ChangeLevelDistances.RandomValue;
        }
	}
}
