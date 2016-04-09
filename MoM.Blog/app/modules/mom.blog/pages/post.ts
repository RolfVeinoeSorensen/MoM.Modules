import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogService} from "../services/blog";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import {Router, RouteParams} from 'angular2/router';
import {Codeblock} from 'ng2-prism/codeblock';
import {Csharp, Css, Javascript, Json} from 'ng2-prism/languages';

@Component({
    selector: "blog-post",
    templateUrl: "/blog/pages/post",
    providers: [BlogService],
    directives: [CORE_DIRECTIVES, Codeblock, Csharp, Css, Javascript, Json] //, Csharp, Css, Javascript, Json]
})
export class PostComponent implements OnInit {
    post: Post;
    isLoading: boolean = false;
    year: number;
    month: number;
    urlSlug: string;

    constructor(
        private service: BlogService,
        private router: Router,
        private routeParams: RouteParams
    )
    {

    }

    ngOnInit() {
        this.year = +this.routeParams.get("year");
        this.month = +this.routeParams.get("month");
        this.urlSlug = this.routeParams.get("urlSlug");
        this.get();
    }

    get() {
        this.isLoading = true;
        this.service.getPost(this.year , this.month, this.urlSlug, json => {
            if (json) {
                //console.log(json);
                this.post = json;
                this.isLoading = false;
            }
        });
    }
}