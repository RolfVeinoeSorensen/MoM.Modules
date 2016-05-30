import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import {TopCategoriesComponent} from "../widgets/topcategories";
import {LatestsPostsComponent} from "../widgets/latestsposts";
import {TagCloudComponent} from "../widgets/tagcloud";
import {BlogPublicService} from "../services/blogpublicservice";
import {Router, RouteParams, RouteConfig, ROUTER_DIRECTIVES} from "@angular/router-deprecated";

@Component({
    selector: "blog",
    templateUrl: "/blog/pages/blog",
    providers: [BlogPublicService],
    directives: [CORE_DIRECTIVES, ROUTER_DIRECTIVES, TopCategoriesComponent, LatestsPostsComponent, TagCloudComponent]
})
export class BlogComponent implements OnInit {
    //message: string;
    //topCategoriesComponent: TopCategoriesComponent;
    constructor(
        private service: BlogPublicService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        //this.topCategoriesComponent = new TopCategoriesComponent(this.service);
        //this.topCategoriesComponent.get();
        //this.message = "Welcome to EasyModules.NET"
    }
}