using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Ingame
{
    // Define el puzle a completar para poder lanzar un hechizo. El tiempo disponible y la complejidad dependera de los valores de este objeto.
    // La dificultad del puzle estará en el rango 1 - 10;
    public class Board
    {
        public enum GameType
        {
            spell,
            attack,
            regeneration,
            order,
            time,
        }

        private static readonly float BASE_TIME = 2f;
        private static readonly float LEVEL_TIME = 1f;
        private static readonly float POWER_TIME = 2f;
        private static readonly float MINIGAME_TIME = 10f;

        #region Private fields
        private MonoBehaviour behaviour;
        private float time_multiplier;
        private int difficulty;

        #endregion

        #region Events
        public event Action<GameType, int, float> OnGenerateGame = delegate{};
        public event Action OnFailGame = delegate{};
        public event Action OnSurrendGame = delegate{};
        public event Action OnCompleteGame = delegate{};  

        #endregion

        public Board(MonoBehaviour behaviour)
        {
            this.behaviour = behaviour;
        }

        public void GenerateSpellGame(SpellUnit unit)  
        {
            int level = unit.lvl;
            int power = unit.spell.Power;

            int difficulty = ComputeDifficulty(power, level);
            float time = ComputeTime(power, level);

            OnGenerateGame?.Invoke(GameType.spell, difficulty, time);
        }

        public void GenerateExtraGame(GameType type)
        {
            OnGenerateGame?.Invoke(type, 1, MINIGAME_TIME);
        }

        private float ComputeTime(int power, int lvl)
        {
            return BASE_TIME + POWER_TIME * power + LEVEL_TIME * lvl;
        }

        private int ComputeDifficulty(int power, int lvl)
        {
            return lvl + (power - 1) * 2;
        }


    }

}
