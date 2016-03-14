import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogService} from "../service/blog";
import {Category} from "../interfaces/category";

@Component({
    selector: "blog-categories",
    templateUrl: "/blog/components/categories",
    providers: [BlogService],
    directives: CORE_DIRECTIVES
})
export class CategoriesComponent implements OnInit {
    categories: Category;
    isLoading: boolean = false;

    constructor(private service: BlogService) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.isLoading = true;
        this.service.getCategories(json => {
            if (json) {
                console.log(json);
                this.categories = json;
                this.isLoading = false;
            }
        });
    }
}