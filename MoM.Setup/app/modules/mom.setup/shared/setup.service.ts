import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Subject } from "rxjs/Subject";

import { SiteSettingDto } from "../dtos/SiteSettingDto";
import { SiteSettingConnectionStringDto } from "../dtos/SiteSettingConnectionStringDto";
import { SiteSettingInstallationStatusDto } from "../dtos/SiteSettingInstallationStatusDto";
import { SiteSettingEmailDto } from "../dtos/SiteSettingEmailDto";
import { UserCreateDto } from "../dtos/UserCreateDto";
import { SetupApi } from "../api/setup.api";

@Injectable()
export class SetupService {
    private installStepsCompleted = new Subject<number>();
    isAllreadyInstalled: boolean = false;
    stepOneComplete: boolean = false;
    stepTwoComplete: boolean = false;
    stepThreeComplete: boolean = false;
    stepFourComplete: boolean = false;
    stepFiveComplete: boolean = false;
    siteSetting: SiteSettingDto;
    connectionstring = new Subject<SiteSettingConnectionStringDto>();
    connectionAuthenticationModel: string = "sql";
    status: SiteSettingInstallationStatusDto;
    isLoading: boolean = false;
    hasError: boolean = false;
    errorMessage: string;
    admin: UserCreateDto;

    // Observable streams
    installStepsCompleted$ = this.installStepsCompleted.asObservable();
    connectionstring$ = this.connectionstring.asObservable();

    constructor(private api: SetupApi) { }

    init() {
        this.isLoading = true;
        this.api.init().subscribe(
            status => {
                this.siteSetting = status.siteSetting;
                this.status = status;
                this.checkCompletedSteps();
                //this.mailForm.value = this.siteSetting.email;
            },
            error => {
                this.hasError = true;
                this.errorMessage = <any>error;
                this.isLoading = false;
            }
        );
    }

    getConnectionstring() {
        this.isLoading = true;
        this.api.getConnectionString().subscribe(connectionstring => {
                this.connectionstring.next(connectionstring);
                this.connectionAuthenticationModel = connectionstring.useWindowsAuthentication === true ? "windows" : "sql";
                this.isLoading = false;
            },
            error => {
                this.hasError = true;
                this.errorMessage = <any>error;
                this.isLoading = false;
            }
        );
    }

    onSaveDatabaseSettings() {
        this.isLoading = true;
        //this.connectionstring.useWindowsAuthentication = this.connectionAuthenticationModel === "windows" ? true : false;
        this.connectionstring.subscribe(connectionstring => {
            this.api.saveConnectionstring(connectionstring).subscribe(
            status => {
                this.status = status;
                this.checkCompletedSteps();
                this.isLoading = false;
            },
            error => {
                this.hasError = true;
                this.errorMessage = <any>error;
                this.isLoading = false;
            });
        });
    }

    onAdminAccountSave(admin: UserCreateDto) {
        this.admin = admin;
        console.log(this.admin);
        this.api.createAdmin(this.admin).subscribe(
            status => {
                this.status = status;
                this.checkCompletedSteps();
                this.isLoading = false;
            },
            error => {
                this.hasError = true;
                this.errorMessage = <any>error;
                this.isLoading = false;
            }
        );
    }

    onSocialAccountsSave(siteSetting: SiteSettingDto) {
        this.siteSetting = siteSetting;
        this.api.setupSocial(this.siteSetting).subscribe(
            status => {
                this.status = status;
                this.checkCompletedSteps();
                this.isLoading = false;
            },
            error => {
                this.hasError = true;
                this.errorMessage = <any>error;
                this.isLoading = false;
            }
        );
    }

    onMailSettingsSave(siteSetting: SiteSettingDto) {
        this.siteSetting = siteSetting;
        console.log(this.siteSetting.email);
        this.api.setupMail(this.siteSetting).subscribe(
            status => {
                this.status = status;
                this.checkCompletedSteps();
                this.isLoading = false;
            },
            error => {
                this.hasError = true;
                this.errorMessage = <any>error;
                this.isLoading = false;
            }
        );
    }

    checkCompletedSteps() {
        var self = this;
        self.installStepsCompleted.next(self.status.installationStatus);
        for (var i = 0; i < self.status.installationStatus; i++) {
            self.setCompletedStep(i);
        };
        console.log(self.installStepsCompleted);
    }

    setCompletedStep(status: number) {
        switch (status) {
            case 1:
                this.stepOneComplete = true;
                return;
            case 2:
                this.stepTwoComplete = true;
                return;
            case 3:
                this.stepThreeComplete = true;
                return;
            case 4:
                this.stepFourComplete = true;
                return;
            case 5:
                this.stepFiveComplete = true;
                return;
            case 6:
                this.isAllreadyInstalled = true;
            default:
                return;
        }
    }





    //// Observable string sources
    //private missionAnnouncedSource = new Subject<string>();
    //private missionConfirmedSource = new Subject<string>();
    //// Observable string streams
    //missionAnnounced$ = this.missionAnnouncedSource.asObservable();
    //missionConfirmed$ = this.missionConfirmedSource.asObservable();
    //// Service message commands
    //announceMission(mission: string) {
    //    this.missionAnnouncedSource.next(mission);
    //}
    //confirmMission(astronaut: string) {
    //    this.missionConfirmedSource.next(astronaut);
    //}
}