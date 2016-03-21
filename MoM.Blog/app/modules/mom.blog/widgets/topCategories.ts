import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogService} from "../service/blog";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";

@Component({
    selector: "blog-topcategories",
    templateUrl: "/blog/widgets/topcategories",
    providers: [BlogService],
    directives: CORE_DIRECTIVES
})
export class TopCategoriesComponent implements OnInit {
    categories: Category;
    isLoading: boolean = false;
    pageSize: number = 10;

    constructor(private service: BlogService) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.isLoading = true;
        this.service.getCategoriesWithPostcount(this.pageSize, json => {
            if (json) {
                this.categories = json;
                this.isLoading = false;
            }
        });
    }
}