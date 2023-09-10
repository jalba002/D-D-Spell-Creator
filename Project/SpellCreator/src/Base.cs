using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SpellCreator
{
    public class ExportableSpell : Spell
    {
        public int id = -1;

        [NonSerialized] public new bool vocal;
        [NonSerialized] public new bool somatic;
        [NonSerialized] public new bool material;
        [NonSerialized] public new string materialDescription;

        public string sound = "";
        public bool is_edit = false;

        public ExportableSpell ToExportable(Spell export)
        {
            ExportableSpell exportableSpell = (ExportableSpell)export;
            exportableSpell.vocal = export.vocal;
            exportableSpell.somatic = export.somatic;
            exportableSpell.material = export.material;
            exportableSpell.materialDescription = export.materialDescription;
            MessageBox.Show(JsonConvert.SerializeObject(exportableSpell, Formatting.Indented), "Spell to ExportableSpell result");
            return exportableSpell;
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Spell : INotifyPropertyChanged
    {
        [NonSerialized] string _name;
        [NonSerialized] string _school;
        [NonSerialized] string _level;
        [NonSerialized] string _casting_time;
        [NonSerialized] string _range;
        [NonSerialized] bool _vocal;
        [NonSerialized] bool _somatic;
        [NonSerialized] bool _material;
        [NonSerialized] string _materialDescription;
        [NonSerialized] string _components;
        [NonSerialized] string _duration;
        [NonSerialized] string _description;
        [NonSerialized] string _description_high;
        [NonSerialized] string _book;
        [NonSerialized] string _classes;
        [NonSerialized] string _concentration;
        [NonSerialized] string _ritual;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        public string school
        {
            get
            {
                return _school;
            }
            set
            {
                _school = value;
                NotifyPropertyChanged();
            }
        }
        public string level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                NotifyPropertyChanged();
            }
        }

        public string casting_time
        {
            get
            {
                return _casting_time;
            }
            set
            {
                _casting_time = value;
                NotifyPropertyChanged();
            }
        }
        public string range
        {
            get
            {
                return _range;
            }
            set
            {
                _range = value;
                NotifyPropertyChanged();
            }
        }
        public bool vocal
        {
            get
            {
                return _vocal;
            }
            set
            {
                _vocal = value;
                NotifyPropertyChanged();
            }
        }
        public bool somatic
        {
            get
            {
                return _somatic;
            }
            set
            {
                _somatic = value;
                NotifyPropertyChanged();
            }
        }
        public bool material
        {
            get
            {
                return _material;
            }
            set
            {
                _material = value;
                NotifyPropertyChanged();
            }
        }
        public string materialDescription
        {
            get
            {
                return _materialDescription;
            }
            set
            {
                _materialDescription = value;
                NotifyPropertyChanged();
            }
        }
        public string components
        {
            get
            {
                return _components;
            }
            set
            {
                _components = value;
                NotifyPropertyChanged();
            }
        }
        public string duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                NotifyPropertyChanged();
            }
        }
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyPropertyChanged();
            }
        }
        public string description_high
        {
            get
            {
                return _description_high;
            }
            set
            {
                _description_high = value;
                NotifyPropertyChanged();
            }
        }
        public string book
        {
            get
            {
                return _book;
            }
            set
            {
                _book = value;
                NotifyPropertyChanged();
            }
        }
        public string classes
        {
            get
            {
                return _classes;
            }
            set
            {
                _classes = value;
                NotifyPropertyChanged();
            }
        }
        public string concentration
        {
            get
            {
                return _concentration;
            }
            set
            {
                _concentration = value;
                NotifyPropertyChanged();
            }
        }
        public string ritual
        {
            get
            {
                return _ritual;
            }
            set
            {
                _ritual = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }  

        public Spell()
        {
            name = "";
            school = "Evocation";
            level = "Cantrip";
            casting_time = "1 action";
            range = "30 feet";
            components = "";
            vocal = false;
            somatic = false;
            material = false;
            materialDescription = "";
            duration = "Instantaneous";
            description = "Default Description";
            description_high = "Default Upcast Description";
            book = "";
            classes = "Wizard";
            concentration = "false";
            ritual = "false";
        }

        public Spell(string name, string school, string level, string castingTime,
            string range, string components, string duration,
            string description, string descriptionHigh, string book,
            string classes, bool concentration, bool ritual)
        {
            this.name = name;
            this.school = school;
            this.level = level;
            this.casting_time = castingTime;
            this.range = range;
            this.components = components;
            this.duration = duration;
            this.description = description;
            this.description_high = descriptionHigh;
            this.book = book;
            this.classes = classes;
            this.concentration = concentration.ToString().ToLower();
            this.ritual = ritual.ToString().ToLower();
        }

        public Spell(string name, string school, string level, string castingTime,
            string range, string components, string duration,
            string description, string descriptionHigh, string book,
            string classes, string concentration, string ritual)
        {
            this.name = name;
            this.school = school;
            this.level = level;
            this.casting_time = castingTime;
            this.range = range;
            this.components = components;
            this.duration = duration;
            this.description = description;
            this.description_high = descriptionHigh;
            this.book = book;
            this.classes = classes;
            this.concentration = concentration;
            this.ritual = ritual;
        }


        public bool Load()
        {
            // The flags for internal usage.
            // Checkboxes and stuff.
            this.vocal = this.components.Contains("V");
            this.somatic = this.components.Contains("S");
            this.material = this.components.Contains("M");
            if (this.material)
                this.materialDescription = Utils.RemoveSpecialCharacters(this.components.Split('M')[1].TrimStart(new[] { ' ' }));

            int.TryParse(this.level, out int numericLevel);

            if (numericLevel <= 0)
            {
                this.level = "Cantrip";
            }
            else if (numericLevel > 0)
            {
                level = Utils.ToOrdinal(numericLevel) + " level";
            }
            else
            {
                return false; // Error? Its the wrong level.
            }

            return true;
        }

        public Spell Exportable() // Works with the 5e DND APK app.
        {
            if (level == "Cantrip")
            {
                level = "-1";
            }
            else
            {
                level = new string(level.Where(char.IsDigit).ToArray());
            }

            // Transform components into a single line for exportation.
            components =
                (vocal ? "V, " : "") +
                (somatic ? "S, " : "") +
                (material ? "M (" + materialDescription + ")" : "");

            return this;
        }

    }

    public class Version
    {
        public string version = "3.1.5";
        public Version()
        {
            version = "3.1.5";
        }
    }

    public class Database
    {
        public string db = "13";
        public Database()
        {
            db = "13";
        }
    }

    public class Root
    {
        public List<Spell> data { get; set; }

        public Root()
        {
            data = new List<Spell>();
        }

        public void AddSpell(Spell newSpell)
        {
            data.Add(newSpell);
        }
    }
}
