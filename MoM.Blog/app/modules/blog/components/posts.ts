import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogService} from "../service/blog";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";

@Component({
    selector: "blog-posts",
    templateUrl: "/blog/components/posts",
    providers: [BlogService],
    directives: CORE_DIRECTIVES
})
export class PostsComponent implements OnInit {
    posts: Post;
    isLoading: boolean = false;
    paging: Paging;

    constructor(private service: BlogService) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.isLoading = true;
        this.paging = {pageNo:0, pageSize:10 };
        this.service.getPosts(this.paging, json => {
            if (json) {
                console.log(json);
                this.posts = json;
                this.isLoading = false;
            }
        });
    }
}