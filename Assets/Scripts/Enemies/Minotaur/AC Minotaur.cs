using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACMinotaur
{
    public static class State
    {
        public const string MinotaurIdle = nameof(MinotaurIdle);
        public const string MinotaurRun = nameof(MinotaurRun);
        public const string MinotaurSawPlayer = nameof(MinotaurSawPlayer);
        public const string MinotaurAttack = nameof(MinotaurAttack);
        public const string MinotaurSuperAttak = nameof(MinotaurSuperAttak);
        public const string MinotaurDied = nameof(MinotaurDied);
        public const string MinotaurTakeDamage = nameof(MinotaurTakeDamage);
    }

    public static class Params
    {
        
    }
}
