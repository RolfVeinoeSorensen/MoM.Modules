/* tslint:disable: member-ordering forin */
import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

import { ButtonsModule } from "ng2-bootstrap/ng2-bootstrap";

import { SetupApi } from "../../api/setup.api";
import { SetupService } from "../../shared/setup.service";

import { SiteSettingConnectionStringDto } from "../../dtos/SiteSettingConnectionStringDto";

import { Hero } from "../../shared/hero";
import { forbiddenNameValidator } from "../../shared/forbidden-name.directive";

@Component({
    //moduleId: module.id,
    selector: "database-form",
    providers: [SetupApi, SetupService],
    templateUrl: "/setup/pages/database"
})
export class DatabaseComponent implements OnInit {

    //powers = ["Really Smart", "Super Flexible", "Weather Changer"];

    //hero = new Hero(18, "Dr. WhatIsHisName", this.powers[0], "Dr. What");

    submitted = false;
    active = true;
    connectionstring: SiteSettingConnectionStringDto = {database:"", password:"", server:"",username:"",useWindowsAuthentication:false};
    connectionAuthenticationModel: string = "0";



    onSubmit() {
        this.submitted = true;
        this.connectionstring = this.connectionStringForm.value;
        console.log(this.connectionstring);
    }

    constructor(private service: SetupService, private api: SetupApi, private fb: FormBuilder) {
        service.connectionstring$.subscribe(connection => {
            console.log(connection);
            this.connectionstring = connection;
            this.connectionAuthenticationModel = this.connectionstring.useWindowsAuthentication === true ? "1" : "0";
        });
    }

    connectionStringForm: FormGroup;

    ngOnInit(): void {
        this.buildForm();
        this.init();
    }

    init() {
        this.service.getConnectionstring();
    }
    //forbiddenNameValidator(/bob/i)
    buildForm(): void {
        this.connectionStringForm = this.fb.group({
            "server": [this.connectionstring.server, [
                Validators.required,
                Validators.minLength(1),
                Validators.maxLength(24)
            ]
            ],
            "database": [this.connectionstring.database, Validators.required],
            "useWindowsAuthentication": [this.connectionAuthenticationModel, Validators.required],
            "username": [this.connectionstring.username, Validators.required],
            "password": [this.connectionstring.password, Validators.required]
        });

        this.connectionStringForm.valueChanges
            .subscribe(data => this.onValueChanged(data));

        this.onValueChanged(); // (re)set validation messages now
    }


    onValueChanged(data?: any) {
        if (!this.connectionStringForm) { return; }
        const form = this.connectionStringForm;

        for (const field in this.formErrors) {
            // clear previous error message (if any)
            this.formErrors[field] = "";
            const control = form.get(field);

            if (control && control.dirty && !control.valid) {
                const messages = this.validationMessages[field];
                for (const key in control.errors) {
                    this.formErrors[field] += messages[key] + " ";
                }
            }
        }
    }

    formErrors = {
        "server": "",
        "database": "",
        "useWindowsAuthentication": "",
        "username": "",
        "password": ""
    };
    //"name": {
    //    "required": "Name is required.",
    //    "minlength": "Name must be at least 4 characters long.",
    //    "maxlength": "Name cannot be more than 24 characters long.",
    //    "forbiddenName": "Someone named 'Bob' cannot be a hero."
    //},
    validationMessages = {
        "server": {
            "required": "Server is required."
        },
        "database": {
            "required": "Database is required."
        },
        "useWindowsAuthentication": "",
        "username": {
            "required": "Username is required."
        },
        "password": {
            "required": "Password is required."
        }
    };
}