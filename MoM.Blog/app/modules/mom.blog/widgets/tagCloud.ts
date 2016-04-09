import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogService} from "../services/blog";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";

@Component({
    selector: "blog-tagcloud",
    templateUrl: "/blog/widgets/tagcloud",
    providers: [BlogService],
    directives: CORE_DIRECTIVES
})
export class TagCloudComponent implements OnInit {
    tags: Tag;
    isLoading: boolean = false;
    pageSize: number = 10;

    constructor(private service: BlogService) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.isLoading = true;
        this.service.getTagsWithPostcount(this.pageSize, json => {
            if (json) {
                this.tags = json;
                this.isLoading = false;
            }
        });
    }
}