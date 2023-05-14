using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ACPlayer
{
    public static class State
    {
        public const string IdleWithoutEnemy = nameof(IdleWithoutEnemy);
        public const string SawEnemies = nameof(SawEnemies);
        public const string WhaitingForEnemies = nameof(WhaitingForEnemies);
        public const string AxeAttack = nameof(AxeAttack);
        public const string RunWhithAxeWithoutEnemy = nameof(RunWhithAxeWithoutEnemy);
    }

    public static class Params
    {
        public const string Speed = nameof(Speed);
    }
}
