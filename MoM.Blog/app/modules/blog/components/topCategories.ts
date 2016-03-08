import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {BlogService} from "../service/blog";
import {Category} from "../interfaces/category";

@Component({
    selector: "blog-top-categories",
    templateUrl: "/components/blogtopcategories",
    providers: [BlogService],
    directives: CORE_DIRECTIVES
})
export class TopCategoriesComponent implements OnInit {
    categories: Category;
    isLoading: boolean = false;

    constructor(private service: BlogService) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.isLoading = true;
        this.service.getTopCategories(json => {
            if (json) {
                console.log(json);
                this.categories = json;
                this.isLoading = false;
            }
        });
    }
}