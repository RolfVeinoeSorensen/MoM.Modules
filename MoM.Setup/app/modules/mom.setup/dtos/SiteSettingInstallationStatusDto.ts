import {SiteSettingDto} from "./SiteSettingDto";
import {InstallationStatus} from "../enums/InstallationStatus";

export interface SiteSettingInstallationStatusDto {
    siteSetting: SiteSettingDto;
    installationResultCode: string;
    message: string;
    installationStatus: InstallationStatus;
}
