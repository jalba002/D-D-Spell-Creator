using System;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Windows;

namespace SpellCreator
{
    class Exporter
    {
        public enum ExternalFormatting
        {
            OnlySpell,
            DNDSpell,
            SpellGroup
        }
        public static void ExportSpell<T>(T data, ExternalFormatting formatting)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Text files (*.txt)|*.txt";
            fileDialog.DefaultExt = ".txt";

            string fullData = "";

            if (fileDialog.ShowDialog() == true)
            {
                switch (formatting)
                {
                    case ExternalFormatting.OnlySpell:
                        break;
                    case ExternalFormatting.DNDSpell:
                        fullData = "[\n{\"version\":\"3.1.5\"},\n{\"db\":\"13\"},\n";
                        break;
                }

                fullData += JsonConvert.SerializeObject(data, Formatting.Indented); // add data to the string
                StreamWriter stream = new StreamWriter(fileDialog.FileName);

                switch (formatting)
                {
                    case ExternalFormatting.OnlySpell:
                        break;
                    case ExternalFormatting.DNDSpell:
                        fullData += "\n]";
                        break;
                }

                stream.Write(fullData);
                stream.Close();
            }
        }

        public static Spell ImportSpell()
        {
            //var itemsString = "";
            //string path = "defaultSpell.json";
            //try
            //{
            //    StreamReader stream = new StreamReader(path);
            //    itemsString = stream.ReadToEnd();
            //    stream.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    return null; 
            //}

            string itemsString = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Json Files (*.json)|*.json"; //|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                itemsString = File.ReadAllText(openFileDialog.FileName);
            }
            else
            {
                return null;
            }

            // Automatically generates a list for every item indented in the json file.
            // Handy!
            //itemList = JsonConvert.DeserializeObject(itemsString, typeof(List<Item>)) as List<Item>;

            // https://stackoverflow.com/questions/50406948/how-to-deserialize-strange-json-format-in-c-sharp/50407911
            try
            {
                //list = JsonConvert.DeserializeObject(, typeof(List<Spell>)) as List<Spell>;
                dynamic list = JsonConvert.DeserializeObject<dynamic>(itemsString);
                //return list as Spell;
                //Console.WriteLine(list.ToString());
                var spell = list[2].data; // Array of spells
                //Console.WriteLine(list.version.ToString());
                Console.WriteLine(spell[0].ToString());
                Spell newLoadedSpell = JsonConvert.DeserializeObject(spell[0].ToString(), typeof(Spell)) as Spell;
                newLoadedSpell.Load();
                return newLoadedSpell;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error when importing the spell data. It might have an incorrect format or the file was modified.", "Import Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                //Console.WriteLine("ERROR: " + e.Message);
            }
            return null;
        }
    }
}
