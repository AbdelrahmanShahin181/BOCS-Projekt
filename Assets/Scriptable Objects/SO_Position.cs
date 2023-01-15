using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Position", menuName = "Character Position")]
public class SO_Position : ScriptableObject
{
    public float x;
    public float y;
    public int layer;
    public int hp;
    public int kaffeeCoins;
    public int TimelineLevel;
}
