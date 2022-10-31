using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RustFile.SharedLib.Templates;
using RustFile.SharedLib.Templates.Options;
using RustFile.SharedLib.Utils;

namespace RustFile.SharedLib.Actions {
    public class AddSrcs {
        public List<string> allNames { get; private set; } = new();
        public List<string> structNames { get; private set; } = new();
        public List<string> traitNames { get; private set; } = new();
        public List<string> enumNames { get; private set; } = new();
        public bool IsPub { get; private set; } = false;

        public void AddFile(string structName, string traitName, string enumName, bool isPub) {
            if (!structName.Equals("")) {
                structNames = structName.Split(" ").ToList();

                Add(new StructTemplate(new() {
                    IsStructPub = isPub
                }), structNames);
            }

            if (!traitName.Equals("")) {
                traitNames = traitName.Split(" ").ToList();

                Add(new TraitTemplates(new() {
                    IsTraitPub = isPub
                }), traitNames);
            }

            if (!enumName.Equals("")) {
                enumNames = enumName.Split(" ").ToList();

                Add(new EnumTemplate(new() {
                }), enumNames);
            }

            IsPub = isPub;
            allNames = structNames.Union(traitNames).Union(enumNames).ToList();
            if (!FileUtils.IsRootDir()) FileUtils.WriteFileToMod(allNames, isPub);
        }

        private void Add(ITemplate template, List<string> list) {
            Console.WriteLine("Processing...");

            list.ForEach(s =>
            {
                string fullname = "";
                if (!s.EndsWith(".rs")) fullname = $"{s}.rs";
                string path = Path.Combine(FileUtils.getCurrentDir(), fullname);
                if (File.Exists(path)) return;

                using (File.Create(path)) {
                }

                using (var tw = new StreamWriter(path, true)) {
                    tw.WriteLine(template.GetTemplate(s));
                }
            });
        }
    }
}