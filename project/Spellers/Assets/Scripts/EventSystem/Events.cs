using SpellSystem;
using System.Collections.Generic;

namespace CustomEventSystem
{
    public static class Events
    {
        // Eventos del modo historia:
        public static readonly CustomEvent<int> OnSelectLevel = new CustomEvent<int>();

        // Eventos de la partida:
        public static readonly CustomEvent OnBattleBegins = new CustomEvent();
        public static readonly CustomEvent<bool> OnBattleEnds = new CustomEvent<bool>();
        public static readonly CustomEvent OnJoinPlayer = new CustomEvent();
        public static readonly CustomEvent<int> OnJoinEnemy = new CustomEvent<int>();

        // Eventos del jugador:    
        public static readonly CustomEvent<int> OnChangePlayerHealth = new CustomEvent<int>();
        public static readonly CustomEvent<int> OnChangePlayerShields = new CustomEvent<int>();
        public static readonly CustomEvent<float> OnChangePlayerAttack = new CustomEvent<float>();
        public static readonly CustomEvent<float> OnChangePlayerDefense = new CustomEvent<float>();
        public static readonly CustomEvent OnDefeatPlayer = new CustomEvent();
        public static readonly CustomEvent<int> OnSelectTarget = new CustomEvent<int>();
        public static readonly CustomEvent OnPlayerUseSpell = new CustomEvent();

        // Eventos del libro de hechizos:
        public static readonly CustomEvent<int> OnSelectSpellSlot = new CustomEvent<int>();
        public static readonly CustomEvent<int, SpellUnit> OnChangeSpellSlot = new CustomEvent<int, SpellUnit>();
        public static readonly CustomEvent<List<SpellUnit>> OnGenerateSpellSlots = new CustomEvent<List<SpellUnit>>();

        // Eventos del tablero:
        public static readonly CustomEvent<char[], int, string> OnGenerateBoard = new CustomEvent<char[], int, string>();
        public static readonly CustomEvent<int, int> OnSelectKey = new CustomEvent<int, int>();
        public static readonly CustomEvent<int, int, bool> OnCheckKey = new CustomEvent<int, int, bool>();
        public static readonly CustomEvent OnCompleteWord = new CustomEvent();
        public static readonly CustomEvent<int> OnSetTimer = new CustomEvent<int>();
        public static readonly CustomEvent<int> OnUpdateTimer = new CustomEvent<int>();
        public static readonly CustomEvent OnFailSpell = new CustomEvent();

        // Eventos de los enemigos:
        public static readonly CustomEvent<int, int> OnChangeEnemyHealth = new CustomEvent<int, int>();
        public static readonly CustomEvent<int, int> OnChangeEnemyShields = new CustomEvent<int, int>();
        public static readonly CustomEvent<int, float> OnChangeEnemyAttack = new CustomEvent<int, float>();
        public static readonly CustomEvent<int, float> OnChangeEnemyDefense = new CustomEvent<int, float>();
        public static readonly CustomEvent<int> OnDefeatEnemy = new CustomEvent<int>();

    }
}