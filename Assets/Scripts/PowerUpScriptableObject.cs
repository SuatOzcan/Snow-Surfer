using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PowerUpScriptableObject", menuName = "Scriptable Objects/PowerUpScriptableObject")]
public class PowerUpScriptableObject : ScriptableObject
{
    [SerializeField]
    string _powerUpType;
    [SerializeField]
    float _valueChange;
    [SerializeField]
    public float _time;


    public enum _powerupTypes { speed, torque };
    [SerializeField]
    _powerupTypes[] _powerupTypesArray;

    
    public _powerupTypes GetPowerupType()
    {
        return _powerupTypesArray[0];
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
