using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace MegingjordReforged.Source.Utilities
{
    public static class ConfigFormatter
    {
        private static readonly string[] PreferredSectionOrder =
        {
            "General",

            "Logging",

            "Belts - Aedigjord",
            "Belts - Aedigjord - Effects",

            "Belts - Seidgjord",
            "Belts - Seidgjord - Effects",

            "Belts - Skadigjord",
            "Belts - Skadigjord - Effects",

            "Belts - Alagjord",
            "Belts - Alagjord - Effects",

            "Belts - Fornmegingjord",
            "Belts - Fornmegingjord - Effects",

            "Advanced"
        };


        private const string FormatVersionKey =
            "# MegingjordReforged Config Format Version:";



        public static int GetStoredFormatVersion(
            string configPath)
        {
            if (string.IsNullOrWhiteSpace(configPath) ||
                !File.Exists(configPath))
            {
                return 0;
            }


            try
            {
                foreach (string line in File.ReadAllLines(
                             configPath,
                             Encoding.UTF8))
                {
                    if (!line.StartsWith(
                            FormatVersionKey,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }


                    string value =
                        line.Replace(
                            FormatVersionKey,
                            string.Empty)
                        .Trim();


                    if (int.TryParse(
                            value,
                            out int version))
                    {
                        return version;
                    }
                }
            }
            catch (Exception exception)
            {
                ModLogger.LogWarning(
                    $"Unable to read configuration format version: {exception.Message}"
                );
            }


            return 0;
        }



        public static void Format(
            string configPath,
            int formatVersion)
        {
            if (string.IsNullOrWhiteSpace(configPath))
            {
                ModLogger.LogWarning(
                    "ConfigFormatter received an invalid path."
                );

                return;
            }


            if (!File.Exists(configPath))
            {
                ModLogger.LogWarning(
                    $"Configuration file does not exist: {configPath}"
                );

                return;
            }


            try
            {
                string[] lines =
                    File.ReadAllLines(
                        configPath,
                        Encoding.UTF8);



                List<string> header =
                    new();


                Dictionary<string, List<string>> sections =
                    ParseSections(
                        lines,
                        header);



                List<string> output =
                    BuildFormattedConfiguration(
                        sections);



                output.InsertRange(
                    0,
                    header);



                AddFormatVersion(
                    output,
                    formatVersion);



                WriteFormattedFile(
                    configPath,
                    output);



                ModLogger.LogInfo(
                    $"Configuration formatted to version {formatVersion}."
                );
            }
            catch (Exception exception)
            {
                ModLogger.LogError(
                    $"Config formatting failed: {exception}"
                );
            }
        }



        private static Dictionary<string, List<string>> ParseSections(
            string[] lines,
            List<string> header)
        {
            Dictionary<string, List<string>> sections =
                new(
                    StringComparer.OrdinalIgnoreCase);


            string? currentSection = null;



            foreach (string line in lines)
            {
                string trimmed =
                    line.Trim();



                if (trimmed.StartsWith("[") &&
                    trimmed.EndsWith("]"))
                {
                    currentSection =
                        trimmed.Substring(
                            1,
                            trimmed.Length - 2)
                        .Trim();


                    if (!sections.ContainsKey(
                            currentSection))
                    {
                        sections[currentSection] =
                            new List<string>();
                    }


                    continue;
                }



                if (currentSection == null)
                {
                    header.Add(line);
                    continue;
                }



                sections[currentSection]
                    .Add(line);
            }


            return sections;
        }



        private static List<string> BuildFormattedConfiguration(
            Dictionary<string, List<string>> sections)
        {
            List<string> output =
                new();



            HashSet<string> written =
                new(
                    StringComparer.OrdinalIgnoreCase);



            foreach (string section in PreferredSectionOrder)
            {
                if (!sections.TryGetValue(
                        section,
                        out List<string> contents))
                {
                    continue;
                }


                WriteSection(
                    output,
                    section,
                    contents);


                written.Add(section);
            }



            foreach (KeyValuePair<string, List<string>> section in sections)
            {
                if (written.Contains(
                        section.Key))
                {
                    continue;
                }


                WriteSection(
                    output,
                    section.Key,
                    section.Value);
            }


            return output;
        }



        private static void WriteSection(
            List<string> output,
            string name,
            List<string> contents)
        {
            if (output.Count > 0)
            {
                output.Add(string.Empty);
            }


            output.Add(
                $"[{name}]");


            output.AddRange(
                contents);
        }



        private static void AddFormatVersion(
            List<string> lines,
            int version)
        {
            lines.RemoveAll(
                line =>
                    line.StartsWith(
                        FormatVersionKey,
                        StringComparison.OrdinalIgnoreCase)
            );


            lines.Insert(
                0,
                $"{FormatVersionKey} {version}"
            );


            lines.Insert(
                1,
                string.Empty
            );
        }



        private static void WriteFormattedFile(
            string path,
            List<string> lines)
        {
            string temp =
                path + ".tmp";


            try
            {
                File.WriteAllLines(
                    temp,
                    NormalizeSpacing(lines),
                    Encoding.UTF8);



                File.Copy(
                    temp,
                    path,
                    true);



                File.Delete(
                    temp);
            }
            catch
            {
                if (File.Exists(temp))
                {
                    File.Delete(temp);
                }

                throw;
            }
        }



        private static List<string> NormalizeSpacing(
            List<string> lines)
        {
            List<string> result =
                new();


            bool previousBlank =
                false;



            foreach (string line in lines)
            {
                bool blank =
                    string.IsNullOrWhiteSpace(line);



                if (blank && previousBlank)
                {
                    continue;
                }


                result.Add(line);


                previousBlank =
                    blank;
            }


            return result;
        }
    }
}