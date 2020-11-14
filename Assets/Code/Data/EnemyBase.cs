using UnityEngine;
using UnityEditor;

public class EnemyBase
{
    public EnemyType type;//类型.
    public int hp;//血量.
    public int atk;//攻击力.
    public int def;//防御力.
    public float atkSpeed;//攻速.
    public int moveSpeed;//移速.
    public float atkRange;//攻击范围,以怪物本身为中心的半径圆,近战为0.5.
    public bool fly;//是否是飞行单位.
}