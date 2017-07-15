using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class WeaponSO: ScriptableObject
{
    public GameObject Model;
    public GameObject Projectile;
    public RandomBoxAudio Audio;
    public float AtacksPerSecond=3;
    public float ChargePercentage;
    public float MaxChargeTime;
    public List<ShootCharges> _shootCharges;
}
