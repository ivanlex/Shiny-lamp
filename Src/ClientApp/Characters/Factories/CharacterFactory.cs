using ClientApp.Characters.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Characters.Factories
{
    internal static class CharacterFactory
    {
        public static Character CreateFactory(CharacterTypeEnum characterType)
        {
            switch (characterType)
            {
                case CharacterTypeEnum.NPC:
                    return new NPCCharacter();
                case CharacterTypeEnum.Job:
                    return new JobCharacter();
                case CharacterTypeEnum.Other:
                default:
                    throw new NotSupportedException($"This character can't be created since the type of character is not supported");
            }
        }
    }

    public enum CharacterTypeEnum 
    { 
        NPC,
        Job,
        Other
    }
}
