using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpScriptableObject", menuName = "Scriptable Objects/PowerUpScriptableObject")]
public class PowerUpScriptableObject : ScriptableObject
{
    [SerializeField]
    string _powerUpType;
    [SerializeField]
    float _valueChange;
    [SerializeField]
    float _time;

    public string GetPowerupType()
    {
        return _powerUpType;
    }

    public float GetValueChange()
    {
        return _valueChange;
    }

    public float GetTime()
    {
        return _time;
    }
}
