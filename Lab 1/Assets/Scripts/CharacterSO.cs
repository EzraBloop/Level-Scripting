using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSO : ScriptableObject
{
    public string charactnname;
    public Sprite portrait;
}

[Serializable]
public class CharacterStats
{
    public int maxHP;
    public int currentHP;
    public int maxSP;
    public int currentSP;
    public int Atk;
    public int Def;

    public CharacterStats(CharacterStats stats)
    {

    }

}