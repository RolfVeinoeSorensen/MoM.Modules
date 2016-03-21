import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import {TopCategoriesComponent} from "../widgets/topcategories";
import {LatestsPostsComponent} from "../widgets/latestsposts";
import {TagCloudComponent} from "../widgets/tagcloud";
import {BlogService} from "../service/blog";
import {Router, RouteParams, RouteConfig, ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
    selector: "blog",
    templateUrl: "/blog/pages/blog",
    providers: [BlogService],
    directives: [CORE_DIRECTIVES, ROUTER_DIRECTIVES, TopCategoriesComponent, LatestsPostsComponent, TagCloudComponent]
})
export class BlogComponent implements OnInit {
    //message: string;
    //topCategoriesComponent: TopCategoriesComponent;
    constructor(
        private service: BlogService,
        private router: Router,
        routeParams: RouteParams
    ) { }

    ngOnInit() {
        //this.topCategoriesComponent = new TopCategoriesComponent(this.service);
        //this.topCategoriesComponent.get();
        //this.message = "Welcome to EasyModules.NET"
    }
}