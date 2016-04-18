import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogAdminService} from "../services/blogadminservice";
import {Paging, PagingWithSort, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import {Router, RouteParams} from 'angular2/router';
import { BUTTON_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';

@Component({
    selector: "blog-admin",
    templateUrl: "/blog/pages/admincategories",
    providers: [BlogAdminService],
    directives: [CORE_DIRECTIVES, BUTTON_DIRECTIVES]
})
export class AdminCategoriesComponent implements OnInit {
    categories: Category;
    isLoading: boolean = false;
    paging: PagingWithSort;
    public pageSize: string = "10";

    constructor(
        private service: BlogAdminService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        this.paging = { pageNo: 0, pageSize: parseInt(this.pageSize), sortColumn: "name", sortByAscending: false };
        this.getCategories();
    }

    onCategoryEdit(category: Category) {
        this.getCategories();
    }

    onCategoryCreate(category: Category) {
        this.getCategories();
    }

    onCategoryDelete(category: Category) {
        this.getCategories();
    }

    onPageSizeChange(pageSize: string) {
        this.paging.pageSize = parseInt(pageSize);
        console.log(this.paging);
        this.getCategories();
    }

    onPageChange(pageNo: number) {
        this.paging.pageNo = pageNo;
        this.getCategories();
    }

    onSortChange(sortColumn: string) {
        console.log("col:" + sortColumn);
        this.paging.sortByAscending = this.paging.sortColumn == sortColumn ? this.paging.sortByAscending : !this.paging.sortByAscending;
        this.paging.sortColumn = sortColumn;
        this.getCategories();
    }

    getCategories(){
        this.isLoading = true;        
        this.service.getCategories(this.paging, json => {
            if (json) {
                this.categories = json;
                this.isLoading = false;
            }
        });
    }
}