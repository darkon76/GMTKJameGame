using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "RoomSO", menuName = "ScriptableObjects/RoomSO" )]
public class RoomSO : ScriptableObject
{
    [MinMaxRange(0,75)]
    public RangedFloat LavaFloorProb;
    [MinMaxRange(0,20f)]
    public RangedFloat BoxProb;
    [MinMaxRange(0,20f)]
    public RangedFloat BlockerProb;
}
