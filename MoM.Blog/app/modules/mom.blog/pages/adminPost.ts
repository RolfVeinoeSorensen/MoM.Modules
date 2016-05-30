import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import {BlogAdminService} from "../services/blogadminservice";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import {Router, RouteParams} from "@angular/router-deprecated";
//import {Codeblock} from "ng2-prism/codeblock";
//import {Csharp, Css, Javascript, Json} from "ng2-prism/languages";

@Component({
    selector: "blog-admin-post",
    templateUrl: "/blog/pages/AdminPost",
    providers: [BlogAdminService],
    directives: [CORE_DIRECTIVES] //, Csharp, Css, Javascript, Json]
})
export class AdminPostComponent implements OnInit {
    post: Post;
    isLoading: boolean = false;
    postId: number;
    isNewPost: boolean = true;
    pageTitle: string;
    submitted: boolean = false;

    constructor(
        private service: BlogAdminService,
        private router: Router,
        private routeParams: RouteParams
    )
    {
        this.postId = +this.routeParams.get("postId");
    }

    ngOnInit() {
            console.log(this.postId);
        if (this.postId !== 0) {
            this.isNewPost = false;
            this.pageTitle = "Edit post";
            this.get();
        }
        else {
            this.pageTitle = "Create post";
            this.post = { title: "", postId: 0, content: "", category: null, teaser: "", isPublished: 0, meta: "", day: 0, modifiedDate: new Date(), month: null, monthName: "", monthNameShort: "", postedDate: new Date(), postTags: [], urlSlug: "", year: 0 };
            this.isLoading = false;
        }
    }

    get() {
        this.isLoading = true;
        this.service.getPostById(this.postId, json => {
            if (json) {
                this.post = json;
                this.isLoading = false;
            }
        });
    }

    onSubmit() {
        this.submitted = true;
        console.log("submit");
        console.log(this.post);
        console.log(this.isNewPost);
    }

    onAddPost(post: Post) {
        this.isLoading = true;
        this.service.createPost(this.post, json => {
            if (json) {
                this.post = json;
                this.isLoading = false;
            }
        });
    }

    onUpdatePost(post: Post) {
        console.log("update");
        console.log(post);
        this.isLoading = true;
        this.service.updatePost(this.post, json => {
            if (json) {
                this.post = json;
                this.isLoading = false;
            }
        });
    }

    onCancel() {
        this.router.navigate(["../AdminBlog"]);
    }
}