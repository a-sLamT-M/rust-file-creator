using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RustFile.SharedLib.Utils {
    public class FileUtils {
        private static string dir = System.IO.Directory.GetCurrentDirectory();
        private static string modPath = Path.Combine(dir, "mod.rs");
        public static string getCurrentDir() {
            return dir;
        }
        public static bool IsModExist() {
            return File.Exists(modPath);
        }
        public static bool IsRootDir() {
            return File.Exists(Path.Combine(Path.GetFullPath(".."),"Cargo.toml"));
        }
        public static void CreateModRs() {
            using(File.Create(modPath)){};
        }
        public static void WriteFileToMod(List<string> filenames, bool isPub) {
            List<string> modExist = new();


            if (IsModExist()) {
                modExist = File.ReadLines(modPath).ToList();
                foreach (var m in modExist) {
                    Console.WriteLine(m);
                }
            }
            else {
                CreateModRs();
            }
            foreach (var val in filenames) {
                if (modExist.Contains($"mod {val};") || modExist.Contains($"pub mod {val};")) continue;
                Console.WriteLine(val);
                if (isPub) {
                    File.AppendAllText(modPath, "pub mod " + val + ";"+ Environment.NewLine);
                }
                else {
                    File.AppendAllText(modPath, "mod " + val + ";"+ Environment.NewLine);
                }
            }
        }
    }
}

