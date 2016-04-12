import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogAdminService} from "../services/blogadminservice";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import {Router, RouteParams} from 'angular2/router';

@Component({
    selector: "blog-admin",
    templateUrl: "/blog/pages/admincategories",
    providers: [BlogAdminService],
    directives: [CORE_DIRECTIVES]
})
export class AdminCategoriesComponent implements OnInit {
    categories: Category;
    isLoading: boolean = false;
    paging: Paging;

    constructor(
        private service: BlogAdminService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        //this.get();
    }

    onPostEdit(category: Category) {
        this.router.navigate(['../AdminBlogCategoryEdit', { postId: category.categoryId }]);
    }

    onPostCreate() {
        this.router.navigate(['../AdminBlogCategoryCreate']);
    }

    //get() {
    //    this.isLoading = true;
    //    this.paging = { pageNo: 0, pageSize: 10 };
    //    this.service.getCategories(this.paging, json => {
    //        if (json) {
    //            this.categories = json;
    //            this.isLoading = false;
    //        }
    //    });
    //}
}