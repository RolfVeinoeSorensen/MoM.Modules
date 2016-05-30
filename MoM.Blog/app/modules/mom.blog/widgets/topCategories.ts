import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import {BlogPublicService} from "../services/blogpublicservice";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";

@Component({
    selector: "blog-topcategories",
    templateUrl: "/blog/widgets/topcategories",
    providers: [BlogPublicService],
    directives: CORE_DIRECTIVES
})
export class TopCategoriesComponent implements OnInit {
    categories: Category;
    isLoading: boolean = false;
    pageSize: number = 10;

    constructor(private service: BlogPublicService) { }

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