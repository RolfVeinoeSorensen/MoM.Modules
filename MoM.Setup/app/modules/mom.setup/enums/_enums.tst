$Enums(MoM.Module.Enums*)[
    export enum $Name {$Values[
        $name = $Value,]
    }]
${
    using Typewriter.Extensions.Types;
	string Imports(Property property){
		var type = property.Type;
        if(type.IsEnum){
            return "import {" + type.ToString() + "} from \"./" + property.Type.ToString() + "\";" + Environment.NewLine;
        }
		if (type.IsPrimitive){
			return string.Empty;
            }
		return "import {" + type.ToString().Replace("[", string.Empty).Replace("]", string.Empty) + "} from \"./" + property.Type.ToString().Replace("[", string.Empty).Replace("]", string.Empty) + "\";" + Environment.NewLine;
	}
    Template(Settings settings)
    {
        settings
            .IncludeCurrentProject()
            .IncludeProject("MoM.Module");
    }
}