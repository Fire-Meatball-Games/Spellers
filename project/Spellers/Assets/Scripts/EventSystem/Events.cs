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
        public static readonly CustomEvent<Spell> OnDisplaySpellDetails = new CustomEvent<Spell>();
        public static readonly CustomEvent OnModifyPlayerDeck = new CustomEvent();
        public static readonly CustomEvent OnModifyPlayerSkin = new CustomEvent();

        // Eventos del modo historia:
        public static readonly CustomEvent<int> OnSelectLevel = new CustomEvent<int>();
        public static readonly CustomEvent OnDeselectLevel = new CustomEvent();

        // Eventos de la partida:

        public static readonly CustomEvent OnBattleReady = new CustomEvent();
        public static readonly CustomEvent OnStartCountDown = new CustomEvent();
        public static readonly CustomEvent OnEndCountDown = new CustomEvent();              
        public static readonly CustomEvent OnBattleBegins = new CustomEvent();              
        public static readonly CustomEvent<bool> OnPauseBattle = new CustomEvent<bool>();   
        public static readonly CustomEvent<bool> OnBattleEnds = new CustomEvent<bool>();
        public static readonly CustomEvent OnJoinPlayer = new CustomEvent();
        public static readonly CustomEvent OnJoinEnemy = new CustomEvent();


        //Eventos de la interfaz del jugador:
        public static readonly CustomEvent OnSelectSpellSlot = new CustomEvent();
        public static readonly CustomEvent OnSelectMinigame = new CustomEvent();
        public static readonly CustomEvent OnFailGame = new CustomEvent();
        public static readonly CustomEvent OnCompleteGame = new CustomEvent();
        public static readonly CustomEvent OnTimerEnds = new CustomEvent();
        public static readonly CustomEvent OnPlayerUseSpell = new CustomEvent();

        public static readonly CustomEvent OnCompleteStopWandGame = new CustomEvent();
        public static readonly CustomEvent OnCompletePotionsGame = new CustomEvent();
        public static readonly CustomEvent OnCompleteFlipCardsGame = new CustomEvent();

        // Eventos de minijuegos:        
        public static readonly CustomEvent OnCompleteStrengthMinigame = new CustomEvent(); 
        public static readonly CustomEvent OnCompletePoisonMinigame = new CustomEvent();
        public static readonly CustomEvent OnCompleteBlindMinigame = new CustomEvent();
        public static readonly CustomEvent OnCompleteDifficultyMinigame = new CustomEvent();

        // Eventos del tablero:
        public static readonly CustomEvent OnHitkey = new CustomEvent();
        public static readonly CustomEvent OnFailSpell = new CustomEvent();

        // Condiciones:
        public static readonly CustomEvent OnWinConditionChecked = new CustomEvent();

        // Trigger minijuegos:
        public static readonly CustomEvent ActivePowerGame = new CustomEvent();
        public static readonly CustomEvent ActiveHealGame = new CustomEvent();
        


    }
}