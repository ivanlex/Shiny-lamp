using TryFeature.Characters.Abstracts;
using TryFeature.Characters.Factories;

namespace TryFeature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimulationMultithread();
        }

        static void SimulationMultithread()
        {
            List<Character> jobs = new();

            for (int i = 0; i < 10; i++)
            {
                jobs.Add(
                    CharacterFactory.CreateCharactor(
                            CharacterTypeEnum.JobCharater
                        )
                    );
            }

            foreach (var job in jobs)
            {
                var enumerator = job.Thinking().GetEnumerator();
                Console.WriteLine($"JobID:{job.CharacterID}, Event:{enumerator.Current}, ThreadID:{Thread.CurrentThread.ManagedThreadId}");

                enumerator.MoveNext();
            }

            Console.ReadLine();
        }
    }
}