import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogPublicService} from "../services/blogpublicservice";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";

@Component({
    selector: "blog-tagcloud",
    templateUrl: "/blog/widgets/tagcloud",
    providers: [BlogPublicService],
    directives: CORE_DIRECTIVES
})
export class TagCloudComponent implements OnInit {
    tags: Tag;
    isLoading: boolean = false;
    pageSize: number = 10;

    constructor(private service: BlogPublicService) { }

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