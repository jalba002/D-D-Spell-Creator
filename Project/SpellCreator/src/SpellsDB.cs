using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace SpellCreator
{
    public class SpellsDB
    {
        ObservableCollection<School> schools = new ObservableCollection<School>();
        ObservableCollection<CastTime> castTimes = new ObservableCollection<CastTime>();
        ObservableCollection<Level> levels = new ObservableCollection<Level>();

        private CollectionViewSource schoolsViewSource = new CollectionViewSource();
        private CollectionViewSource castTimesViewSource = new CollectionViewSource();
        private CollectionViewSource levelsViewSource = new CollectionViewSource();

        public ICollectionView Schools_GetActive { get => schoolsViewSource.View; }
        public ICollectionView CastTimes_GetActive { get => castTimesViewSource.View; }
        public ICollectionView Levels_GetActive { get => levelsViewSource.View; }
        public SpellsDB()
        {
            schools = new ObservableCollection<School>()
            {
                new School() { name = "Abjuration" },
                new School() { name = "Conjuration" },
                new School() { name = "Divination" },
                new School() { name = "Enchantment" },
                new School() { name = "Evocation" },
                new School() { name = "Illusion" },
                new School() { name = "Necromancy" },
                new School() { name = "Transmutation" }
            };
            schoolsViewSource.Source = schools;

            castTimes = new ObservableCollection<CastTime>()
            {
                new CastTime() { castTime = "1 bonus action"},
                new CastTime() { castTime = "1 action"},
                new CastTime() { castTime = "1 minute"},
                new CastTime() { castTime = "10 minutes"},
                new CastTime() { castTime = "1 hour"},
                new CastTime() { castTime = "8 hours"},
                new CastTime() { castTime = "24 hours"},
            };
            castTimesViewSource.Source = castTimes;

            levels = new ObservableCollection<Level>()
            {
                new Level() { level = "Cantrip" },
                new Level() { level = "1st level"},
                new Level() { level = "2nd level"},
                new Level() { level = "3rd level"},
                new Level() { level = "4th level"},
                new Level() { level = "5th level"},
                new Level() { level = "6th level"},
                new Level() { level = "7th level"},
                new Level() { level = "8th level"},
                new Level() { level = "9th level"},
                new Level() { level = "10th level"},
                new Level() { level = "11st level"},
                new Level() { level = "12nd level"},
                new Level() { level = "13rd level"},
                new Level() { level = "14th level"},
                new Level() { level = "15th level"},
                new Level() { level = "16th level"},
                new Level() { level = "17th level"},
                new Level() { level = "18th level"},
                new Level() { level = "19th level"},
                new Level() { level = "20th level"},
            };

            levelsViewSource.Source = levels;
        }

        public void DeleteEntries()
        {
            schools = new ObservableCollection<School>()
            {
                new School() { name = "DESTROYED" }
            };
            schoolsViewSource.Source = schools;
        }

        public class School
        {
            public string name { get; set; }
            public string description { get; set; }
        }

        public class CastTime
        {
            public string castTime { get; set; }
        }

        public class Level
        {
            public string level { get; set; }
        }

    }
}
