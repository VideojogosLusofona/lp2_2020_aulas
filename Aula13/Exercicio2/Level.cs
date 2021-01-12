using System.Text;
using System.Collections.Generic;

namespace ex4
{
    public class Level
    {
        private readonly char category;
        private IList<float> scores;

        public Level(char category, IEnumerable<float> scores)
        {
            this.category = category;
            this.scores = new List<float>(scores);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{category}:");
            foreach (float sc in scores)
                sb.Append($" {sc:f2}");
            return sb.ToString();
        }

        public void IncScores()
        {
            for (int i = 0; i < scores.Count; i++) scores[i]++;
        }

        public Level ShallowCopy() => MemberwiseClone() as Level;

        public Level NewCopy()
        {
            Level level = ShallowCopy();
            level.scores = new List<float>(scores);
            return level;
        }
    }
}