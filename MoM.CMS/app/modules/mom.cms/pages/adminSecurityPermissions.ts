import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import {Paging, PagingWithSort} from "../interfaces/iPager";
import {User, Role} from "../interfaces/iIdentity";
import {AdminIdentityService} from "../services/adminidentityservice";
import {Router, RouteParams} from "@angular/router-deprecated";
import { BUTTON_DIRECTIVES } from "ng2-bootstrap/ng2-bootstrap";

@Component({
    selector: "mom-admin-security-permissions",
    directives: [CORE_DIRECTIVES, BUTTON_DIRECTIVES],
    providers: [AdminIdentityService],
    templateUrl: "/cms/pages/adminsecuritypermissions"
})
export class AdminSecurityPermissionsComponent implements OnInit {
    users: User;
    isLoading: boolean = false;
    paging: PagingWithSort;
    public pageSize: string = "10";

    constructor(
        private service: AdminIdentityService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        this.paging = { pageNo: 0, pageSize: parseInt(this.pageSize), sortColumn: "username", sortByAscending: false };
        this.getUsers();
    }

    onCategoryEdit(user: User) {
        this.getUsers();
    }

    onCategoryCreate(user: User) {
        this.getUsers();
    }

    onCategoryDelete(user: User) {
        this.getUsers();
    }

    onPageSizeChange(pageSize: string) {
        this.paging.pageSize = parseInt(pageSize);
        console.log(this.paging);
        this.getUsers();
    }

    onPageChange(pageNo: number) {
        this.paging.pageNo = pageNo;
        this.getUsers();
    }

    onSortChange(sortColumn: string) {
        console.log("col:" + sortColumn);
        this.paging.sortByAscending = this.paging.sortColumn === sortColumn ? !this.paging.sortByAscending : this.paging.sortByAscending;
        this.paging.sortColumn = sortColumn;
        this.getUsers();
    }

    getUsers() {
        this.isLoading = true;
        this.service.getUsers(this.paging, json => {
            if (json) {
                this.users = json;
                this.isLoading = false;
            }
        });
    }
}