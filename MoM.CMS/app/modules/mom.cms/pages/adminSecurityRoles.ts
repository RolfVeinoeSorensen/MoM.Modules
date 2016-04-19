import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {Paging, PagingWithSort} from "../interfaces/iPager";
import {User, Role} from "../interfaces/iIdentity";
import {AdminIdentityService} from "../services/adminidentityservice";
import {Router, RouteParams} from 'angular2/router';
import { BUTTON_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';

@Component({
    selector: "mom-admin-security-roles",
    directives: [CORE_DIRECTIVES, BUTTON_DIRECTIVES],
    providers: [AdminIdentityService],
    templateUrl: "/cms/pages/adminsecurityroles"
})
export class AdminSecurityRolesComponent implements OnInit {
    roles: Role;
    isLoading: boolean = false;
    paging: PagingWithSort;
    public pageSize: string = "10";

    constructor(
        private service: AdminIdentityService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        this.paging = { pageNo: 0, pageSize: parseInt(this.pageSize), sortColumn: "name", sortByAscending: false };
        this.getRoles();
    }

    onCategoryEdit(user: User) {
        this.getRoles();
    }

    onCategoryCreate(user: User) {
        this.getRoles();
    }

    onCategoryDelete(user: User) {
        this.getRoles();
    }

    onPageSizeChange(pageSize: string) {
        this.paging.pageSize = parseInt(pageSize);
        console.log(this.paging);
        this.getRoles();
    }

    onPageChange(pageNo: number) {
        this.paging.pageNo = pageNo;
        this.getRoles();
    }

    onSortChange(sortColumn: string) {
        console.log("col:" + sortColumn);
        this.paging.sortByAscending = this.paging.sortColumn == sortColumn ? !this.paging.sortByAscending : this.paging.sortByAscending;
        this.paging.sortColumn = sortColumn;
        this.getRoles();
    }

    getRoles() {
        this.isLoading = true;
        this.service.getRoles(this.paging, json => {
            if (json) {
                this.roles = json;
                this.isLoading = false;
            }
        });
    }
}