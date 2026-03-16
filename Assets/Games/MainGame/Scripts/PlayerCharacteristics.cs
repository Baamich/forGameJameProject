using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{   
    public int hpMax;
    public int hp;
    public int heals;
    void Start()
    {
        hp = hpMax;
    }
}
