import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogService} from "../services/blog";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import {Router, RouteParams} from 'angular2/router';

@Component({
    selector: "blog-latestsposts",
    templateUrl: "/blog/widgets/latestsposts",
    providers: [BlogService],
    directives: CORE_DIRECTIVES
})
export class LatestsPostsComponent implements OnInit {
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

    onPostViewMore(post: Post) {
        console.log(post)
        this.router.navigate(['../Post', { year: post.year, month: post.month, urlSlug: post.urlSlug }]);
    }

    get() {
        this.isLoading = true;
        this.paging = {pageNo:0, pageSize:10 };
        this.service.getLatestsPosts(this.paging, json => {
            if (json) {
                this.posts = json;
                this.isLoading = false;
            }
        });
    }
}