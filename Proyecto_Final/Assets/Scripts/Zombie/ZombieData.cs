using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ZombieData", menuName = "Zombie Data")]
public class ZombieData : ScriptableObject
{
    public string ZombieName;
    public int hp;
    public int armored;
    public float distanceRay;
    public float speed;
    public float rangeOfView;
    public float minimDistan;

}
