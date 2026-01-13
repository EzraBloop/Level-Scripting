using UnityEngine;
using System.Collections.Generic;

public class DataSreuctureExample : MonoBehaviour
{
    public List<int> integers = new List<int>();
    public Dictionary<int, Pokemon> pokedex = new Dictionary<int, Pokemon>(); //Dictionaries use an identifier then the data it relates to 

    private void Start()
    {
        Pokemon mewtwo = new Pokemon();
        mewtwo.pokemonName = "Mewtwo";
        mewtwo.descirption = "mew but two";
        mewtwo.baseStats = new BaseStats(100, 50, 65, 120, 11, 100);

        pokedex.Add(151, mewtwo);

        Debug.Log(pokedex[151].pokemonName);
    }
}


public class Pokemon
{
    public string pokemonName;
    public string descirption;
    public Sprite sprite;
    public BaseStats baseStats;
}

public enum VehicleType
{
    CART,
    BIKE,
    BOAT
}

public class BaseStats
{
     public int HP, ATK, DEF, SATK, SDEF, SPD;

    public BaseStats(int hp, int atk, int def, int satk, int sdef, int spd)
    {
        HP = hp;
        ATK = atk;
        DEF = def;
        SATK = satk;
        SDEF = sdef;
        SPD = spd;
    }
}