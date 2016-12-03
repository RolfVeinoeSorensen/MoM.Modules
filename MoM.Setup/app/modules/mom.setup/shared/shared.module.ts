import { NgModule }     from "@angular/core";
import { CommonModule } from "@angular/common";

import { HttpModule, JsonpModule } from "@angular/http";

import { ForbiddenValidatorDirective } from "./forbidden-name.directive";
import { SubmittedComponent }          from "./submitted.component";

import { SiteSettingDto } from "../dtos/SiteSettingDto";
import { SiteSettingConnectionStringDto } from "../dtos/SiteSettingConnectionStringDto";
import { SiteSettingInstallationStatusDto } from "../dtos/SiteSettingInstallationStatusDto";

@NgModule({
    imports: [
        CommonModule,
        HttpModule,
        JsonpModule
    ],
    declarations: [
        ForbiddenValidatorDirective,
        SubmittedComponent
    ],
    exports: [
        ForbiddenValidatorDirective,
        SubmittedComponent,
        CommonModule
    ]
})
export class SharedModule {
}