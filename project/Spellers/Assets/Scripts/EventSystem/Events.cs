using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace CustomEventSystem
{
    public static class Events
    {
        // Eventos de la partida:
        public static readonly CustomEvent OnBattleBegins = new CustomEvent();
        public static readonly CustomEvent<bool> OnBattleEnds = new CustomEvent<bool>();
        public static readonly CustomEvent OnJoinPlayer = new CustomEvent();
        public static readonly CustomEvent<int> OnJoinEnemy = new CustomEvent<int>();

        // Eventos del jugador:
        public static readonly CustomEvent<int> OnSelectSpellSlot = new CustomEvent<int>();
        public static readonly CustomEvent<int, int> OnSelectKey = new CustomEvent<int, int>();
        public static readonly CustomEvent<bool> OnCheckKey = new CustomEvent<bool>();
        public static readonly CustomEvent OnCompleteWord = new CustomEvent();
        public static readonly CustomEvent<int> OnSelectTarget = new CustomEvent<int>();

        // Eventos de los enemigos:
    }
}