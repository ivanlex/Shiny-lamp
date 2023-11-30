using System.Diagnostics;
using TryFeature.Characters.Abstracts;
using TryFeature.Characters.Factories;

namespace TryFeature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetNanoSecondsForNow();
        }

        static void GetNanoSecondsForNow()
        {
            double _GetNanoSecondsForNow()
            {
                var timestamp = Stopwatch.GetTimestamp();
                var nanoseconds = 1000000000 * timestamp / Stopwatch.Frequency;
                return nanoseconds;
            }

            var t1 = _GetNanoSecondsForNow();
            var t2 = _GetNanoSecondsForNow();
            var delta = t2 - t1;
            Console.WriteLine($"Delta time for t2 and t1 is {delta}");
        }

        static void FasterMethodToDividedByX()
        {
            var i = 17;
            var dividedByBit = 1;
            Console.WriteLine($"i={i}, i >> {dividedByBit} = {i >> dividedByBit}");
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