import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
//import {BlogAdminService} from "../services/blogadminservice";
import {Paging, PagingWithSort} from "../interfaces/ipager";
import {Router, RouteParams} from 'angular2/router';

@Component({
    selector: "cms-admin-content-pages",
    templateUrl: "/cms/pages/admincontentpages",
    //providers: [BlogAdminService],
    directives: [CORE_DIRECTIVES]
})
export class AdminContentPagesComponent implements OnInit {
    pages: any;
    isLoading: boolean = false;
    paging: PagingWithSort;

    constructor(
        //private service: BlogAdminService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        this.get();
    }

    onPageEdit(page: any) {
        this.router.navigate(['../AdminContentPage', { pageId: page.pageId }]);
    }

    onPageCreate() {
        this.router.navigate(['../AdminContentPage', { pageId: 0 }]);
    }

    get() {
        this.isLoading = true;
        this.paging = { pageNo: 0, pageSize: 10, sortColumn: "title", sortByAscending: false };
        //this.service.getPosts(this.paging, json => {
        //    if (json) {
        //        this.pages = json;
        //        this.isLoading = false;
        //    }
        //});
    }
}