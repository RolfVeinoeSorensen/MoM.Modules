import { Component, OnInit }      from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location }               from "@angular/common";
import { NgForm, FormGroup, FormBuilder, Validators }    from "@angular/forms";

import {SiteSettingDto} from "../dtos/SiteSettingDto";
import {SiteSettingConnectionStringDto} from "../dtos/SiteSettingConnectionStringDto";
import {SiteSettingInstallationStatusDto} from "../dtos/SiteSettingInstallationStatusDto";
import {SiteSettingEmailDto} from "../dtos/SiteSettingEmailDto";
import {UserCreateDto} from "../dtos/UserCreateDto";
import { SetupService } from "../api/SetupService";
import { ControlMessages } from "../validation/control-messages.component";
import { ValidationService } from "../validation/validation.service";

import { ButtonsModule, TabsModule, ProgressbarComponent } from "ng2-bootstrap/ng2-bootstrap";


@Component({
    selector: "install-page",
    templateUrl: "/setup/pages/setupguide",
    providers: [SetupService],
    directives: [ControlMessages]
})
export class InstallComponent implements OnInit {
    installStepsCompleted: number = 0;
    isAllreadyInstalled: boolean = false;
    stepOneComplete: boolean = false;
    stepTwoComplete: boolean = false;
    stepThreeComplete: boolean = false;
    stepFourComplete: boolean = false;
    stepFiveComplete: boolean = false;
    siteSetting: SiteSettingDto;
    connectionstring: SiteSettingConnectionStringDto;
    connectionAuthenticationModel: string = "sql";
    status: SiteSettingInstallationStatusDto;
    isLoading: boolean = false;
    hasError: boolean = false;
    errorMessage: string;
    admin: UserCreateDto;
    adminCreateForm: FormGroup;
    mailForm: FormGroup;
    socialAccountsForm: FormGroup;
    constructor(
        private service: SetupService,
        fromBuilder: FormBuilder
    ) {
        this.adminCreateForm = fromBuilder.group({
            username: ["Administrator", Validators.required],
            email: ["", Validators.compose([Validators.required, ValidationService.emailValidator])],
            password: ["", Validators.compose([Validators.required, ValidationService.passwordValidator])],
            confirm: ["", Validators.compose([Validators.required, ValidationService.passwordMatchValidator])],
        });

        //this.socialAccountsForm = fromBuilder.group({
        //    facebookEnabled: [this.siteSetting.authentication.facebook.enabled],
        //    facebookAppId: [this.siteSetting.authentication.facebook.appId, Validators.required],
        //    facebookAppSecret: [this.siteSetting.authentication.facebook.appSecret, Validators.required],
        //});

        this.mailForm = fromBuilder.group({
            hostname: ["", Validators.required],
            password: [""], //, ValidationService.requiredIfRequireCredentialsValidator],
            port: ["25", Validators.compose([Validators.required, ValidationService.numberValidator])],
            requireCredentials: [true],
            senderEmailAdress: ["", Validators.compose([Validators.required, ValidationService.emailValidator])],
            userName: [""], //, ValidationService.requiredIfRequireCredentialsValidator],
            useSSL: [false]
        });
    }

    ngOnInit() {
        this.init();
    }

    init() {
        this.isLoading = true;
        this.service.init().subscribe(
            status => {
                this.siteSetting = status.siteSetting;
                this.status = status;
                this.checkCompletedSteps();
                this.getConnectionstring();
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
        this.service.getConnectionString().subscribe(
            connectionstring => {
                this.connectionstring = connectionstring;
                this.connectionAuthenticationModel = this.connectionstring.useWindowsAuthentication === true ? "windows" : "sql";
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
        this.connectionstring.useWindowsAuthentication = this.connectionAuthenticationModel === "windows" ? true : false;
        this.service.saveConnectionstring(this.connectionstring).subscribe(
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
    }

    onAdminAccountSave() {
        var self = this;
        if (this.adminCreateForm.dirty && this.adminCreateForm.valid) {
            this.admin = { username: this.adminCreateForm.value.username, email: this.adminCreateForm.value.email, password: this.adminCreateForm.value.password };
            console.log(this.admin);
            this.service.createAdmin(this.admin).subscribe(
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
    }

    onSocialAccountsSave() {
        this.service.setupSocial(this.siteSetting).subscribe(
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

    onMailSettingsSave() {
        var self = this;
        if (this.mailForm.dirty && this.mailForm.valid) {
            this.siteSetting.email = {
                hostName: this.mailForm.value.hostname,
                password: this.mailForm.value.password,
                port: this.mailForm.value.port,
                requireCredentials: this.mailForm.value.requireCredentials,
                senderEmailAdress: this.mailForm.value.senderEmailAdress,
                userName: this.mailForm.value.userName,
                useSSL: this.mailForm.value.useSSL
            };
            console.log(this.siteSetting.email);
            this.service.setupMail(this.siteSetting).subscribe(
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
    }

    checkCompletedSteps() {
        var self = this;
        self.installStepsCompleted = self.status.installationStatus;
        for (var i = 0; i < self.installStepsCompleted; i++) {
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
}