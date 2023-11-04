using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryFeature.Characters.Abstracts;

namespace TryFeature.Characters
{
    internal class JobCharacter : Character
    {
        public JobCharacter() : base(CharacterTypeEnum.JobCharater) { }

        public override IEnumerable<ActionEnum> Thinking()
        {
            while(true)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"CharacterID: {CharacterID}, Action:{ActionEnum.WalkEast}");
                    yield return ActionEnum.WalkEast;
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"CharacterID: {CharacterID}, Action:{ActionEnum.WalkSouth}");
                    yield return ActionEnum.WalkSouth;
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"CharacterID: {CharacterID}, Action:{ActionEnum.WalkWest}");
                    yield return ActionEnum.WalkWest;
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"CharacterID: {CharacterID}, Action:{ActionEnum.WalkNorth}");
                    yield return ActionEnum.WalkNorth;
                }
            }
        }
    }
}
