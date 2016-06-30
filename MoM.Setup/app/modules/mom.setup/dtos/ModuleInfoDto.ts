import {ModuleType} from "../enums/ModuleType";

export interface ModuleInfoDto {
    name: string;
    description: string;
    authors: string;
    iconCss: string;
    type: ModuleType;
    versionMajor: number;
    versionMinor: number;
    loadPriority: number;
}
