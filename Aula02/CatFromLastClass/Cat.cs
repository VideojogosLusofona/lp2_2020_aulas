using System;

namespace CatFromLastClass
{
    public class Cat
    {
        public static int MaxEnergy { get; set; } = 100;
        public static int EnergyGainAfterSleep { get; set; } = 20;
        public static int EnergyLossAfterPlay { get; set; } = 15;
        public static int EnergyLossAfterMeow { get; set; } = 5;

        private int energy;
        private Feed feedStatus;
        private Random random;
        private Feed[] possibleFeedStatus;
        private Mood[] possibleMoods;

        public string Name { get; }

        public int Energy
        {
            get => energy;
            private set
            {
                energy = value;
                if (energy < 0) energy = 0;
                else if (energy > MaxEnergy) energy = MaxEnergy;
            }
        }

        public Feed FeedStatus
        {
            get => feedStatus;
            private set
            {
                feedStatus = value;
                if (feedStatus < Feed.Starving)
                    feedStatus = Feed.Starving;
                else if (feedStatus > Feed.AboutToExplode)
                    feedStatus = Feed.AboutToExplode;
            }
        }

        public Mood MoodStatus  { get; private set; }

        private Cat()
        {
            random = new Random();
            possibleFeedStatus = (Feed[])Enum.GetValues(typeof(Feed));
            possibleMoods = (Mood[])Enum.GetValues(typeof(Mood));
        }

        public Cat(string name, int energy, Feed feedStatus, Mood moodStatus)
            : this()
        {
            Name = name;
            Energy = energy;
            FeedStatus = feedStatus;
            MoodStatus = moodStatus;
        }

        public Cat(string name) : this()
        {
            Name = name;
            energy = random.Next(MaxEnergy + 1);
            FeedStatus =
                possibleFeedStatus[random.Next(possibleFeedStatus.Length)];
            MoodStatus = RandomMoods();
        }

        private Mood RandomMoods()
        {
            Mood moods = 0;
            int numMoods = random.Next(possibleMoods.Length) + 1;
            for (int i = 0; i < numMoods; i++)
            {
                moods |= possibleMoods[random.Next(possibleMoods.Length)];
            }
            return moods;
        }

        public void Eat()
        {
            FeedStatus++;
        }

        public void Sleep()
        {
            Energy += EnergyGainAfterSleep;
            FeedStatus--;
            MoodStatus = RandomMoods();
        }

        public void Play()
        {
            Energy -= EnergyLossAfterPlay;
            MoodStatus = Mood.Happy;
        }

        public void Meow()
        {
            Console.WriteLine($"{Name} says \"Meow\"!");
            Energy -= EnergyLossAfterMeow;
        }
    }
}
