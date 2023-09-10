using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Runtime.Remoting.Messaging;
using System;
using Newtonsoft.Json;

namespace SpellCreator
{
    public partial class MainWindow : Window
    {
        SpellsDB myDndDatabase;
        Spell currentSpell;
        // https://wpf-tutorial.com/panels/grid-column-row-span/
        public MainWindow()
        {
            myDndDatabase = new SpellsDB();
            currentSpell = new Spell();
            this.DataContext = this;
            InitializeComponent();
        }

        public SpellsDB DndDatabase { get { return myDndDatabase; } }
        //https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/?view=netdesktop-7.0

        // It is binded so it auto updates in TWO-WAYS. So any change to it is reflected everywhere.
        public Spell CurrentSpell { get { return currentSpell; } }// This is the binding for the UI and the currentspell.

        private void SaveSpell()
        {
            RichTextBox spellDescription = this.FindName("spell_description") as RichTextBox;
            RichTextBox spellHigher = this.FindName("spell_higher") as RichTextBox;
            currentSpell.description = Utils.GetTextFromRichTextBox(spellDescription);
            currentSpell.description_high = Utils.GetTextFromRichTextBox(spellHigher);
        }

        private void ExportSpell(object sender, RoutedEventArgs e)
        {
            // Save the current spell into a txt
            // Call external class ofc.
            SaveSpell();
            Root spellList = new Root();
            spellList.AddSpell(currentSpell.Exportable());

            Exporter.ExportSpell(spellList, Exporter.ExternalFormatting.DNDSpell);
        }

        private void ImportSpell(object sender, RoutedEventArgs e)
        {
            Spell newInstance = Exporter.ImportSpell();
            if (newInstance != null)
            {
                SetCurrentSpell(newInstance);
                // Console.WriteLine("Importing spell!");
            }
        }

        private void SetCurrentSpell(Spell newSpell)
        {
            currentSpell.book = newSpell.book;
            currentSpell.casting_time = newSpell.casting_time;
            currentSpell.classes = newSpell.classes;
            currentSpell.components = newSpell.components;
            currentSpell.concentration = newSpell.concentration;
            currentSpell.description = newSpell.description;
            currentSpell.description_high = newSpell.description_high;
            currentSpell.duration = newSpell.duration;
            currentSpell.level = newSpell.level;
            currentSpell.material = newSpell.material;
            currentSpell.materialDescription = newSpell.materialDescription;
            currentSpell.name = newSpell.name;
            currentSpell.range = newSpell.range;
            currentSpell.ritual = newSpell.ritual;
            currentSpell.school = newSpell.school;
            currentSpell.somatic = newSpell.somatic;
            currentSpell.vocal = newSpell.vocal;


            RichTextBox spellDescription = this.FindName("spell_description") as RichTextBox;
            RichTextBox spellHigher = this.FindName("spell_higher") as RichTextBox;
            Utils.SetTextToRichTextBox(ref spellDescription, currentSpell.description);
            Utils.SetTextToRichTextBox(ref spellHigher, currentSpell.description_high);


        }

        private void DisplaySpell(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(JsonConvert.SerializeObject(currentSpell, Formatting.Indented), "Debugging Spell");
        }
    }
}
