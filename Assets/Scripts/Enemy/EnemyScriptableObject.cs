using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    public float visionDis = 10;
    public LayerMask player;
}
