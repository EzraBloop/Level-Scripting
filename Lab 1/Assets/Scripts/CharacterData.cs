using UnityEngine;

public class CharacterData
{
    public string characterName;
    public Sprite portrait;
    public CharacterStats stats;
    public CharacterData(CharacterSO config)
    {
        characterName = config.charactnname;
        portrait = config.portrait;

        
    }
}
