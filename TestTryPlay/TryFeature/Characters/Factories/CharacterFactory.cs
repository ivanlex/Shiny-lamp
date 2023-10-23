using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryFeature.Characters.Abstracts;

namespace TryFeature.Characters.Factories
{
    internal static class CharacterFactory
    {
        public static Character CreateCharactor(CharacterTypeEnum characterType)
        {
            switch (characterType)
            {
                case CharacterTypeEnum.JobCharater:
                    return new JobCharacter();
                default:
                    throw new NotSupportedException("该角色类型暂不支持");
            }
        }
    }
}
