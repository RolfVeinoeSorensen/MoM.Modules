﻿import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import {AccountService} from "../services/accountservice";

@Component({
    selector: "account-login-partial",
    templateUrl: "/account/widgets/loginpartial",
    providers: [AccountService],
    directives: CORE_DIRECTIVES
})
export class LoginPartialComponent implements OnInit {
    isLoading: boolean = false;
    pageSize: number = 10;

    constructor(private service: AccountService) { }

    ngOnInit() {
        //this.get();
    }

    logIn() {
        this.isLoading = true;

    }

    logOff() {
        this.isLoading = true;
        this.service.logOff(json => {
            if (json) {
                console.log(json);
                this.isLoading = false;
            }
        });
    }
}