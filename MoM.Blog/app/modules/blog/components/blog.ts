import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {CategoriesComponent} from "./categories";
import {BlogService} from "../service/blog";

@Component({
    selector: "blog",
    templateUrl: "/blog/components/index",
    providers: [BlogService],
    directives: [CORE_DIRECTIVES, CategoriesComponent]
})
export class BlogComponent implements OnInit {
    //message: string;
    //topCategoriesComponent: TopCategoriesComponent;
    constructor(private service: BlogService) { }

    ngOnInit() {
        //this.topCategoriesComponent = new TopCategoriesComponent(this.service);
        //this.topCategoriesComponent.get();
        //this.message = "Welcome to EasyModules.NET"
    }
}