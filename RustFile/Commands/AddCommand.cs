using System.CommandLine;
using RustFile.SharedLib.Actions;

namespace RustFile.Commands; 

public class AddCommand {
    public AddSrcs addSrcs = new();
    
    private Option<string> structOption = new(
        name: "struct",
        description: "Add a Rust struct file, and try to add it to mod.rs in current dir.",
        getDefaultValue: () => ""
    );
    
    private Option<string> traitOption = new(
        name: "trait",
        description: "Add a Rust file with trait, and try to add it to mod.rs in current dir.",
        getDefaultValue: () => ""
    );
    
    private Option<string> enumOption = new(
        name: "enum",
        description: "Add a Rust file with enum, and try to add it to mod.rs in current dir.",
        getDefaultValue: () => ""
    );
    
    private Option<bool> pubOption = new(
        name: "pub",
        description: "Set access modifier to public."
    );
    public Command WriteCommand { get; private set; }
    
    public AddCommand() {
        WriteCommand = new("add", "Add a rust file and try to add it to mod.rs in current dir.") {
            structOption,
            traitOption,
            enumOption,
            pubOption
        };
        
        WriteCommand.SetHandler(async (structName, traitName, enumName, isPub) =>
        {
            addSrcs.AddFile(structName, traitName, enumName, isPub);
        },structOption, traitOption, enumOption, pubOption);
    }
}