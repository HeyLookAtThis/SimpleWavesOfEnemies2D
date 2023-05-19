using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACBandit
{
    public static class State
    {
        public const string BanditAttack = nameof(BanditAttack);
        public const string BanditDie = nameof(BanditDie);
        public const string BanditTakeDamage = nameof(BanditTakeDamage);
        public const string BanditIdle = nameof(BanditIdle);
        public const string BanditRun = nameof(BanditRun);
    }

    public static class Params
    {

    }
}
