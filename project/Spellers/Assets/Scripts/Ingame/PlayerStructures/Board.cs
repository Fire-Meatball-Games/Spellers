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
        private static readonly float BASE_TIME = 2f;
        private static readonly float LEVEL_TIME = 2f;
        private static readonly float POWER_TIME = 2f;
        private static readonly int MAX_DIFICULTY = 10;
        #region Private fields
        private MonoBehaviour behaviour;
        private float time;
        private int difficulty;

        #endregion

        #region Events
        public event Action OnGenerateGame = delegate{};
        public event Action OnFailGame = delegate{};
        public event Action OnSurrendGame = delegate{};
        public event Action OnCompleteGame = delegate{};  

        #endregion

        public Board(MonoBehaviour behaviour)
        {
            this.behaviour = behaviour;
        }

        public void GenerateGame(SpellUnit unit)  
        {
            int level = unit.lvl;
            int power = unit.spell.Power;
            int wordLength = 2 + (power - 1) + level;
            int boardDimension = 2 + level;
            int ticks = 500  + 250 * level; // tick = 0.02s
        }

        private float ComputeTime(int power, int lvl)
        {
            return BASE_TIME + POWER_TIME * power + LEVEL_TIME * lvl;
        }

    }

}
