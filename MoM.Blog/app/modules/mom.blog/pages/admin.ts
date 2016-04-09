import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogService} from "../services/blog";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import {Router, RouteParams} from 'angular2/router';

@Component({
    selector: "blog-admin",
    templateUrl: "/blog/pages/admin",
    providers: [BlogService],
    directives: [CORE_DIRECTIVES]
})
export class AdminComponent implements OnInit {
    posts: Post;
    isLoading: boolean = false;
    paging: Paging;

    constructor(
        private service: BlogService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        this.get();
    }

    onPostEdit(post: Post) {
        this.router.navigate(['../AdminBlogPostEdit', { postId: post.postId }]);
    }

    onPostCreate() {
        this.router.navigate(['../AdminBlogPostCreate']);
    }

    get() {
        this.isLoading = true;
        this.paging = { pageNo: 0, pageSize: 10 };
        this.service.getLatestsPosts(this.paging, json => {
            if (json) {
                this.posts = json;
                this.isLoading = false;
            }
        });
    }
}