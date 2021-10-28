using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public class SpellerPlayer : Speller
    {
        #region Public variables
        public SpellTable table;
        public SpellBoard board;

        [SerializeField] List<Spell> spells;
        #endregion

        #region Unity CallBacks
        public override void Init()
        {
            base.Init();
            target = FindObjectOfType<SpellerNPC>();
            table = new SpellTable(new SpellDeck(spells));
            board = new SpellBoard();
            board.OnFailKeyEvent += () => stats.GetDamage(5);
        }

        private void Start()
        {
            InitializeTable();
        }
        #endregion

        #region Public methods

        // Selecciona el hechizo en la posici�n idx de la mesa.
        // Activa el tablero correspondiente al tipo de hechizo seleccionado

        public void SelectSpell(int idx)
        {
            table.SelectSpellSlot(idx);
            board.GenerateBoard(table.GetSelectedSpell().lvl);
        }

        // Pulsa la tecla (x, y) del tablero de juego

        public void OnKey(int column, int row)
        {
            board.CheckCharacterKey(column, row);
        }
        #endregion

        #region Private Methods

        private void InitializeTable()
        {
            table.Initialize();
        }

        protected override Spell GetActiveSpell()
        {
            return table.GetSelectedSpell();
        }

        #endregion
    }
}
