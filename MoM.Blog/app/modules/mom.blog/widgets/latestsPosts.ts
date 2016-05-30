import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import {BlogPublicService} from "../services/blogpublicservice";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import {Router, RouteParams} from "@angular/router-deprecated";

@Component({
    selector: "blog-latestsposts",
    templateUrl: "/blog/widgets/latestsposts",
    providers: [BlogPublicService],
    directives: CORE_DIRECTIVES
})
export class LatestsPostsComponent implements OnInit {
    posts: Post;
    isLoading: boolean = false;
    paging: Paging;

    constructor(
        private service: BlogPublicService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        this.get();
    }

    onPostViewMore(post: Post) {
        console.log(post);
        this.router.navigate(["../Post", { year: post.year, month: post.month, urlSlug: post.urlSlug }]);
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