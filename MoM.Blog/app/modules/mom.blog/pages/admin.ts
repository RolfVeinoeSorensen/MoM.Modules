import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import {BlogAdminService} from "../services/blogadminservice";
import {Paging, PagingWithSort, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import {Router, RouteParams} from "@angular/router-deprecated";

@Component({
    selector: "blog-admin",
    templateUrl: "/blog/pages/admin",
    providers: [BlogAdminService],
    directives: [CORE_DIRECTIVES]
})
export class AdminComponent implements OnInit {
    posts: Post;
    isLoading: boolean = false;
    paging: PagingWithSort;

    constructor(
        private service: BlogAdminService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        this.get();
    }

    onPostEdit(post: Post) {
        this.router.navigate(["../AdminBlogPostEdit", { postId: post.postId }]);
    }

    onPostCreate() {
        this.router.navigate(["../AdminBlogPostCreate"]);
    }

    get() {
        this.isLoading = true;
        this.paging = { pageNo: 0, pageSize: 10, sortColumn: "title", sortByAscending: false };
        this.service.getPosts(this.paging, json => {
            if (json) {
                this.posts = json;
                this.isLoading = false;
            }
        });
    }
}