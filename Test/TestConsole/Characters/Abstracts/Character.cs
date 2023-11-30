using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryFeature.Characters.Abstracts
{
    internal static class Statics
    {
        internal static int CharacterIDCounter { get; set; }
    }

    internal enum ActionEnum
    {
        /// <summary>
        /// 向北走
        /// </summary>
        WalkNorth = 0,
        /// <summary>
        /// 向东走
        /// </summary>
        WalkEast = 1,
        /// <summary>
        /// 向南走
        /// </summary>
        WalkSouth = 2,
        /// <summary>
        /// 向西走
        /// </summary>
        WalkWest = 3,
    }

    internal enum CharacterTypeEnum
    {
        /// <summary>
        /// 任务角色
        /// </summary>
        JobCharater = 0,
    }

    internal abstract class Character
    {
        public int CharacterID { get; set; }
        public CharacterTypeEnum CharaterType { get; set; }
        public abstract IEnumerable<ActionEnum> Thinking();

        public Character(CharacterTypeEnum charaterType)
        {
            CharaterType = charaterType;
            CharacterID = Statics.CharacterIDCounter++;
        }
    }
}
