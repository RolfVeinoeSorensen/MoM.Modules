﻿import {Component, OnInit} from "@angular/core";
import {TAB_DIRECTIVES} from "ng2-bootstrap/ng2-bootstrap";
import {Paging,PagingWithSort} from "../interfaces/iPager";
import {AdminIdentityService} from "../services/adminidentityservice";

@Component({
    selector: "mom-admin-security",
    directives: [TAB_DIRECTIVES],
    providers: [AdminIdentityService],
    templateUrl: "/cms/pages/adminsecurity"
})
export class AdminSecurityComponent implements OnInit {
    isLoading: boolean = false;
    users: any;
    pagerUsers: PagingWithSort;
    //message: string;

    constructor(
        private service: AdminIdentityService
    ) { }

    ngOnInit() {
        this.initUsers();
    }

    initUsers() {
        this.pagerUsers = { pageNo: 0, pageSize: 10, sortColumn: "UserName", sortByAscending: false };
        this.getUsers();
    }

    getUsers() {
        this.service.getUsers(this.pagerUsers, json => {
            if (json) {
                this.users = json;
                this.isLoading = false;
                console.log(this.users);
            }
        });
    }
}