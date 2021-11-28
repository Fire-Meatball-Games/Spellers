using SpellSystem;
using System.Collections.Generic;

namespace CustomEventSystem
{
    public static class Events
    {
        public static readonly CustomEvent<int> OnLoadScene = new CustomEvent<int>();

        // Eventos del menu de inicio:
        public static readonly CustomEvent<int, SpellerNPCSettings> OnChangeSpellerNPCSettings = new CustomEvent<int, SpellerNPCSettings>();
        public static readonly CustomEvent OnSecretActivated = new CustomEvent();

        // Eventos de la coleccion de hechizos del jugador:
        public static readonly CustomEvent OnSelectSpellCard = new CustomEvent();

        public static readonly CustomEvent<Spell> OnDisplaySpellDetails = new CustomEvent<Spell>();
        public static readonly CustomEvent OnAddSpellToDeck = new CustomEvent();

        // Eventos del modo historia:
        public static readonly CustomEvent<int> OnSelectLevel = new CustomEvent<int>();
        public static readonly CustomEvent OnDeselectLevel = new CustomEvent();

        // Eventos de la partida:
        public static readonly CustomEvent OnEndCountDown = new CustomEvent();              
        public static readonly CustomEvent OnBattleBegins = new CustomEvent();              
        public static readonly CustomEvent<bool> OnPauseBattle = new CustomEvent<bool>();   
        public static readonly CustomEvent<bool> OnBattleEnds = new CustomEvent<bool>();
        public static readonly CustomEvent OnJoinPlayer = new CustomEvent();
        public static readonly CustomEvent<int> OnJoinEnemy = new CustomEvent<int>();

        // Eventos del jugador:    
        public static readonly CustomEvent<int> OnChangePlayerHealth = new CustomEvent<int>();
        public static readonly CustomEvent<int> OnChangePlayerShields = new CustomEvent<int>();

        public static readonly CustomEvent<float> OnChangePlayerAttack = new CustomEvent<float>();
        public static readonly CustomEvent<int> OnChangePlayerRegeneration = new CustomEvent<int>();
        public static readonly CustomEvent<int> OnChangePlayerSlots = new CustomEvent<int>();
        public static readonly CustomEvent<int> OnChangePlayerOrder = new CustomEvent<int>();
        public static readonly CustomEvent<int> OnChangePlayerDifficulty = new CustomEvent<int>();
        public static readonly CustomEvent OnChangeStat = new CustomEvent();


        public static readonly CustomEvent OnDefeatPlayer = new CustomEvent();
        public static readonly CustomEvent<int> OnSelectTarget = new CustomEvent<int>();
        public static readonly CustomEvent OnPlayerUseSpell = new CustomEvent();

        // Eventos del libro de hechizos:
        public static readonly CustomEvent<int> OnSelectSpellSlot = new CustomEvent<int>();
        public static readonly CustomEvent<int, SpellSystem.SpellUnit> OnChangeSpellSlot = new CustomEvent<int, SpellSystem.SpellUnit>();
        public static readonly CustomEvent<List<SpellSystem.SpellUnit>> OnGenerateSpellSlots = new CustomEvent<List<SpellSystem.SpellUnit>>();

        // Eventos de minijuegos:        
        public static readonly CustomEvent OnCompleteStrengthMinigame = new CustomEvent(); 
        public static readonly CustomEvent OnFailPoisonMinigame = new CustomEvent();
        public static readonly CustomEvent OnCompletePoisonMinigame = new CustomEvent();
        public static readonly CustomEvent OnCompleteBlindMinigame = new CustomEvent();
        public static readonly CustomEvent OnCompleteDifficultyMinigame = new CustomEvent();

        // Eventos del tablero:
        public static readonly CustomEvent<string, bool> OnGenerateWord = new CustomEvent<string, bool>();
        public static readonly CustomEvent<char[], int> OnGenerateBoard = new CustomEvent<char[], int>();
        public static readonly CustomEvent<int, int> OnSelectKey = new CustomEvent<int, int>();
        public static readonly CustomEvent<int, int, bool> OnCheckKey = new CustomEvent<int, int, bool>();
        public static readonly CustomEvent OnHitkey = new CustomEvent();
        public static readonly CustomEvent OnCompleteWord = new CustomEvent();
        public static readonly CustomEvent<int> OnSetTimer = new CustomEvent<int>();
        public static readonly CustomEvent<int> OnUpdateTimer = new CustomEvent<int>();
        public static readonly CustomEvent OnFailSpell = new CustomEvent();

        // Eventos de los enemigos:
        public static readonly CustomEvent<int, int> OnChangeEnemyHealth = new CustomEvent<int, int>();
        public static readonly CustomEvent<int, int> OnChangeEnemyShields = new CustomEvent<int, int>();

        public static readonly CustomEvent<int, float> OnChangeEnemyAttack = new CustomEvent<int, float>();
        public static readonly CustomEvent<int, int> OnChangeEnemyRegeneration = new CustomEvent<int, int>();
        public static readonly CustomEvent<int, int> OnChangeEnemySlots = new CustomEvent<int, int>();
        public static readonly CustomEvent<int, int> OnChangeEnemyOrder = new CustomEvent<int, int>();
        public static readonly CustomEvent<int, int> OnChangeEnemyDifficulty = new CustomEvent<int, int>();

        public static readonly CustomEvent<int> OnDefeatEnemy = new CustomEvent<int>();

    }
}