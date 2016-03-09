import {Component, OnInit} from "angular2/core";
import {AsyncRoute, Router, RouteDefinition, RouteConfig, Location, ROUTER_DIRECTIVES} from "angular2/router";

declare var System: any;

@Component({
    selector: "app",
    templateUrl: "/components/template",
    directives: [ROUTER_DIRECTIVES]
})

export class AppComponent implements OnInit {
    public routes: RouteDefinition[] = null;
    constructor(private router: Router,
        private location: Location) {

    }

    ngOnInit() {
        if (this.routes === null) {
            this.routes = [
                new AsyncRoute({
                    path: "/home",
                    name: "Home",
                    useAsDefault: true,
                    loader: () => System.import("app/components/home").then(c => c["HomeComponent"])
                }),
                new AsyncRoute({
                    path: "/services",
                    name: "Services",
                    loader: () => System.import("app/components/services").then(c => c["ServicesComponent"])
                }) //,
                //new AsyncRoute({
                //    path: "/filemanager",
                //    name: "FileManager",
                //    loader: () => System.import("app/components/filemanager").then(c => c["FileManagerComponent"])
                //}),
                //new AsyncRoute({
                //    path: "/testfileupload",
                //    name: "TestFileUpload",
                //    loader: () => System.import("app/components/testfileupload").then(c => c["TestFileUploadComponent"])
                //}),
                //new AsyncRoute({
                //    path: "/blog",
                //    name: "Blog",
                //    loader: () => System.import("app/components/blog/blog").then(c => c["BlogComponent"])
                //})
            ];

            this.router.config(this.routes);
        }
    }

    getLinkStyle(route: RouteDefinition) {
        return this.location.path().indexOf(route.path) > -1;
    }
}